namespace Easyfood.Application.Models.Partners
{
    public class PartnerDto
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyType { get; set; }
        public string PartnerLogo { get; set; }
        public decimal Score { get; set; }
        public DeliveryDto Delivery { get; set; }

        public PartnerDto(Guid id,
            string companyName,
            string companyType,
            string partnerLogo,
            DeliveryDto delivery,
            decimal score)
        {
            Id = id;
            CompanyName = companyName;
            CompanyType = companyType;
            PartnerLogo = partnerLogo;
            Delivery = delivery;
            Score = score;
        }
    }
}