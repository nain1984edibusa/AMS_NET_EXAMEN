import { Routes } from '@angular/router';


export const APP_ROUTES: Routes = [
  { path: '', redirectTo: 'insurance', pathMatch: 'full' },

  { path: 'insurance', loadChildren: () => import('../../insurance/routes/insurance.routes').then(r => r.INSURANCE_ROUTES) },
  //{ path: 'security', loadChildren: () => import('../../security/routes/security.routes').then(r => r.SECURITY_ROUTES) },


  //{ path: '**', component: PageNotFoundComponent }
];
