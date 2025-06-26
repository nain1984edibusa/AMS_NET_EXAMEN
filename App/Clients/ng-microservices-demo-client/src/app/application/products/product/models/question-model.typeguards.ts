import { ChoiceQuestionModel } from "./choice-question-model";
import { QuestionModel } from "./question-model";

export function isChoiceQuestionModel(
  question: QuestionModel
): question is ChoiceQuestionModel {
  return 'choices' in question && Array.isArray((question as any).choices);
}
