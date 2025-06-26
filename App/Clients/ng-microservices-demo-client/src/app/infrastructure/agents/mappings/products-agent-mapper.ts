import { classes } from '@automapper/classes';
import { createMap, createMapper, forMember, mapFrom, Mapper } from '@automapper/core';
import { CoverDto } from '../../rest-clients/products/models/dtos/cover-dto';
import { ChoiceDto } from '../../rest-clients/products/models/dtos/choice-dto';
import { Cover } from '../../../domain/products/entities/cover';
import { Choice } from '../../../domain/products/entities/choice';
import { QuestionDto } from '../../rest-clients/products/models/dtos/question-dto';
import { Question } from '../../../domain/products/entities/question';
import { ProductResponse } from '../../rest-clients/products/models/response/products-response';
import { Product } from '../../../domain/products/entities/product';
import { questionEntityFactory } from './question-entity-factory';

export const productsAgentMapper: Mapper = createMapper({
  strategyInitializer: classes(),
});

createMap(productsAgentMapper, CoverDto, Cover);
createMap(productsAgentMapper, ChoiceDto, Choice);

createMap(productsAgentMapper, ProductResponse, Product,
  forMember((dest) => dest.covers, mapFrom((src) => src.covers.map(c => productsAgentMapper.map(c, CoverDto, Cover)) ?? [])),
  forMember((dest) => dest.questions, mapFrom((src) => src.questions.map(q => questionEntityFactory(q)) ?? []))
);
