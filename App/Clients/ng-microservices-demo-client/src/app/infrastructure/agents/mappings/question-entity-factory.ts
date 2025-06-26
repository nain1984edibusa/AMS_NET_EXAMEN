import { Choice } from "../../../domain/products/entities/choice";
import { ChoiceQuestion } from "../../../domain/products/entities/choice-question";
import { DateQuestion } from "../../../domain/products/entities/date-question";
import { NumericQuestion } from "../../../domain/products/entities/numeric-question";
import { Question } from "../../../domain/products/entities/question";
import { ChoiceDto } from "../../rest-clients/products/models/dtos/choice-dto";
import { QuestionDto } from "../../rest-clients/products/models/dtos/question-dto";
import { productsAgentMapper } from "./products-agent-mapper";

export function questionEntityFactory(dto: QuestionDto): Question {
  switch (dto.questionType) {
    case 'Choice':
      return new ChoiceQuestion(
        dto.questionCode,
        dto.index,
        dto.text,
        (dto.choices ?? []).map(ch => productsAgentMapper.map(ch, ChoiceDto, Choice))
      );
    case 'Numeric':
      return new NumericQuestion(dto.questionCode, dto.index, dto.text);
    case 'Date':
      return new DateQuestion(dto.questionCode, dto.index, dto.text);
    default:
      throw new Error(`Unknown question type: ${dto.questionType}`);
  }
}
