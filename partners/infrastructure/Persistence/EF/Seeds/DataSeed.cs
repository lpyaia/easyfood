using Easyfood.Partners.Domain.Entities;
using Easyfood.Partners.Domain.Enums;
using Easyfood.Partners.Domain.ValueObjects;

namespace Easyfood.Partners.Infrastructure.Persistence.EF.Seeds
{
    public static class DataSeed
    {
        public static async Task Seed(PartnersDbContext context)
        {
            if (context.Merchants.Any())
                return;

            #region Merchant 1

            var owner1 = new Owner("Lucas", "Pyaia", Guid.NewGuid());
            var menu1 = new Menu();

            menu1.AddItem(new MenuItem("Leite", "Leite fresco.", "", new Money(5.50m)));
            menu1.AddItem(new MenuItem("Margarina", "Margarina especial.", "", new Money(3.25m)));
            menu1.AddItem(new MenuItem("Manteiga", "Manteiga de primeira qualidade.", "", new Money(10m)));
            menu1.AddItem(new MenuItem("Chocolate quente", "Leite com achocolatado.", "", new Money(7.50m)));

            var address1 = new Address("Rua das Flores, 123", "Sorocaba", "SP", "18000-000", "Brasil", -23.519869, -47.464175);
            var merchant1 = new Merchant
            (
                "Padaria do José",
                "Padaria com produtos frescos.",
                "/merchants/1",
                CompanyType.Restaurant,
                menu1.Id,
                address1,
                owner1.Id
            );

            merchant1.RegisterTag(Tag.Restaurant);

            var reviewMerchant11 = new Review(merchant1.Id, "Restaurante muito bom.", 5m, "João");
            var reviewMerchant12 = new Review(merchant1.Id, "Restaurante muito ruim.", 1m, "Maria");
            var reviewMerchant13 = new Review(merchant1.Id, "Restaurante muito razoável.", 2.5m, "José");
            var reviewMerchant14 = new Review(merchant1.Id, "Restaurante muito bom.", 4.5m, "Augusto");

            context.Owners.Add(owner1);
            context.Menus.Add(menu1);
            context.Merchants.Add(merchant1);
            context.Reviews.AddRange
            (
                reviewMerchant11,
                reviewMerchant12,
                reviewMerchant13,
                reviewMerchant14
            );

            #endregion Merchant 1

            #region Merchant 2

            var owner2 = new Owner("Bruce", "Wayne", Guid.NewGuid());
            var menu2 = new Menu();

            menu2.AddItem(new MenuItem("Temaki", "Unidade do Temaki.", "", new Money(23m)));
            menu2.AddItem(new MenuItem("Sushi", "Porção de sushi.", "", new Money(35m)));

            var address2 = new Address("Rua Sete de Setembro, 210", "Sorocaba", "SP", "18000-010", "Brasil", -23.503448, -47.466241);
            var merchant2 = new Merchant
            (
                "Magic Food",
                "Restaurante especializado em comida japonesa.",
                "/merchants/2",
                CompanyType.Restaurant,
                menu2.Id,
                address2,
                owner2.Id
            );

            merchant2.RegisterTag(Tag.Restaurant);
            merchant2.RegisterTag(Tag.Japanese);
            merchant2.RegisterTag(Tag.Chinese);

            var reviewMerchant21 = new Review(merchant2.Id, "Restaurante muito legal.", 3m, "Gustavo");
            var reviewMerchant22 = new Review(merchant2.Id, "Restaurante lamentável.", 1m, "Maria");
            var reviewMerchant23 = new Review(merchant2.Id, "Restaurante muito razoável.", 2.5m, "José");
            var reviewMerchant24 = new Review(merchant2.Id, "Restaurante muito bom.", 4.5m, "Augusto");

            context.Owners.Add(owner2);
            context.Menus.Add(menu2);
            context.Merchants.Add(merchant2);
            context.Reviews.AddRange(
                reviewMerchant21,
                reviewMerchant22,
                reviewMerchant23,
                reviewMerchant24
            );

            #endregion Merchant 2

            #region Merchant 3

            var owner3 = new Owner("Mary", "Jane", Guid.NewGuid());
            var menu3 = new Menu();

            menu3.AddItem(new MenuItem("Pizza 8 pedaços", "Sabores variados.", "", new Money(55m)));
            menu3.AddItem(new MenuItem("Pizza 12 pedaços", "Sabores variados.", "", new Money(75m)));
            menu3.AddItem(new MenuItem("Pizza 6 pedaços", "Sabores variados.", "", new Money(45m)));

            var address3 = new Address("Rua Abraham Lincoln, 700", "Sorocaba", "SP", "18000-020", "Brasil", -23.481222, -47.420883);
            var merchant3 = new Merchant
            (
                "Ligeirinho Pizza",
                "As melhores pizzarias da região.",
                "/merchants/4",
                CompanyType.Restaurant,
                menu3.Id,
                address3,
                owner3.Id
            );

            merchant3.RegisterTag(Tag.Restaurant);
            merchant3.RegisterTag(Tag.Pizza);

            var reviewMerchant31 = new Review(merchant3.Id, "Pizzaria incrível.", 5m, "Gina");
            var reviewMerchant32 = new Review(merchant3.Id, "Lamentável.", 1m, "Maria");
            var reviewMerchant33 = new Review(merchant3.Id, "Show de horrores.", 2.5m, "José");

            context.Owners.Add(owner3);
            context.Menus.Add(menu3);
            context.Merchants.Add(merchant3);
            context.Reviews.AddRange(
                reviewMerchant31,
                reviewMerchant32,
                reviewMerchant33
            );

            #endregion Merchant 3

            #region Merchant 4

            var owner4 = new Owner("Rocky", "Balboa", Guid.NewGuid());
            var menu4 = new Menu();

            menu4.AddItem(new MenuItem("Anti-inflamatório", "Remédio Genérico.", "", new Money(10m)));
            menu4.AddItem(new MenuItem("Aspirina", "2 unidades.", "", new Money(15m)));
            menu4.AddItem(new MenuItem("Xarope", "250ml.", "", new Money(30m)));

            var address4 = new Address("Rua Central, 50", "Sorocaba", "SP", "18000-030", "Brasil", -23.458141, -47.484642);
            var merchant4 = new Merchant
            (
                "Farmácia Balboa",
                "Remédios com desconto.",
                "/merchants/5",
                CompanyType.Pharmacy,
                menu4.Id,
                address4,
                owner4.Id
            );

            merchant4.RegisterTag(Tag.Pharmacy);

            context.Owners.Add(owner4);
            context.Menus.Add(menu4);
            context.Merchants.Add(merchant4);

            #endregion Merchant 4

            #region Merchant 5

            var owner5 = new Owner("Raul", "Seixas", Guid.NewGuid());
            var menu5 = new Menu();

            menu5.AddItem(new MenuItem("Arroz", "5kg.", "", new Money(23m)));
            menu5.AddItem(new MenuItem("Feijão", "1kg.", "", new Money(10m)));
            menu5.AddItem(new MenuItem("Refrigerante", "Refrigerante gelado 2 Litros.", "", new Money(8m)));
            menu5.AddItem(new MenuItem("Nescau", "1kg.", "", new Money(15.50m)));

            var address5 = new Address("Rua do Futebol, 510", "Sorocaba", "SP", "18000-040", "Brasil", -23.534306, -47.465246);
            var merchant5 = new Merchant
            (
                "Super Market",
                "Super precinho.",
                "/merchants/6",
                CompanyType.Market,
                menu5.Id,
                address5,
                owner5.Id
            );

            merchant5.RegisterTag(Tag.Market);

            var reviewMerchant51 = new Review(merchant5.Id, "Tudo caro.", 5m, "Joana");

            context.Owners.Add(owner5);
            context.Menus.Add(menu5);
            context.Merchants.Add(merchant5);
            context.Reviews.AddRange(
                reviewMerchant51
            );

            #endregion Merchant 5

            #region Merchant 6

            var owner6 = new Owner("Raul", "Seixas", Guid.NewGuid());
            var menu6 = new Menu();

            menu6.AddItem(new MenuItem("Macarrão à Bolonhesa", "Delícioso Macarrão.", "", new Money(30m)));
            menu6.AddItem(new MenuItem("Lasanha à Bolonhesa", "Deliciosa Lasanha.", "", new Money(45m)));
            menu6.AddItem(new MenuItem("Parmegiana", "Pargemiana de Filé Mignon com Arroz e Batatas fritas.", "", new Money(60m)));

            var address6 = new Address("Rua do Graças, 11", "Sorocaba", "SP", "18000-050", "Brasil", -23.505549, -47.513748);
            var merchant6 = new Merchant
            (
                "Mamma Mia",
                "Culinária italiana.",
                "/merchants/7",
                CompanyType.Restaurant,
                menu6.Id,
                address6,
                owner6.Id
            );

            var reviewMerchant61 = new Review(merchant3.Id, "Incrível.", 5m, "Gi");
            var reviewMerchant62 = new Review(merchant3.Id, "Lamentável.", 1m, "Maria");

            merchant6.RegisterTag(Tag.Italian);
            merchant6.RegisterTag(Tag.Restaurant);

            context.Owners.Add(owner6);
            context.Menus.Add(menu6);
            context.Merchants.Add(merchant6);
            context.Reviews.AddRange(
                reviewMerchant61,
                reviewMerchant62
            );

            #endregion Merchant 6

            await context.SaveChangesAsync();
        }
    }
}