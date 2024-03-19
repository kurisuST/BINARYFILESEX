using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace BINARYFILESEX
{
    internal class Program
    {
        private const string fileName = "products.dat";

        static void Main(string[] args)
        {
            try
            {
                Product[] products = {
                new Product(1, "Laptop", 1200),
                new Product(2, "Smartphone", 800),
                new Product(3, "Tablet", 500)
            };

                SaveProducts(products);

                Product[] storedProducts = LoadProducts();
                Console.WriteLine("Stored products:");
                foreach (var product in storedProducts)
                {
                    Console.WriteLine(product);
                }

                int searchId = 2;
                Product foundProduct = FindProductById(searchId);
                if (foundProduct != null)
                {
                    Console.WriteLine($"\nProduct found for ID {searchId}:");
                    Console.WriteLine(foundProduct);
                }
                else
                {
                    Console.WriteLine($"\nNo product found for ID {searchId}.");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Product file not found.");
            }
            catch (SerializationException)
            {
                Console.WriteLine("Error reading or writing to product file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        static void SaveProducts(Product[] products)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, products);
            }
        }

        static Product[] LoadProducts()
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (Product[])formatter.Deserialize(fs);
            }
        }

        static Product FindProductById(int id)
        {
            Product[] products = LoadProducts();
            foreach (var product in products)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }
            return null;
        }
    }
}
