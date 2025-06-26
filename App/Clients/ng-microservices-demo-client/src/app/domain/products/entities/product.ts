import { AutoMap } from '@automapper/classes';
import { Cover } from './cover';
import { Question } from './question';

export class Product {
  @AutoMap()
  public id: string;

  @AutoMap()
  public code: string;

  @AutoMap()
  public name: string;

  @AutoMap()
  public image: string;

  @AutoMap()
  public description: string;

  @AutoMap(() => [Cover])
  public covers: Cover[];
    
  public questions: Question[];

  @AutoMap()
  public maxNumberOfInsured: number;

  @AutoMap()
  public icon: string;

  constructor(
    id: string,
    code: string,
    name: string,
    image: string,
    description: string,
    covers: Cover[],
    questions: Question[],
    maxNumberOfInsured: number,
    icon: string
  ) {
    this.id = id;
    this.code = code;
    this.name = name;
    this.image = image;
    this.description = description;
    this.covers = covers;
    this.questions = questions;
    this.maxNumberOfInsured = maxNumberOfInsured;
    this.icon = icon;
  }

  hasCovers(): boolean {
    return this.covers && this.covers.length > 0;
  }
}
