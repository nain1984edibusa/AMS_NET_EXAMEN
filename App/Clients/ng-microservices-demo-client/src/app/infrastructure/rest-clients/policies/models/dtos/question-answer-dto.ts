import { AutoMap } from "@automapper/classes";
import { QuestionType } from "../../../../../application/enums/question-type";

export abstract class QuestionAnswerDto {
  @AutoMap()
  questionCode!: string;

  abstract get questionType(): QuestionType;
  abstract getAnswer(): unknown;
}

export abstract class QuestionAnswerDtoGeneric<T> extends QuestionAnswerDto {
  @AutoMap()
  answer!: T;

  override getAnswer(): T {
    return this.answer;
  }
}
