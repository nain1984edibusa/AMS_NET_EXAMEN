namespace Microservices.Demo.Reports.Service.Application.Dtos
{
    public class PolicyReportDto
    {
        public string PolicyNumber { get; set; }
        public string ProductCode { get; set; }
        public string DescripcionCode { get; set; }
        public string HolderFirstName { get; set; }
        public string HolderLastName { get; set; }
        public string HolderStreet { get; set; }
        public string HolderCountry { get; set; }
        public string HolderCity { get; set; }
        public string HolderZipCode { get; set; }
    }
}
