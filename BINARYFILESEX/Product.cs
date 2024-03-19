namespace BINARYFILESEX
{
    internal class Product
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public Product(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Price: {Price:C}";
        }
    }

}

