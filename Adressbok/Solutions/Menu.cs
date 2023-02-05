using Adressbok.Interfaces;
using Adressbok.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Adressbok.Solutions
{
    public class Menu
    {
        public List<Contact> contacts = new List<Contact>();

        private FileService file = new FileService();
        public string FilePath { get; set; } = null!;

        public void WelcomeMenu()
        {
            PopulateContacts();
            GreetingMessages();


        }


        public void GreetingMessages()
        {
            string[] menuOptions = new string[] { "Create a contact\t\t", "View a contact\t\t", "View all contacts\t\t", "Delete a contact\t\t", "Exit the program\t\t" };
            //introducing the variable
            int menuSelect = 0;

            while (true)
            {
                Console.Clear();
                //fixing, so the arrow moves along menu options, choosing the one option
                Console.CursorVisible = false;

                if (menuSelect == 0)
                {
                    Console.WriteLine("** " + menuOptions[0] + "<--");
                    Console.WriteLine(menuOptions[1]);
                    Console.WriteLine(menuOptions[2]);
                    Console.WriteLine(menuOptions[3]);
                    Console.WriteLine(menuOptions[4]);

                }

                else if (menuSelect == 1)
                {
                    Console.WriteLine(menuOptions[0]);
                    Console.WriteLine("** " + menuOptions[1] + "<--");
                    Console.WriteLine(menuOptions[2]);
                    Console.WriteLine(menuOptions[3]);
                    Console.WriteLine(menuOptions[4]);

                }

                else if (menuSelect == 2)
                {
                    Console.WriteLine(menuOptions[0]);
                    Console.WriteLine(menuOptions[1]);
                    Console.WriteLine("** " + menuOptions[2] + "<--");
                    Console.WriteLine(menuOptions[3]);
                    Console.WriteLine(menuOptions[4]);
                }

                else if (menuSelect == 3)
                {
                    Console.WriteLine(menuOptions[0]);
                    Console.WriteLine(menuOptions[1]);
                    Console.WriteLine(menuOptions[2]);
                    Console.WriteLine("** " + menuOptions[3] + "<--");
                    Console.WriteLine(menuOptions[4]);
                }

                else if (menuSelect == 4)
                {
                    Console.WriteLine(menuOptions[0]);
                    Console.WriteLine(menuOptions[1]);
                    Console.WriteLine(menuOptions[2]);
                    Console.WriteLine(menuOptions[3]);
                    Console.WriteLine("** " + menuOptions[4] + "<--");
                }



                //fixing so the choice in menu is in the possible interval
                var keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.DownArrow && menuSelect != menuOptions.Length - 1)
                {
                    menuSelect++;
                }

                else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelect >= 1)
                {
                    menuSelect--;
                }

                else if (keyPressed.Key == ConsoleKey.Enter)
                {
                    switch (menuSelect)
                    {
                        case 0:
                            FirstChoice();
                            break;
                        case 1:
                            SecondChoice();
                            break;
                        case 2:
                            ThirdChoice();
                            break;
                        case 3:
                            FourthChoice();
                            break;
                        case 4:
                            FifthChoice();
                            break;
                    }


                }
            }
        }

        private void PopulateContacts()
        {
            try
            {
                var data = JsonConvert.DeserializeObject<List<Contact>>(file.Read(FilePath));
                if (data != null)

                    contacts = data;
                Console.WriteLine(data);

            }
            catch
            {
                Console.WriteLine("ERROR");
            }

        }

        

        private void FirstChoice()

        {

            {
                Contact contact = new Contact();

                Console.Clear();
                Console.WriteLine("Here you can create a contact!");
                Console.WriteLine("First name: ");
                contact.FirstName = Console.ReadLine() ?? "";
                Console.WriteLine("Last name: ");
                contact.LastName = Console.ReadLine() ?? "";
                Console.WriteLine("Phone number: ");
                contact.PhoneNumber = Console.ReadLine() ?? "";
                Console.WriteLine("Email address: ");
                contact.Email = Console.ReadLine() ?? "";

                contacts.Add(contact);
                file.Save(FilePath, JsonConvert.SerializeObject(contacts));

                Console.Clear();
                Console.WriteLine("You have created a contact named: " + $"{contact.FirstName} {contact.LastName}" + "\n" + "with a phone number: " + $"{contact.PhoneNumber}" + "\n" + "with a following email address: " + $"{contact.Email}");
                Console.WriteLine();
                Console.WriteLine("Press any button to go back to the menu");
                Console.ReadKey();

                
            }


        }

        private void SecondChoice()

        {

            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts with such name found.");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Name search phrase: ");
                var searchPhrase = Console.ReadLine();
                if (searchPhrase != null && searchPhrase != "")
                {
                    var matchingContacts = contacts.FindAll(c => c.FirstName.Contains(searchPhrase)).ToList();
                    if (searchPhrase != null)
                    {
                        Console.Clear();
                        foreach (var contact in matchingContacts)
                        {
                            Console.WriteLine($"Is this the contact you searched for? \n {contact.FirstName} {contact.LastName}, \n with following phone number: {contact.PhoneNumber}, \n and following email: {contact.Email} \n");
                      
                        }
                        Console.WriteLine("Push any button to get back to the menu");
                        Console.ReadKey();
                    } else
                    { 
                        Console.WriteLine("Error");
                        Console.ReadKey();
                    }
                    
                }
                else
                {

                }
            } 


            
        }

        private void ThirdChoice()

        {

            {
                Console.WriteLine("Now you can see all contacts: ");
                foreach(Contact contact in contacts)
                {
                    Console.WriteLine($"Contact-ID number: {contact.Id}");
                    Console.WriteLine(contact.FirstName);
                    Console.WriteLine(contact.LastName);
                    Console.WriteLine(contact.Email);
                    Console.WriteLine(contact.PhoneNumber);
                    Console.WriteLine("");
                }

               // Console.Clear();
                Console.WriteLine("You have accessed all contacts. Press any button to get back to the menu.");
                Console.ReadKey();

            }


        }

        private void FourthChoice()

        {

            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts with such name found.");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("´Remove a contact by phone number:  ");
                var removePhrase = Console.ReadLine();

                if (removePhrase != null && removePhrase != "")
                {
                    var removeOption = contacts.FirstOrDefault(c => c.PhoneNumber == removePhrase);

                    if (removeOption != null)
                    {
                        Console.Clear();
                        Console.WriteLine("Is this the contact you want yo remove?");
                        Console.WriteLine($"{removeOption.FirstName} {removeOption.LastName}");
                        Console.WriteLine($"With such email and phone number {removeOption.Email} {removeOption.PhoneNumber}");
                        Console.WriteLine("Write 'yes' to delete the contact");

                        var removeOne = Console.ReadLine();
                        string[] deleteOptions = new string[] { "Remove a contact\t\t", "Do not remove a contact\t\t" };
                        int menuChoose = 0;

                        switch (removeOne)
                        {
                            case "yes":
                                contacts.Remove(removeOption);
                                file.Save(FilePath, JsonConvert.SerializeObject(contacts));
                                Console.WriteLine("The contact was removed!");
                                Console.ReadKey();
                                break;
                        }
                    }

                    else
                    {
                        Console.WriteLine($"There is no such contact with given phone number: {removePhrase}, did you spell in correctly?");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Something went wrong, did you write in the phone number?");
                    Console.ReadKey();
                } 
            }
        }

        private void FifthChoice()

        {

            {
                Console.Clear();
                Console.WriteLine("You have chosen to exit the program.\n\n Hope you have found a needed contact!");
                Console.WriteLine("\n");
                Console.WriteLine("Press Enter to stop the program.");
                Console.ReadKey();
                //exiting the program
                Environment.Exit(1);
            }
        }
    }
}
