using System;
using Project1.Utilites;

namespace Project1.Model
{
    //category information
    public class Category
    {
        
        public static string PATH = "Category.txt"; //The file to saving data


        private string id, categoryName;

        public Category(string id, string categoryName)
        {
            this.id = id;
            this.categoryName = categoryName;
        }

        public Category()
        {
        }

        public string Id
        {
            get => id;
            set => id = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string CategoryName
        {
            get => categoryName;
            set => categoryName = value ?? throw new ArgumentNullException(nameof(value));
        }


        public void Input() //Enter the information
        {
            id = new Random(1000).Next().ToString();
            Console.Write("Category Name: ");
            categoryName = Validation.InputString();
            Console.Clear();
        }

        
        public void Display()
        {
            Console.WriteLine("{0,-20}|{1,-20}", id, categoryName); //display information's object
        }

        public override string ToString()
        {
            return id + "#" + categoryName; //return the string, the information has splice "#"
        }
    }
}