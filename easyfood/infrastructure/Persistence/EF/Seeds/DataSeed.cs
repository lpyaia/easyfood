using Easyfood.Domain.Entities;
using Easyfood.Domain.Enums;
using Easyfood.Domain.ValueObjects;

namespace Easyfood.Infrastructure.Persistence.EF.Seeds
{
    public static class DataSeed
    {
        public static async Task Seed(EasyfoodDbContext context)
        {
            if (context.Set<Partner>().Any())
                return;

            #region Customers

            var customer1 = new Customer(
                new Guid("483692e9-2af6-4fb9-9af6-3d562cdde43e"),
                "John",
                "Doe",
                "john.doe@yahoo.com",
                "john.doe",
                new DateTime(1990, 01, 23));

            context.Set<Customer>().Add(customer1);

            #endregion Customers

            #region Partner 1

            var owner1 = new Owner("Lucas", "Pyaia", Guid.NewGuid());
            var menu1 = new Menu();

            menu1.AddItem(new MenuItem("Leite", "Leite fresco.", "", new Money(5.50m)));
            menu1.AddItem(new MenuItem("Margarina", "Margarina especial.", "", new Money(3.25m)));
            menu1.AddItem(new MenuItem("Manteiga", "Manteiga de primeira qualidade.", "", new Money(10m)));
            menu1.AddItem(new MenuItem("Chocolate quente", "Leite com achocolatado.", "", new Money(7.50m)));

            var address1 = new Address("Rua das Flores, 123", "Sorocaba", "SP", "18000-000", "Brasil", -23.519869, -47.464175);
            var partner1 = new Partner
            (
                "Padaria do José",
                "Padaria com produtos frescos.",
                "/merchants/1",
                CompanyType.Restaurant,
                menu1.Id,
                address1,
                owner1.Id,
                5m
            );

            partner1.RegisterTag(Tag.Restaurant);

            var reviewMerchant11 = new Review(partner1.Id, "Restaurante muito bom.", 5m, customer1.Id);
            var reviewMerchant12 = new Review(partner1.Id, "Restaurante muito ruim.", 1m, customer1.Id);
            var reviewMerchant13 = new Review(partner1.Id, "Restaurante muito razoável.", 2.5m, customer1.Id);
            var reviewMerchant14 = new Review(partner1.Id, "Restaurante muito bom.", 4.5m, customer1.Id);

            context.Set<Owner>().Add(owner1);
            context.Set<Menu>().Add(menu1);
            context.Set<Partner>().Add(partner1);
            context.Set<Review>().AddRange
            (
                reviewMerchant11,
                reviewMerchant12,
                reviewMerchant13,
                reviewMerchant14
            );

            #endregion Partner 1

            #region Partner 2

            var owner2 = new Owner("Bruce", "Wayne", Guid.NewGuid());
            var menu2 = new Menu();

            menu2.AddItem(new MenuItem("Temaki", "Unidade do Temaki.", "", new Money(23m)));
            menu2.AddItem(new MenuItem("Sushi", "Porção de sushi.", "", new Money(35m)));

            var address2 = new Address("Rua Sete de Setembro, 210", "Sorocaba", "SP", "18000-010", "Brasil", -23.503448, -47.466241);
            var partner2 = new Partner
            (
                "Magic Food",
                "Restaurante especializado em comida japonesa.",
                "/merchants/2",
                CompanyType.Restaurant,
                menu2.Id,
                address2,
                owner2.Id,
                4.3m
            );

            partner2.RegisterTag(Tag.Restaurant);
            partner2.RegisterTag(Tag.Japanese);
            partner2.RegisterTag(Tag.Chinese);

            var reviewMerchant21 = new Review(partner2.Id, "Restaurante muito legal.", 3m, customer1.Id);
            var reviewMerchant22 = new Review(partner2.Id, "Restaurante lamentável.", 1m, customer1.Id);
            var reviewMerchant23 = new Review(partner2.Id, "Restaurante muito razoável.", 2.5m, customer1.Id);
            var reviewMerchant24 = new Review(partner2.Id, "Restaurante muito bom.", 4.5m, customer1.Id);

            context.Set<Owner>().Add(owner2);
            context.Set<Menu>().Add(menu2);
            context.Set<Partner>().Add(partner2);
            context.Set<Review>().AddRange(
                reviewMerchant21,
                reviewMerchant22,
                reviewMerchant23,
                reviewMerchant24
            );

            #endregion Partner 2

            #region Partner 3

            var owner3 = new Owner("Mary", "Jane", Guid.NewGuid());
            var menu3 = new Menu();

            menu3.AddItem(new MenuItem("Pizza 8 pedaços", "Sabores variados.", "", new Money(55m)));
            menu3.AddItem(new MenuItem("Pizza 12 pedaços", "Sabores variados.", "", new Money(75m)));
            menu3.AddItem(new MenuItem("Pizza 6 pedaços", "Sabores variados.", "", new Money(45m)));

            var address3 = new Address("Rua Abraham Lincoln, 700", "Sorocaba", "SP", "18000-020", "Brasil", -23.481222, -47.420883);
            var partner3 = new Partner
            (
                "Ligeirinho Pizza",
                "As melhores pizzarias da região.",
                "/merchants/4",
                CompanyType.Restaurant,
                menu3.Id,
                address3,
                owner3.Id,
                3.9m
            );

            partner3.RegisterTag(Tag.Restaurant);
            partner3.RegisterTag(Tag.Pizza);

            var reviewMerchant31 = new Review(partner3.Id, "Pizzaria incrível.", 5m, customer1.Id);
            var reviewMerchant32 = new Review(partner3.Id, "Lamentável.", 1m, customer1.Id);
            var reviewMerchant33 = new Review(partner3.Id, "Show de horrores.", 2.5m, customer1.Id);

            context.Set<Owner>().Add(owner3);
            context.Set<Menu>().Add(menu3);
            context.Set<Partner>().Add(partner3);
            context.Set<Review>().AddRange(
                reviewMerchant31,
                reviewMerchant32,
                reviewMerchant33
            );

            #endregion Partner 3

            #region Partner 4

            var owner4 = new Owner("Rocky", "Balboa", Guid.NewGuid());
            var menu4 = new Menu();

            menu4.AddItem(new MenuItem("Anti-inflamatório", "Remédio Genérico.", "", new Money(10m)));
            menu4.AddItem(new MenuItem("Aspirina", "2 unidades.", "", new Money(15m)));
            menu4.AddItem(new MenuItem("Xarope", "250ml.", "", new Money(30m)));

            var address4 = new Address("Rua Central, 50", "Sorocaba", "SP", "18000-030", "Brasil", -23.458141, -47.484642);
            var partner4 = new Partner
            (
                "Farmácia Balboa",
                "Remédios com desconto.",
                "/merchants/5",
                CompanyType.Pharmacy,
                menu4.Id,
                address4,
                owner4.Id,
                4.7m
            );

            partner4.RegisterTag(Tag.Pharmacy);

            context.Set<Owner>().Add(owner4);
            context.Set<Menu>().Add(menu4);
            context.Set<Partner>().Add(partner4);

            #endregion Partner 4

            #region Partner 5

            var owner5 = new Owner("Raul", "Seixas", Guid.NewGuid());
            var menu5 = new Menu();

            menu5.AddItem(new MenuItem("Arroz", "5kg.", "", new Money(23m)));
            menu5.AddItem(new MenuItem("Feijão", "1kg.", "", new Money(10m)));
            menu5.AddItem(new MenuItem("Refrigerante", "Refrigerante gelado 2 Litros.", "", new Money(8m)));
            menu5.AddItem(new MenuItem("Nescau", "1kg.", "", new Money(15.50m)));

            var address5 = new Address("Rua do Futebol, 510", "Sorocaba", "SP", "18000-040", "Brasil", -23.534306, -47.465246);
            var partner5 = new Partner
            (
                "Super Market",
                "Super precinho.",
                "/merchants/6",
                CompanyType.Market,
                menu5.Id,
                address5,
                owner5.Id,
                2.0m
            );

            partner5.RegisterTag(Tag.Market);

            var reviewMerchant51 = new Review(partner5.Id, "Tudo caro.", 5m, customer1.Id);

            context.Set<Owner>().Add(owner5);
            context.Set<Menu>().Add(menu5);
            context.Set<Partner>().Add(partner5);
            context.Set<Review>().AddRange(
                reviewMerchant51
            );

            #endregion Partner 5

            #region Partner 6

            var owner6 = new Owner("Raul", "Seixas", Guid.NewGuid());
            var menu6 = new Menu();

            menu6.AddItem(new MenuItem("Macarrão à Bolonhesa", "Delícioso Macarrão.", "", new Money(30m)));
            menu6.AddItem(new MenuItem("Lasanha à Bolonhesa", "Deliciosa Lasanha.", "", new Money(45m)));
            menu6.AddItem(new MenuItem("Parmegiana", "Pargemiana de Filé Mignon com Arroz e Batatas fritas.", "", new Money(60m)));

            var address6 = new Address("Rua do Graças, 11", "Sorocaba", "SP", "18000-050", "Brasil", -23.505549, -47.513748);
            var partner6 = new Partner
            (
                "Mamma Mia",
                "Culinária italiana.",
                "/merchants/7",
                CompanyType.Restaurant,
                menu6.Id,
                address6,
                owner6.Id,
                5.0m
            );

            var reviewMerchant61 = new Review(partner3.Id, "Incrível.", 5m, customer1.Id);
            var reviewMerchant62 = new Review(partner3.Id, "Lamentável.", 1m, customer1.Id);

            partner6.RegisterTag(Tag.Italian);
            partner6.RegisterTag(Tag.Restaurant);

            context.Set<Owner>().Add(owner6);
            context.Set<Menu>().Add(menu6);
            context.Set<Partner>().Add(partner6);
            context.Set<Review>().AddRange(
                reviewMerchant61,
                reviewMerchant62
            );

            #endregion Partner 6

            await context.SaveChangesAsync();
        }
    }
}