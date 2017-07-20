using System;
using System.Collections.Generic;
using System.Linq;

namespace BagOLoot
{
    public class Program

    {
        public static void Main(string[] args)
        {
            var db = new DatabaseInterface();
            db.Check();

            Console.WriteLine ("WELCOME TO THE BAG O' LOOT SYSTEM");
            Console.WriteLine ("*********************************");
            Console.WriteLine ("1. Add a child");
            Console.WriteLine ("2. Assign toy to a child");
			Console.Write ("> ");

			// Read in the user's choice
			int choice;
			Int32.TryParse (Console.ReadLine(), out choice);

            if (choice == 1)
            {
                Console.WriteLine ("Enter child name");
                Console.Write ("> ");
                string childName = Console.ReadLine();
                ChildRegister registry = new ChildRegister();
                bool childId = registry.AddChild(childName);
                Console.WriteLine(childId);
            }
            if (choice == 2)
            {
                Console.WriteLine ("To which child?");
                ChildRegister registry = new ChildRegister();
                SantaHelper helper = new SantaHelper();
                var children = registry.GetChildren();
                for (int i = 0; i < children.Count; i++)
                {
                    Console.WriteLine($"{i+1}. {children[i]}");
                }
                Console.Write ("> ");
                int childId = Int32.Parse(Console.ReadLine());
                string child = registry.GetChild(childId);
                Console.Write ($"What toy should {child} get?");
                string toyToAdd = Console.ReadLine();
                helper.AddToyToBag(toyToAdd, childId);
            }
            if (choice == 3)
            {
                Console.WriteLine ("From which child?");
                ChildRegister registry = new ChildRegister();
                var children = registry.GetChildren();
                for (int i = 0; i < children.Count; i++)
                {
                    Console.WriteLine($"{i+1}. {children[i]}");
                }
                Console.Write ("> ");
            }

        }
    }
}