import { QuestionType } from "../../../enums/question-type";
import { AnswerModel } from "../models/answer-model";
import { ChoiceAnswerModel } from "../models/choice-answer-model";
import { NumericAnswerModel } from "../models/numeric-answer-model";
import { QuestionAnswerModel } from "../models/question-answer-model";
import { TextAnswerModel } from "../models/text-answer-model";

export function resolveAnswerModel(ans: QuestionAnswerModel): new (...args: any[]) => AnswerModel {  
  switch (ans.questionType) {
    case QuestionType.Text:
      return TextAnswerModel;
    case QuestionType.Numeric:
      return NumericAnswerModel;
    case QuestionType.Choice:
      return ChoiceAnswerModel;
    default:
      throw new Error("Tipo de AnswerModel no soportado");
  }
}
