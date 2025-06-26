import { Question } from "./question";

export class NumericQuestion extends Question {
  constructor(
    questionCode: string,
    index: number,
    text: string
  ) {
    super(questionCode, index, text);
  }
}
