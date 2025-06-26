import { Question } from "./question";

export class DateQuestion extends Question {
  constructor(
    questionCode: string,
    index: number,
    text: string
  ) {
    super(questionCode, index, text);
  }
}
