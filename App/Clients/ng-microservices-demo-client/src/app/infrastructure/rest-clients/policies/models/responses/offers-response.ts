import { AutoMap } from "@automapper/classes";

export class OfferResponse {
  @AutoMap()
  public offerNumber: string;
  @AutoMap()
  public totalPrice: number;
  @AutoMap()
  public coversPrices: { [key: string]: number };

  constructor(
    offerNumber: string = '',
    totalPrice: number = 0,
    coversPrices: { [key: string]: number } = {}
  ) {
    this.offerNumber = offerNumber;
    this.totalPrice = totalPrice;
    this.coversPrices = coversPrices;
  }

  static empty(): OfferResponse {
    return new OfferResponse();
  }
}
