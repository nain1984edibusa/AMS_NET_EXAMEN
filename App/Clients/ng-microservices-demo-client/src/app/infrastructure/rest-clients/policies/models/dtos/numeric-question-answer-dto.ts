import { AutoMap } from "@automapper/classes";
import { QuestionType } from "../../../../../application/enums/question-type";
import { QuestionAnswerDtoGeneric } from "./question-answer-dto";

export class NumericQuestionAnswerDto extends QuestionAnswerDtoGeneric<number> {
  @AutoMap()
  questionType: QuestionType = QuestionType.Numeric;
}
