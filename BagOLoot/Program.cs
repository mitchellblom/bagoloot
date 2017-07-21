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
            Console.WriteLine ("3. Revoke toy from child");
            Console.WriteLine ("4. Review child's toy list");
            Console.WriteLine ("5. Child toy delivery complete");
            Console.WriteLine ("6. Yuletime Delivery Report");
			Console.Write ("> ");

			int choice;
			Int32.TryParse (Console.ReadLine(), out choice);

            ChildRegister registry = new ChildRegister();

            if (choice == 1)
            {
                Console.WriteLine ("Enter child name: ");
                Console.Write ("> ");
                string childName = Console.ReadLine();
                bool childId = registry.AddChild(childName);
                Console.WriteLine(childId);
            }
            if (choice == 2)
            {
                Console.WriteLine ("Assign toy to which child? ");
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
                Console.Write ($"Enter toy to add to {chosenChild.name}'s Bag o' Loot: ");
                string toyToAdd = Console.ReadLine();
                helper.AddToyToBag(toyToAdd, chosenChild.id);
            }
            if (choice == 3)
            {
                Console.WriteLine ("Remove toy from which child?");
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
                List<Toy>childsToys = helper.GetChildsToys(chosenChild.id);
                Console.WriteLine($"Which toy would you like to remove from {chosenChild.name}'s Bag o' Loot? ");
                for (int i = 0; i < childsToys.Count; i++)
                {
                    Console.WriteLine($"{i+1}. {childsToys[i].name}");
                }
                int enteredKey2 = Int32.Parse(Console.ReadLine());
                Toy toyToRemove = childsToys[enteredKey2-1];
                helper.RemoveToyFromBag(toyToRemove.id);
            }
        }
    }
}