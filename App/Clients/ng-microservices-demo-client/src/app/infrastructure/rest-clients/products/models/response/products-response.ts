import { AutoMap } from "@automapper/classes";
import { CoverDto } from "../dtos/cover-dto";
import { QuestionDto } from "../dtos/question-dto";


export class ProductResponse {
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

  @AutoMap(() => [CoverDto])
  public covers: CoverDto[];

  @AutoMap(() => [QuestionDto])
  public questions: QuestionDto[];

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
    covers: CoverDto[],
    questions: QuestionDto[],
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
