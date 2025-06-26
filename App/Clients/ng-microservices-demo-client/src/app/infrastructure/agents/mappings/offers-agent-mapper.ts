import { classes } from '@automapper/classes';
import { createMap, createMapper, forMember, mapFrom, Mapper } from '@automapper/core';
import { Offer } from '../../../domain/policies/entities/offer';
import { CalculatePriceParamsModel } from '../../../application/policies/offer/models/calculate-price-params-model';
import { QuestionAnswerDto } from '../../rest-clients/policies/models/dtos/question-answer-dto';
import { AnswerModel } from '../../../application/policies/offer/models/answer-model';
import { TextAnswerModel } from '../../../application/policies/offer/models/text-answer-model';
import { NumericAnswerModel } from '../../../application/policies/offer/models/numeric-answer-model';
import { ChoiceAnswerModel } from '../../../application/policies/offer/models/choice-answer-model';
import { TextQuestionAnswerDto } from '../../rest-clients/policies/models/dtos/text-question-answer-dto';
import { NumericQuestionAnswerDto } from '../../rest-clients/policies/models/dtos/numeric-question-answer-dto';
import { ChoiceQuestionAnswerDto } from '../../rest-clients/policies/models/dtos/choice-question-answer-dto';
import { CalculatePriceResponse } from '../../rest-clients/policies/models/responses/calculate-price-response';
import { CalculatedPrice } from '../../../domain/policies/value-objects/calculated-price';
import { CalculatePriceRequest } from '../../rest-clients/policies/models/requests/calculate-price-request';
import { resolveQuestionAnswerRequest } from './resolve-question-answer-request';
import { OfferResponse } from '../../rest-clients/policies/models/responses/offers-response';

export const offersAgentMapper: Mapper = createMapper({
  strategyInitializer: classes(),
});

createMap(offersAgentMapper, TextAnswerModel, TextQuestionAnswerDto,  
  forMember(dest => dest.answer, mapFrom(src => src.answerValue ? src.answerValue : ''))
);

createMap(offersAgentMapper, NumericAnswerModel, NumericQuestionAnswerDto,
  forMember(dest => dest.answer, mapFrom(src => src.answerValue ? src.answerValue : 0))
);
createMap(offersAgentMapper, ChoiceAnswerModel, ChoiceQuestionAnswerDto,
  forMember(dest => dest.answer, mapFrom(src => src.answerValue ? src.answerValue : '')),  
);

createMap(offersAgentMapper, CalculatePriceParamsModel, CalculatePriceRequest,
  forMember(dest => dest.selectedCovers, mapFrom(src => src.selectedCovers)),
  forMember(
    dest => dest.answers,
    mapFrom(src =>
      Array.isArray(src.answers)
        ? src.answers.map(ans =>          
          offersAgentMapper.map(
            ans,
            Object.getPrototypeOf(ans).constructor,
            resolveQuestionAnswerRequest(ans)
          )
        )
        : []
    )
  )
);

createMap(offersAgentMapper, CalculatePriceResponse, CalculatedPrice,
  forMember(dest => dest.coversPrices, mapFrom(src => src.coversPrices))
)
createMap(offersAgentMapper, OfferResponse, CalculatedPrice,
  forMember(dest => dest.coversPrices, mapFrom(src => src.coversPrices))
)
