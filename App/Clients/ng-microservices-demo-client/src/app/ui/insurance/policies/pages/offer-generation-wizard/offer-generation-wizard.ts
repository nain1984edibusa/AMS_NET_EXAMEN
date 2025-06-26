import { ChangeDetectorRef, Component, inject, OnInit, ViewChild } from '@angular/core';
import { ProductModel } from '../../../../../application/products/product/models/products-model';
import { ProductApplicationService } from '../../../../../application/products/product/services/product-application-service';
import { CoverModel } from '../../../../../application/products/product/models/cover-model';
import { QuestionModel } from '../../../../../application/products/product/models/question-model';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatStepper, MatStepperModule } from '@angular/material/stepper';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule} from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule, MatSelectionList } from '@angular/material/list';
import { MatSelectModule } from '@angular/material/select';
import { CurrencyPipe, DatePipe, KeyValuePipe } from '@angular/common';
import { isChoiceQuestionModel } from '../../../../../application/products/product/models/question-model.typeguards';
import { OfferApplicationService } from '../../../../../application/policies/offer/services/offer-application-service';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { OfferModel } from '../../../../../application/policies/offer/models/offer-model';
import { QuestionAnswerModel } from '../../../../../application/policies/offer/models/question-answer-model';
import { TextQuestionAnswerModel } from '../../../../../application/policies/offer/models/text-question-answer-model';
import { NumericQuestionAnswerModel } from '../../../../../application/policies/offer/models/numeric-question-answer-model';
import { ChoiceQuestionAnswerModel } from '../../../../../application/policies/offer/models/choice-question-answer-model';
import { CalculatePriceCommand } from '../../../../../application/policies/offer/use-cases/commands/calculate-price/calculate-price-command';
import { PolicyApplicationService } from '../../../../../application/policies/policy/services/policy-application-service';
import { CreatePolicyCommand } from '../../../../../application/policies/policy/use-cases/commands/createPolicy/create-policy-command';
import { PersonModel } from '../../../../../application/policies/policy/models/person-model';
import { AddressModel } from '../../../../../application/policies/policy/models/adress-model';
import { PolicyModel } from '../../../../../application/policies/policy/models/policy-model';

@Component({
  selector: 'app-offer-generation-wizard',
  imports: [
    MatStepperModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatListModule,
    MatSelectModule,
    CurrencyPipe,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    DatePipe    
  ],
  templateUrl: './offer-generation-wizard.html',
  styleUrl: './offer-generation-wizard.scss'
})
export class OfferGenerationWizard implements OnInit {
  @ViewChild('stepper') stepper!: MatStepper;

  private productsApplicationService = inject(ProductApplicationService);
  private offerApplicationService = inject(OfferApplicationService);
  private policyApplicationService = inject(PolicyApplicationService);

  public products: ProductModel[] = [];
  @ViewChild('coverList') coverList!: MatSelectionList;

  public selectedProduct?: ProductModel;
  public calculatePrice?: OfferModel;
  public policyResult?: PolicyModel;
  public summaryData?: any;
  public selectedCovers: CoverModel[] = [];
  public questions: QuestionModel[] = [];
  public answersForm!: FormGroup;
  public datesForm!: FormGroup;
  public holderForm!: FormGroup;
  public isChoiceQuestionModel = isChoiceQuestionModel;

  private fb: FormBuilder = inject(FormBuilder);
  private cdr = inject(ChangeDetectorRef);
  public currentStep = 0;

  public ngOnInit(): void {
    this.answersForm = this.fb.group({});
    this.datesForm = this.fb.group({ policyFrom: [null], policyTo: [null] });
    this.holderForm = this.fb.group({firstName: [''],lastName: [''],taxId: [''],country: [''],zipCode: [''],city: [''],street: ['']});

    this.productsApplicationService.getAllProducts.execute().then(products => {      
      this.products = products;
      console.log(products)
    });
  }

  public nextStep() {
    this.currentStep++;
    this.stepper.next();
  }
  public prevStep() {
    this.currentStep--;
    this.stepper.previous();
  }

  private initForm() {
    const group: any = {};
    this.questions.forEach(q => {
      group[q.questionCode] = [''];
    });
    this.answersForm = this.fb.group(group);
  }

  public selectProduct(product: ProductModel) {
    this.selectedProduct = product;
    this.selectedCovers = [];
    this.questions = product.questions || [];
    this.initForm();
    this.cdr.detectChanges();

    setTimeout(() => {
      if (this.coverList) {
        this.coverList.deselectAll();        
      }
    }, 0);

    this.nextStep();
  }

  public toggleCover(cover: CoverModel) {
    if (this.selectedCovers.includes(cover)) {
      this.selectedCovers = this.selectedCovers.filter(c => c !== cover);
    } else {
      this.selectedCovers = [...this.selectedCovers, cover];
    }
  }

  public submitOffer() {

    const command = this.getCalculatePriceCommand();
    this.offerApplicationService.calculatePrice.execute(command).then(calculatedPrice => {    
      this.calculatePrice = calculatedPrice;      
    });    
    
    this.nextStep();
  }

  public createPolicy() {    
    const command = this.getCreatePolicyCommand();
    this.policyApplicationService.createPolicy.execute(command).then((policy) => {
      this.policyResult = policy;
      this.summaryData = this.getSumaryData();      
      this.nextStep();
    }).catch(error => {
      console.error('Error creating policy: ', error);
      alert('Error creating policy: ' + error.message);
    });
  }

  public get coversNames(): string {
    return this.selectedCovers.map(c => c.name).join(', ');
  }

  public isCoverSelected(cover: CoverModel): boolean {
    return this.selectedCovers.some(c => c.code === cover.code);
  }

  public getCalculatePriceCommand(): CalculatePriceCommand {
    const answersArray: QuestionAnswerModel[] = this.questions.map(q => {
      const value = this.answersForm.value[q.questionCode];
      switch (q.questionType) {
        case 'Text':
          return new TextQuestionAnswerModel(q.questionCode, value);
        case 'Numeric':
          return new NumericQuestionAnswerModel(q.questionCode, value);
        case 'Choice':
          return new ChoiceQuestionAnswerModel(q.questionCode, value);
        default:
          throw new Error('Tipo de pregunta no soportado');
      }
    });

    const command = new CalculatePriceCommand(
      this.selectedProduct!.code,
      this.datesForm.value.policyFrom,
      this.datesForm.value.policyTo,
      this.selectedCovers.map(c => c.code),
      answersArray
    );

    return command;
  }

  public getCreatePolicyCommand(): CreatePolicyCommand{
    const offerNumber = this.calculatePrice?.offerNumber ?? '';
    
    const person = new PersonModel(
      this.holderForm.value.firstName,
      this.holderForm.value.lastName,
      this.holderForm.value.taxId
    );

    const address = new AddressModel(
      this.holderForm.value.country,
      this.holderForm.value.zipCode,
      this.holderForm.value.city,
      this.holderForm.value.street
    );

    const command = new CreatePolicyCommand(
      offerNumber,
      person,
      address
    );

    return command;
  }

  private getSumaryData() {
    const summaryData = {
      policyNumber: this.policyResult?.number,
      productCode: this.policyResult?.productCode,
      totalPremium: this.policyResult?.totalPremium,
      policyHolder: this.policyResult?.policyHolder,
      validFrom: this.policyResult?.dateFrom,
      validTo: this.policyResult?.dateTo,
      covers: this.policyResult?.covers,
      offerNumber: this.calculatePrice?.offerNumber,
      totalPrice: this.calculatePrice?.totalPrice      
    };

    return summaryData;
  }
  public restartWizard() {
    this.stepper.reset();
    this.currentStep = 0;
    this.selectedProduct = undefined;
    this.calculatePrice = undefined;
    this.policyResult = undefined;
    this.selectedCovers = [];
    this.questions = [];
    this.answersForm.reset();
    this.datesForm.reset();
    this.holderForm.reset();
  }
}
