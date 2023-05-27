using Easyfood.Domain.Entities.Customers;
using Easyfood.Domain.Entities.Owners;
using Easyfood.Domain.Entities.Partners;
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

            #region Tags

            var chineseTag = new Tag("Chinese");
            var brazilianTag = new Tag("Brazilian");
            var mexicanTag = new Tag("Mexican");
            var italianTag = new Tag("Italian");
            var japaneseTag = new Tag("Japanese");
            var pizzaTag = new Tag("Pizza");
            var burgerTag = new Tag("Burger");
            var healthyTag = new Tag("Healthy");
            var beerTag = new Tag("Beer");
            var fastFoodTag = new Tag("Fast Food");

            context.Set<Tag>().AddRange(chineseTag,
                brazilianTag,
                mexicanTag,
                italianTag,
                japaneseTag,
                pizzaTag,
                burgerTag,
                healthyTag,
                beerTag,
                fastFoodTag);

            #endregion Tags

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
            var address1 = new Address("Rua das Flores, 123", "Sorocaba", "SP", "18000-000", "Brasil", -23.519869, -47.464175);
            var partner1 = new Partner
            (
                "Padaria do José",
                "Padaria com produtos frescos.",
                "/merchants/1",
                CompanyType.Restaurant,
                address1,
                owner1.Id,
                5m
            );

            var menu1 = new Menu(partner1.Id);

            menu1.AddItem(new MenuItem("Leite", "Leite fresco.", "./static-images/leite.jpg", new Money(5.50m), menu1.Id));
            menu1.AddItem(new MenuItem("Margarina", "Margarina especial.", "./static-images/margarina.jpg", new Money(3.25m), menu1.Id));
            menu1.AddItem(new MenuItem("Manteiga", "Manteiga de primeira qualidade.", "./static-images/manteiga.jpg", new Money(10m), menu1.Id));
            menu1.AddItem(new MenuItem("Chocolate quente", "Leite com achocolatado.", "./static-images/leite-achocolatado.jpg", new Money(7.50m), menu1.Id));

            partner1.RegisterTag(healthyTag);

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
            var address2 = new Address("Rua Sete de Setembro, 210", "Sorocaba", "SP", "18000-010", "Brasil", -23.503448, -47.466241);
            var partner2 = new Partner
            (
                "Magic Food",
                "Restaurante especializado em comida japonesa.",
                "/merchants/2",
                CompanyType.Restaurant,
                address2,
                owner2.Id,
                4.3m
            );

            partner2.RegisterTag(japaneseTag);
            partner2.RegisterTag(chineseTag);
            partner2.RegisterTag(healthyTag);

            var menu2 = new Menu(partner2.Id);

            menu2.AddItem(new MenuItem("Temaki", "Unidade do Temaki.", "./static-images/temaki.jpg", new Money(23m), menu2.Id));
            menu2.AddItem(new MenuItem("Sushi", "Porção de sushi.", "./static-images/sushi.jpg", new Money(35m), menu2.Id));

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
            var address3 = new Address("Rua Abraham Lincoln, 700", "Sorocaba", "SP", "18000-020", "Brasil", -23.481222, -47.420883);
            var partner3 = new Partner
            (
                "Ligeirinho Pizza",
                "As melhores pizzarias da região.",
                "/merchants/4",
                CompanyType.Restaurant,
                address3,
                owner3.Id,
                3.9m
            );

            partner3.RegisterTag(pizzaTag);
            partner3.RegisterTag(fastFoodTag);
            partner3.RegisterTag(italianTag);

            var menu3 = new Menu(partner3.Id);

            menu3.AddItem(new MenuItem("Pizza Portuguesa", "Molho de tomate, mussarela, presunto, cebola, palmito, ervilha, ovo cozido, azeitona", "./static-images/pizza-portuguesa.jpg", new Money(55m), menu3.Id));
            menu3.AddItem(new MenuItem("Pizza Frango Catupiry", "Molho de tomate, frango desfiado, catupiry", "./static-images/pizza-frango-catupiry.jpg", new Money(75m), menu3.Id));
            menu3.AddItem(new MenuItem("Pizza Calebresa", "Molho de tomate, calabresa, cebola, mussarela", "./static-images/pizza-calabresa.jpg", new Money(45m), menu3.Id));

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
            var address4 = new Address("Rua Central, 50", "Sorocaba", "SP", "18000-030", "Brasil", -23.458141, -47.484642);
            var partner4 = new Partner
            (
                "Farmácia Balboa",
                "Remédios com desconto.",
                "/merchants/5",
                CompanyType.Pharmacy,
                address4,
                owner4.Id,
                4.7m
            );

            var menu4 = new Menu(partner4.Id);

            menu4.AddItem(new MenuItem("Anti-inflamatório", "Remédio Genérico.", "./static-images/ibuprofeno.jpg", new Money(10m), menu4.Id));
            menu4.AddItem(new MenuItem("Aspirina", "2 unidades.", "./static-images/aspirina.jpg", new Money(15m), menu4.Id));
            menu4.AddItem(new MenuItem("Xarope", "250ml.", "./static-images/xarope.jpg", new Money(30m), menu4.Id));

            context.Set<Owner>().Add(owner4);
            context.Set<Menu>().Add(menu4);
            context.Set<Partner>().Add(partner4);

            #endregion Partner 4

            #region Partner 5

            var owner5 = new Owner("Raul", "Seixas", Guid.NewGuid());
            var address5 = new Address("Rua do Futebol, 510", "Sorocaba", "SP", "18000-040", "Brasil", -23.534306, -47.465246);
            var partner5 = new Partner
            (
                "Super Market",
                "Super precinho.",
                "/merchants/6",
                CompanyType.Market,
                address5,
                owner5.Id,
                2.0m
            );

            var menu5 = new Menu(partner5.Id);

            menu5.AddItem(new MenuItem("Arroz", "5kg.", "./static-images/arroz.jpg", new Money(23m), menu5.Id));
            menu5.AddItem(new MenuItem("Feijão", "1kg.", "./static-images/feijao.jpg", new Money(10m), menu5.Id));
            menu5.AddItem(new MenuItem("Refrigerante", "Refrigerante gelado 2 Litros.", "./static-images/refrigerante.jpg", new Money(8m), menu5.Id));
            menu5.AddItem(new MenuItem("Nescau", "1kg.", "./static-images/nescau.jpg", new Money(15.50m), menu5.Id));

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
            var address6 = new Address("Rua do Graças, 11", "Sorocaba", "SP", "18000-050", "Brasil", -23.505549, -47.513748);
            var partner6 = new Partner
            (
                "Mamma Mia",
                "Culinária italiana.",
                "/merchants/7",
                CompanyType.Restaurant,
                address6,
                owner6.Id,
                5.0m
            );

            partner6.RegisterTag(italianTag);

            var menu6 = new Menu(partner6.Id);

            menu6.AddItem(new MenuItem("Macarrão à Bolonhesa", "Delícioso Macarrão.", "./static-images/macarrao-bolonhesa.jpg", new Money(30m), menu6.Id));
            menu6.AddItem(new MenuItem("Lasanha à Bolonhesa", "Deliciosa Lasanha.", "./static-images/lasanha-bolonhesa.jpg", new Money(45m), menu6.Id));
            menu6.AddItem(new MenuItem("Parmegiana", "Pargemiana de Filé Mignon com Arroz e Batatas fritas.", "./static-images/parmegiana.jpg", new Money(60m), menu6.Id));

            var reviewMerchant61 = new Review(partner3.Id, "Incrível.", 5m, customer1.Id);
            var reviewMerchant62 = new Review(partner3.Id, "Lamentável.", 1m, customer1.Id);

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