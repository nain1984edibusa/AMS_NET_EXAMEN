import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { PolicyReportService } from '../../../service/policyReport.service';
import { PolicyReport } from '../../../interfaces/policyReport.interface';

@Component({
  selector: 'app-reports-list',
  standalone: true,
  imports: [CommonModule, MatTableModule],
  templateUrl: './reports-list.html',
  styleUrl: './reports-list.scss'
})
export class ReportsList {

  //displayedColumns: string[] = ['policyNumber', 'productCode', 'descripcionCode'];
  displayedColumns: string[] = ['policyNumber', 'productCode', 'descripcionCode', 'holderFirstName', 'holderLastName', 'holderStreet', 'holderCountry', 'holderCity', 'holderZipCode'];
  // dataSource = [
  //   { policyNumber: '0102030405', productCode: 'Bustillos Tapia', descripcionCode: 'Eduardo Andrés' },
  //   { policyNumber: '0607080910', productCode: 'Tapia Cueva', descripcionCode: 'Freddy Rolando' },
  //   { policyNumber: '1101121314', productCode: 'García León', descripcionCode: 'María Elena' }
  // ];

  dataSource: PolicyReport[] =[];

  constructor(private policyReportService: PolicyReportService) {
    this.listarPolicies();
  }
// 
listarPolicies() {
    debugger
    this.policyReportService.consultarPolicies().subscribe({
      next: (result) => {
        console.log('Método getBeneficioTributario', result);
        this.dataSource = result;
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

}
