import { AutoMap } from "@automapper/classes";
import { QuestionType } from "../../../enums/question-type";

export abstract class AnswerModel {
  @AutoMap()
  questionCode!: string;

  abstract get questionType(): QuestionType;
  abstract getAnswerValue(): unknown;
}

export abstract class AnswerModelGeneric<T> extends AnswerModel {
  @AutoMap()
  answerValue!: T;

  override getAnswerValue(): T {
    return this.answerValue;
  }
}
