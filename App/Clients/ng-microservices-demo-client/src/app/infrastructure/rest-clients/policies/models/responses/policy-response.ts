import { AutoMap } from "@automapper/classes";

export class PolicyResponse {
  @AutoMap()
  public number: string;
  @AutoMap()
  public dateFrom: Date;
  @AutoMap()
  public dateTo: Date;
  @AutoMap()
  public policyHolder: string;
  @AutoMap()
  public totalPremium: number;
  @AutoMap()
  public productCode: string;
  @AutoMap()
  public accountNumber: string;
  @AutoMap()
  public covers: string[];

  constructor(
    number: string,
    dateFrom: Date,
    dateTo: Date,
    policyHolder: string,
    totalPremium: number,
    productCode: string,
    accountNumber: string,
    covers: string[]
  ) {
    this.number = number;
    this.dateFrom = dateFrom;
    this.dateTo = dateTo;
    this.policyHolder = policyHolder;
    this.totalPremium = totalPremium;
    this.productCode = productCode;
    this.accountNumber = accountNumber;
    this.covers = covers;
  }
}
