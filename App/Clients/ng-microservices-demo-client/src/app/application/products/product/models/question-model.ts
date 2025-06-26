import { QuestionType } from "../../../enums/question-type";

export abstract class QuestionModel {
  constructor(
    public questionCode: string,
    public index: number,
    public text: string
  ) { }
  abstract get questionType(): QuestionType;
}
