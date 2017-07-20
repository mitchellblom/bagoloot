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
            db.CheckForChildTable();
            db.CheckForToyTable();

            Console.WriteLine ("WELCOME TO THE BAG O' LOOT SYSTEM");
            Console.WriteLine ("*********************************");
            Console.WriteLine ("1. Add a child");
            Console.WriteLine ("2. Assign toy to a child");
			Console.Write ("> ");

			// Read in the user's choice
			int choice;
			Int32.TryParse (Console.ReadLine(), out choice);

            ChildRegister registry = new ChildRegister();

            if (choice == 1)
            {
                Console.WriteLine ("Enter child name");
                Console.Write ("> ");
                string childName = Console.ReadLine();
                bool childId = registry.AddChild(childName);
                Console.WriteLine(childId);
            }
            if (choice == 2)
            {
                Console.WriteLine ("To which child?");
                SantaHelper helper = new SantaHelper();
                List<Child> children = registry.GetChildren();
                Console.WriteLine($"children.Count = {children.Count}");
                for (int i = 0; i < children.Count; i++)
                {
                    Console.WriteLine($"{i+1}. {children[i].name}");
                }
                Console.Write ("> ");
                int enteredKey = Int32.Parse(Console.ReadLine());
                Child chosenChild = children[enteredKey-1];
                Console.Write ($"What toy should {chosenChild.name} get?");
                string toyToAdd = Console.ReadLine();
                helper.AddToyToBag(toyToAdd, chosenChild.id);
            }
            if (choice == 3)
            {
                Console.WriteLine ("From which child?");
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