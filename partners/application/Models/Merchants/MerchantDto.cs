namespace Easyfood.Partners.Application.Models.Merchants
{
    public class MerchantDto
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyType { get; set; }
        public string MerchantLogo { get; set; }
        public DeliveryDto Delivery { get; set; }

        public MerchantDto(Guid id, string companyName, string companyType, string merchantLogo, DeliveryDto delivery)
        {
            Id = id;
            CompanyName = companyName;
            CompanyType = companyType;
            MerchantLogo = merchantLogo;
            Delivery = delivery;
        }
    }
}