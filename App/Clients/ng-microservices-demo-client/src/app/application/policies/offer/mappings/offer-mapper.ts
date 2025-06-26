import { classes } from "@automapper/classes";
import { createMap, createMapper, forMember, mapFrom, Mapper } from "@automapper/core";
import { CalculatePriceParamsModel } from "../models/calculate-price-params-model";
import { QuestionAnswerModel, QuestionAnswerModelGeneric } from "../models/question-answer-model";
import { AnswerModel, AnswerModelGeneric } from "../models/answer-model";
import { TextAnswerModel } from "../models/text-answer-model";
import { TextQuestionAnswerModel } from "../models/text-question-answer-model";
import { NumericQuestionAnswerModel } from "../models/numeric-question-answer-model";
import { ChoiceQuestionAnswerModel } from "../models/choice-question-answer-model";
import { ChoiceAnswerModel } from "../models/choice-answer-model";
import { NumericAnswerModel } from "../models/numeric-answer-model";
import { OfferModel } from "../models/offer-model";
import { CalculatedPrice } from "../../../../domain/policies/value-objects/calculated-price";
import { offersAgentMapper } from "../../../../infrastructure/agents/mappings/offers-agent-mapper";
import { resolveAnswerModel } from "./resolve-answer-model";
import { CalculatePriceCommand } from "../use-cases/commands/calculate-price/calculate-price-command";

export const offerMapper: Mapper = createMapper({
  strategyInitializer: classes(),
});


createMap(
  offerMapper,
  CalculatePriceCommand,
  CalculatePriceParamsModel,
  forMember(dest => dest.selectedCovers, mapFrom(src => src.selectedCovers)),
  forMember(
    dest => dest.answers,
    mapFrom(src => {      
      return Array.isArray(src.answers)
        ? src.answers.map(ans => {          
          return offerMapper.map(
            ans,
            Object.getPrototypeOf(ans).constructor,
            resolveAnswerModel(ans)
          );
        })
        : [];
    })
  )
);

createMap(offerMapper, TextQuestionAnswerModel, TextAnswerModel,
  forMember(dest => dest.answerValue, mapFrom(src => src.answer ? src.answer : ''))
);
createMap(offerMapper, NumericQuestionAnswerModel, NumericAnswerModel,
  forMember(dest => dest.answerValue, mapFrom(src => src.answer ? src.answer : 0))
);
createMap(offerMapper, ChoiceQuestionAnswerModel, ChoiceAnswerModel,
  forMember(dest => dest.answerValue, mapFrom(src => src.answer ? src.answer : []))
);

createMap(offerMapper, CalculatedPrice, OfferModel,
  forMember(dest => dest.coversPrices, mapFrom(src => src.coversPrices)),  
);
