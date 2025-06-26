import { AutoMap } from "@automapper/classes";
import { PolicyHolder } from "../value-objects/policy-holder";
import { Cover } from "../value-objects/cover";

export class Policy {
  @AutoMap()
  public number: string;
  @AutoMap()
  public dateFrom: Date;
  @AutoMap()
  public dateTo: Date;
  @AutoMap()
  public holder: string;
  @AutoMap()
  public totalPremium: number;
  @AutoMap()
  public productCode: string;
  @AutoMap()
  public accountNumber: string;
  @AutoMap()
  public covers: Cover[];
  @AutoMap()
  public offerNumber: string;
  @AutoMap()
  public policyHolder: PolicyHolder;  

  constructor(
    number: string,
    dateFrom: Date,
    dateTo: Date,
    holder: string,
    totalPremium: number,
    productCode: string,
    accountNumber: string,
    covers: Cover[],
    offerNumber: string,
    policyHolder: PolicyHolder
  ) {
    this.number = number;
    this.dateFrom = dateFrom;
    this.dateTo = dateTo;
    this.holder = holder;
    this.totalPremium = totalPremium;
    this.productCode = productCode;
    this.accountNumber = accountNumber;
    this.covers = covers;
    this.offerNumber = offerNumber;
    this.policyHolder = policyHolder;
  }    
}
