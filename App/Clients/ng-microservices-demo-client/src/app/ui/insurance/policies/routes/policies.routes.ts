import { Routes } from "@angular/router";
import { PoliciesShell } from "../shell/layout/policies-shell";
import { OfferGenerationWizard } from "../pages/offer-generation-wizard/offer-generation-wizard";


export const POLICIES_ROUTES: Routes = [
  {
    path: '', component: PoliciesShell,
    children: [
      { path: '', component: OfferGenerationWizard }
    ]
  }
]
