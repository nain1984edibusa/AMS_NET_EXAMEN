import { AutoMap } from "@automapper/classes";
import { ChoiceModel } from "./choice-model";
import { QuestionModel } from "./question-model";
import { QuestionType } from "../../../enums/question-type";

export class ChoiceQuestionModel extends QuestionModel {
  @AutoMap()
  public choices: ChoiceModel[] = [];
  constructor(
    questionCode: string,
    index: number,
    text: string,
    choices: ChoiceModel[] = []
  ) {
    super(questionCode, index, text);
    this.choices = choices;
  }
  
  get questionType(): QuestionType {
    return QuestionType.Choice;
  }
}
