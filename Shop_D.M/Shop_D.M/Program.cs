namespace Shop_D.M
{
    class Program
    {
        static List<Product> inventory = new List<Product>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Wybierz opcję:");
                Console.WriteLine("1. Dodaj produkt");
                Console.WriteLine("2. Usuń produkt");
                Console.WriteLine("3. Wyświetl listę produktów");
                Console.WriteLine("4. Aktualizuj produkt");
                Console.WriteLine("5. Oblicz wartość magazynu");
                Console.WriteLine("6. Wyjście");

                Console.Write("Twój wybór: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        RemoveProduct();
                        break;
                    case "3":
                        ShowProducts();
                        break;
                    case "4":
                        UpdateProduct();
                        break;
                    case "5":
                        CalculateInventoryValue();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Niepoprawna opcja, spróbuj ponownie.");
                        break;
                }
            }
        }

        static void AddProduct()
        {
            Console.Write("Podaj nazwę produktu: ");
            string name = Console.ReadLine();

            Console.Write("Podaj ilość: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Console.Write("Podaj cenę jednostkową: ");
            double price = Convert.ToDouble(Console.ReadLine());

            inventory.Add(new Product(name, quantity, price));
            Console.WriteLine("Produkt dodany!");
        }

        static void RemoveProduct()
        {
            Console.Write("Podaj nazwę produktu do usunięcia: ");
            string name = Console.ReadLine();

            Product productToRemove = inventory.Find(products => products.Name == name);

            if (productToRemove != null)
            {
                inventory.Remove(productToRemove);
                Console.WriteLine("Produkt usunięty!");
            }
            else
            {
                Console.WriteLine("Nie znaleziono produktu.");
            }
        }

        static void ShowProducts()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("Magazyn jest pusty.");
                return;
            }

            Console.WriteLine("Lista produktów:");
            foreach (var product in inventory)
            {
                Console.WriteLine(product);
            }
        }

        static void UpdateProduct()
        {
            Console.Write("Podaj nazwę produktu do aktualizacji: ");
            string name = Console.ReadLine();

            Product productToUpdate = inventory.Find(products => products.Name == name);

            if (productToUpdate != null)
            {
                Console.Write("Podaj nową ilość: ");
                productToUpdate.Quantity = Convert.ToInt32(Console.ReadLine());

                Console.Write("Podaj nową cenę jednostkową: ");
                productToUpdate.Price = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Produkt zaktualizowany!");
            }
            else
            {
                Console.WriteLine("Nie znaleziono produktu.");
            }
        }

        static void CalculateInventoryValue()
        {
            double totalValue = 0;
            foreach (var product in inventory)
            {
                totalValue += product.Quantity * product.Price;
            }

            Console.WriteLine("Łączna wartość magazynu: " + totalValue + " zł");
        }
    }
}

