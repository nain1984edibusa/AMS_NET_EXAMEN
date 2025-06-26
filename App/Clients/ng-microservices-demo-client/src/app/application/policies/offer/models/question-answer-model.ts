import { AutoMap } from "@automapper/classes";
import { QuestionType } from "../../../enums/question-type";

export abstract class QuestionAnswerModel {
  @AutoMap()
  questionCode!: string;
  abstract get questionType(): QuestionType;
  abstract getAnswer(): unknown;
}

export abstract class QuestionAnswerModelGeneric<T> extends QuestionAnswerModel {
  @AutoMap()
  answer!: T;

  getAnswer(): T {
    return this.answer;
  }
}
