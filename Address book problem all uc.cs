using System;
using System.Collections.Generic;

public class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}

public class AddressBook
{
    private List<Contact> contacts;

    public AddressBook()
    {
        contacts = new List<Contact>();
    }

    public void AddContact(Contact contact)
    {
        contacts.Add(contact);
        Console.WriteLine("Contact added successfully!");
    }

    public void EditContact(string firstName, string lastName)
    {
        Contact contact = FindContact(firstName, lastName);
        if (contact != null)
        {
            Console.WriteLine("Enter the updated details:");
            Console.Write("Address: ");
            contact.Address = Console.ReadLine();
            Console.Write("City: ");
            contact.City = Console.ReadLine();
            Console.Write("State: ");
            contact.State = Console.ReadLine();
            Console.Write("Zip: ");
            contact.Zip = Console.ReadLine();
            Console.Write("Phone Number: ");
            contact.PhoneNumber = Console.ReadLine();
            Console.Write("Email: ");
            contact.Email = Console.ReadLine();

            Console.WriteLine("Contact updated successfully!");
        }
        else
        {
            Console.WriteLine("Contact not found!");
        }
    }

    public void DeleteContact(string firstName, string lastName)
    {
        Contact contact = FindContact(firstName, lastName);
        if (contact != null)
        {
            contacts.Remove(contact);
            Console.WriteLine("Contact deleted successfully!");
        }
        else
        {
            Console.WriteLine("Contact not found!");
        }
    }

    private Contact FindContact(string firstName, string lastName)
    {
        return contacts.Find(contact =>
            contact.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
            contact.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
    }
}
public class AddressBookMain
{
    public static void Main(string[] args)
    {
        AddressBook addressBook = new AddressBook();

        while (true)
        {
            Console.WriteLine("\n==== Address Book ====");
            Console.WriteLine("1. Add a new contact");
            Console.WriteLine("2. Edit an existing contact");
            Console.WriteLine("3. Delete a contact");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        AddNewContact(addressBook);
                        break;
                    case 2:
                        EditContact(addressBook);
                        break;
                    case 3:
                        DeleteContact(addressBook);
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a number.");
            }
        }
    }

    private static void AddNewContact(AddressBook addressBook)
    {
        Console.WriteLine("\n==== Add New Contact ====");
        Console.Write("First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();
        Console.Write("Address: ");
        string address = Console.ReadLine();
        Console.Write("City: ");
        string city = Console.ReadLine();
        Console.Write("State: ");
        string state = Console.ReadLine();
        Console.Write("Zip: ");
        string zip = Console.ReadLine();
        Console.Write("Phone Number: ");
        string phoneNumber = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();

        Contact contact = new Contact
        {
            FirstName = firstName,
            LastName = lastName,
            Address = address,
            City = city,
            State = state,
            Zip = zip,
            PhoneNumber = phoneNumber,
            Email = email
        };

        addressBook.AddContact(contact);
    }

    private static void EditContact(AddressBook addressBook)
    {
        Console.WriteLine("\n==== Edit Contact ====");
        Console.Write("First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();

        addressBook.EditContact(firstName, lastName);
    }

    private static void DeleteContact(AddressBook addressBook)
    {
        Console.WriteLine("\n==== Delete Contact ====");
        Console.Write("First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();

        addressBook.DeleteContact(firstName, lastName);
    }
}
