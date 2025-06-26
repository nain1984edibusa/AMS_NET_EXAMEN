namespace Microservices.Demo.Products.Service.Domain.Products.Entities
{
    public class ChoiceQuestion : Question
    {
        public ChoiceQuestion()
        {
        }

        public ChoiceQuestion(string code, int index, string text, List<Choice> choices) : base(code, index, text)
        {
            Choices = choices;
        }

        public List<Choice> Choices { get; set; }

        public static List<Choice> YesNoChoice()
        {
            return new List<Choice>
        {
            new("YES", "Yes"),
            new("NO", "No")
        };
        }
    }

}
