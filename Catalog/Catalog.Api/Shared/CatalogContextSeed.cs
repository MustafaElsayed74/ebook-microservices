using Catalog.Api.Entities;
using MongoDB.Driver;

namespace Catalog.Api.Shared
{
    public static class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productsCollection)
        {

            var isProductsExist = productsCollection.Find(p => true).Any();
            if (!isProductsExist)
            {
                productsCollection.InsertManyAsync(GetPreConfigureProducts());
            }

        }

        private static IEnumerable<Product> GetPreConfigureProducts()
        {
            var products = new List<Product>
{
    new Product()
    {
        Id = "602c2149e773fa3990b47f79",
        Name = "HTC U11+",
        Summary = "This phone is the company's biggest change to its flagship smartphone in years.",
        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut, tenetur.",
        ImageFile = "product-1.png",
        Price = 380.00M,
        Category = "Smart Phone"
    },

    new Product()
    {
        Id = "602c2149e773fa3990b47f80",
        Name = "iPhone 16 Pro",
        Summary = "Apple's latest Pro smartphone with powerful performance and advanced cameras.",
        Description = "The iPhone 16 Pro features a premium design, powerful processor, advanced camera system, and stunning display.",
        ImageFile = "product-2.png",
        Price = 999.00M,
        Category = "Smart Phone"
    },

    new Product()
    {
        Id = "602c2149e773fa3990b47f81",
        Name = "Samsung Galaxy S25 Ultra",
        Summary = "A premium flagship smartphone with powerful performance and advanced AI features.",
        Description = "The Galaxy S25 Ultra offers a large AMOLED display, excellent cameras, powerful hardware, and a premium design.",
        ImageFile = "product-3.png",
        Price = 1199.00M,
        Category = "Smart Phone"
    },

    new Product()
    {
        Id = "602c2149e773fa3990b47f82",
        Name = "Google Pixel 9 Pro",
        Summary = "A premium Android phone with Google's powerful AI and camera technology.",
        Description = "The Pixel 9 Pro combines excellent photography, smart AI features, clean Android software, and premium hardware.",
        ImageFile = "product-4.png",
        Price = 999.00M,
        Category = "Smart Phone"
    },

    new Product()
    {
        Id = "602c2149e773fa3990b47f83",
        Name = "MacBook Pro M4",
        Summary = "A powerful laptop designed for developers, creators, and professionals.",
        Description = "The MacBook Pro delivers exceptional performance, long battery life, and a premium display for professional work.",
        ImageFile = "product-5.png",
        Price = 1599.00M,
        Category = "Laptop"
    },

    new Product()
    {
        Id = "602c2149e773fa3990b47f84",
        Name = "Dell XPS 15",
        Summary = "A premium Windows laptop with powerful hardware and a modern design.",
        Description = "The Dell XPS 15 features a high-quality display, powerful processor, dedicated graphics, and a sleek build.",
        ImageFile = "product-6.png",
        Price = 1499.00M,
        Category = "Laptop"
    },

    new Product()
    {
        Id = "602c2149e773fa3990b47f85",
        Name = "iPad Pro M4",
        Summary = "Apple's most powerful tablet with a stunning display and professional performance.",
        Description = "The iPad Pro combines the power of Apple's M4 chip with a thin design and advanced display technology.",
        ImageFile = "product-7.png",
        Price = 999.00M,
        Category = "Tablet"
    },

    new Product()
    {
        Id = "602c2149e773fa3990b47f86",
        Name = "Apple Watch Series 10",
        Summary = "A smart watch designed for health, fitness, and everyday productivity.",
        Description = "Apple Watch Series 10 offers fitness tracking, health monitoring, notifications, and seamless integration with Apple devices.",
        ImageFile = "product-8.png",
        Price = 399.00M,
        Category = "Smart Watch"
    },

    new Product()
    {
        Id = "602c2149e773fa3990b47f87",
        Name = "Sony WH-1000XM5",
        Summary = "Premium wireless headphones with powerful noise cancellation.",
        Description = "These headphones provide excellent sound quality, advanced noise cancellation, long battery life, and a comfortable design.",
        ImageFile = "product-9.png",
        Price = 399.00M,
        Category = "Headphones"
    },

    new Product()
    {
        Id = "602c2149e773fa3990b47f88",
        Name = "PlayStation 5",
        Summary = "A next-generation gaming console with powerful graphics and fast performance.",
        Description = "The PlayStation 5 delivers immersive gaming with ultra-fast loading, ray tracing, high frame rates, and the DualSense controller.",
        ImageFile = "product-10.png",
        Price = 499.00M,
        Category = "Gaming"
    }
};

            return products;
        }




    }
}
