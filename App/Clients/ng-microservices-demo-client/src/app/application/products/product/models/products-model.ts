import { AutoMap } from '@automapper/classes';
import { CoverModel } from './cover-model';
import { QuestionModel } from './question-model';
// import { QuestionModel } from './question-model'; // si es clase abstracta, no decorar aquí

export class ProductModel {
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

  @AutoMap(() => [CoverModel])
  public covers: CoverModel[];

  // No usar @AutoMap para un array de clase abstracta como QuestionModel
  public questions: QuestionModel[];

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
    covers: CoverModel[],
    questions: QuestionModel[],
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
}
