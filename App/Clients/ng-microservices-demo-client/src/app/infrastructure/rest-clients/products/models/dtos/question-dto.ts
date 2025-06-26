import { AutoMap } from "@automapper/classes";
import { ChoiceDto } from "./choice-dto";
import { QuestionType } from "../../../../../application/enums/question-type";

export class QuestionDto {
  @AutoMap()
  public questionCode: string;

  @AutoMap()
  public index: number;

  @AutoMap()
  public questionType: QuestionType;

  @AutoMap()
  public text: string;

  // Solo decora si el tipo es concreto; si es polimórfico, mapea con factory
  @AutoMap(() => [ChoiceDto])
  public choices?: ChoiceDto[];

  constructor(
    questionCode: string,
    index: number,
    questionType: QuestionType,
    text: string,
    choices?: ChoiceDto[]
  ) {
    this.questionCode = questionCode;
    this.index = index;
    this.questionType = questionType;
    this.text = text;
    this.choices = choices;
  }
}
