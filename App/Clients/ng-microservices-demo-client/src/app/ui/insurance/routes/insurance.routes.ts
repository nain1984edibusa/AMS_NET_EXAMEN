import { Routes } from '@angular/router';
import { InsuranceShell } from '../shell/layout/insurance-shell';
import { PaymentsList } from '../payments/pages/payments-list/payments-list';
import { ReportsList } from '../reports/pages/reports-list/reports-list';
import { authGuard } from '../../../framework/guards/auth-guard';

export const INSURANCE_ROUTES: Routes = [
  {
    path: '', component: InsuranceShell, canActivate: [authGuard],
    children: [
      { path: '', redirectTo: 'policies', pathMatch: 'full' },
      { path: 'policies', loadChildren: () => import('../policies/routes/policies.routes').then(m => m.POLICIES_ROUTES) },
      { path: 'payments', component: PaymentsList },
      { path: 'reports', component: ReportsList },
    ]
  }
]
