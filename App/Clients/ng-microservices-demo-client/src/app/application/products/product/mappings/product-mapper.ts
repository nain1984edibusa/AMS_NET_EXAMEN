import { classes } from "@automapper/classes";
import { createMap, createMapper, forMember, mapFrom, Mapper } from "@automapper/core";
import { questionModelFactory } from "./question-model-factory";
import { ChoiceModel } from "../models/choice-model";
import { ProductModel } from "../models/products-model";
import { Cover } from "../../../../domain/products/entities/cover";
import { CoverModel } from "../models/cover-model";
import { Choice } from "../../../../domain/products/entities/choice";
import { Product } from "../../../../domain/products/entities/product";

export const productMapper: Mapper = createMapper({
  strategyInitializer: classes(),
});

createMap(productMapper, Cover, CoverModel);
createMap(productMapper, Choice, ChoiceModel);

createMap(productMapper, Product, ProductModel,
  forMember((dest) => dest.covers, mapFrom((src) => (src.covers ?? []).map(c => productMapper.map(c, Cover, CoverModel)))),
  forMember((dest) => dest.questions, mapFrom((src) => (src.questions ?? []).map(q => questionModelFactory(q))))
);
