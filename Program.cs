using System;
using System.Collections.Generic;

class LibraryManager
{
    static Dictionary<string, bool> library = new Dictionary<string, bool>();
    static int borrowedCount = 0;
    const int borrowLimit = 3;

    static void Main()
    {
        Console.WriteLine("Welcome to the Library Management System!");

        while (true)
        {
            Console.WriteLine("\nChoose an action: add / remove / search / borrow / return / list / exit");
            string action = Console.ReadLine().ToLower();

            switch (action)
            {
                case "add":
                    AddBook();
                    break;
                case "remove":
                    RemoveBook();
                    break;
                case "search":
                    SearchBook();
                    break;
                case "borrow":
                    BorrowBook();
                    break;
                case "return":
                    ReturnBook();
                    break;
                case "list":
                    ListBooks();
                    break;
                case "exit":
                    Console.WriteLine("Exiting the system. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid action. Please try again.");
                    break;
            }
        }
    }

    static void AddBook()
    {
        Console.Write("Enter the title to add: ");
        string title = Console.ReadLine();

        if (!library.ContainsKey(title))
        {
            library[title] = true;
            Console.WriteLine($"\"{title}\" has been added to the library.");
        }
        else
        {
            Console.WriteLine($"\"{title}\" already exists in the library.");
        }
    }

    static void RemoveBook()
    {
        Console.Write("Enter the title to remove: ");
        string title = Console.ReadLine();

        if (library.ContainsKey(title))
        {
            library.Remove(title);
            Console.WriteLine($"\"{title}\" has been removed from the library.");
        }
        else
        {
            Console.WriteLine($"\"{title}\" is not in the collection.");
        }
    }

    static void SearchBook()
    {
        Console.Write("Enter the title to search: ");
        string title = Console.ReadLine();

        if (library.ContainsKey(title))
        {
            string status = library[title] ? "available" : "borrowed";
            Console.WriteLine($"\"{title}\" is in the library and is currently {status}.");
        }
        else
        {
            Console.WriteLine($"\"{title}\" is not in the collection.");
        }
    }

    static void BorrowBook()
    {
        Console.Write("Enter the title to borrow: ");
        string title = Console.ReadLine();

        if (borrowedCount >= borrowLimit)
        {
            Console.WriteLine("You have reached the borrow limit (3 books).");
            return;
        }

        if (library.ContainsKey(title))
        {
            if (library[title])
            {
                library[title] = false;
                borrowedCount++;
                Console.WriteLine($"\"{title}\" has been borrowed.");
            }
            else
            {
                Console.WriteLine($"\"{title}\" is already borrowed.");
            }
        }
        else
        {
            Console.WriteLine($"\"{title}\" is not in the collection.");
        }
    }

    static void ReturnBook()
    {
        Console.Write("Enter the title to return: ");
        string title = Console.ReadLine();

        if (library.ContainsKey(title))
        {
            if (!library[title])
            {
                library[title] = true;
                borrowedCount--;
                Console.WriteLine($"\"{title}\" has been returned.");
            }
            else
            {
                Console.WriteLine($"\"{title}\" was not borrowed.");
            }
        }
        else
        {
            Console.WriteLine($"\"{title}\" is not in the collection.");
        }
    }

    static void ListBooks()
    {
        Console.WriteLine("\nBooks in the library:");
        foreach (var book in library)
        {
            string status = book.Value ? "Available" : "Borrowed";
            Console.WriteLine($"- {book.Key} ({status})");
        }
    }
}
