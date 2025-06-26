export abstract class Question {
  constructor(
    public questionCode: string,
    public index: number,
    public text: string
  ) { }
}
