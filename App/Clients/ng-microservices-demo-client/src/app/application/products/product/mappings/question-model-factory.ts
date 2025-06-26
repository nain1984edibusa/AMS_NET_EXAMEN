import { Choice } from "../../../../domain/products/entities/choice";
import { ChoiceQuestion } from "../../../../domain/products/entities/choice-question";
import { DateQuestion } from "../../../../domain/products/entities/date-question";
import { NumericQuestion } from "../../../../domain/products/entities/numeric-question";
import { Question } from "../../../../domain/products/entities/question";
import { ChoiceModel } from "../models/choice-model";
import { ChoiceQuestionModel } from "../models/choice-question-model";
import { DateQuestionModel } from "../models/date-question-model";
import { NumericQuestionModel } from "../models/numeric-question-model";
import { QuestionModel } from "../models/question-model";
import { productMapper } from "./product-mapper";

export function questionModelFactory(entity: Question): QuestionModel {
  if (entity instanceof ChoiceQuestion) {
    return new ChoiceQuestionModel(
      entity.questionCode,
      entity.index,
      entity.text,
      (entity.choices ?? []).map(choice => productMapper.map(choice, Choice, ChoiceModel))
    );
  }
  if (entity instanceof NumericQuestion) {
    return new NumericQuestionModel(
      entity.questionCode,
      entity.index,
      entity.text
    );
  }
  if (entity instanceof DateQuestion) {
    return new DateQuestionModel(
      entity.questionCode,
      entity.index,
      entity.text
    );
  }
  throw new Error('Unknown question entity type');
}
