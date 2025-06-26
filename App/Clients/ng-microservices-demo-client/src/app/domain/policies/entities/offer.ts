import { AutoMap } from "@automapper/classes";
import { Cover } from "../value-objects/cover";

export class Offer {
  @AutoMap()
  public number: string;
  @AutoMap()
  public productCode: string;
  @AutoMap()
  public validFrom: Date;
  @AutoMap()
  public validTo: Date;
  @AutoMap()
  public totalPrice: number;
  @AutoMap()
  public covers: Cover[];

  constructor() {
    this.number = "";
    this.productCode = "";
    this.validFrom = new Date();
    this.validTo = new Date();
    this.totalPrice = 0;
    this.covers = [];
  }
}
