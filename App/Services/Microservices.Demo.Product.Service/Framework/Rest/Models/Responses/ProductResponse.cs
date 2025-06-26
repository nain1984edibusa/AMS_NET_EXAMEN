using Microservices.Demo.Products.Service.Framework.Rest.Models.Dtos;

namespace Microservices.Demo.Products.Service.Framework.Rest.Models.Responses
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public IList<CoverDto> Covers { get; set; }
        public IList<QuestionDto> Questions { get; set; }
        public int MaxNumberOfInsured { get; set; }

        public string Icon { get; set; }
    }
}
