import { AutoMap } from '@automapper/classes';

export class CalculatedPrice {
  @AutoMap()
  public offerNumber: string;
  @AutoMap()
  public totalPrice: number;
  @AutoMap()
  public coversPrices: { [key: string]: number };

  constructor() {
    this.offerNumber = '';
    this.totalPrice = 0;
    this.coversPrices = {};
  }
}
