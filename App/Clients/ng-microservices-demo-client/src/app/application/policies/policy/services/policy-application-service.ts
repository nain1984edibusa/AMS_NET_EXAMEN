import { inject, Injectable } from "@angular/core";
import { CreatePolicyUseCase } from "../use-cases/commands/createPolicy/create-policy-use-case";

@Injectable({
  providedIn: 'root'
})
export class PolicyApplicationService {
  public createPolicy = inject(CreatePolicyUseCase);

}
