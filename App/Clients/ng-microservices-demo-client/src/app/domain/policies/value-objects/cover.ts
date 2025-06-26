import { AutoMap } from '@automapper/classes';

export class Cover {
  @AutoMap()
  public code: string;
  @AutoMap()
  public price: number;

  constructor(
    code: string,    
    price: number
  ) {
    this.code = code;
    this.price = price;
  }
}
