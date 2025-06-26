import { AutoMap } from "@automapper/classes";
import { QuestionType } from "../../../../../application/enums/question-type";
import { QuestionAnswerDtoGeneric } from "./question-answer-dto";

export class TextQuestionAnswerDto extends QuestionAnswerDtoGeneric<string> {
  @AutoMap()
  questionType: QuestionType = QuestionType.Numeric;  
}
