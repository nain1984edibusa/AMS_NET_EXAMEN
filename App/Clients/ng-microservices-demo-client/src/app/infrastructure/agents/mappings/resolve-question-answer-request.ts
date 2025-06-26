import { QuestionType } from "../../../application/enums/question-type";
import { AnswerModel } from "../../../application/policies/offer/models/answer-model";
import { ChoiceQuestionAnswerDto } from "../../rest-clients/policies/models/dtos/choice-question-answer-dto";
import { NumericQuestionAnswerDto } from "../../rest-clients/policies/models/dtos/numeric-question-answer-dto";
import { TextQuestionAnswerDto } from "../../rest-clients/policies/models/dtos/text-question-answer-dto";

export function resolveQuestionAnswerRequest(ans: AnswerModel): any {
  switch (ans.questionType) {
    case QuestionType.Text: return TextQuestionAnswerDto;
    case QuestionType.Choice: return ChoiceQuestionAnswerDto;
    case QuestionType.Numeric: return NumericQuestionAnswerDto;
    default: throw new Error("Type not supported: " + ans.questionType);
  }
}
