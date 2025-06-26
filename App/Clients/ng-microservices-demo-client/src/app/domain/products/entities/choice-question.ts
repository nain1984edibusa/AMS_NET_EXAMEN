import { AutoMap } from '@automapper/classes';
import { Choice } from './choice';
import { Question } from './question';

export class ChoiceQuestion extends Question {
  @AutoMap(() => [Choice])
  public choices: Choice[];

  constructor(
    questionCode: string,
    index: number,
    text: string,
    choices: Choice[]
  ) {
    super(questionCode, index, text);
    this.choices = choices;
  }
}
