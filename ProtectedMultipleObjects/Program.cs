using System;

namespace ILOVEINHERITANCEALOT
{

    // base class
    class BaseClass
    {
        protected string _privateField1;
        protected string _privateField2;
        protected string _privateField3;

        public BaseClass()
        {
            _privateField1 = "prvfield1";
            _privateField2 = "prvfield2";
            _privateField3 = "prvfield3";
        }

        public BaseClass(string privateField1, string privateField2, string privateField3)
        {
            _privateField1 = privateField1;
            _privateField2 = privateField2;
            _privateField3 = privateField3;
        }

        // change method

        public virtual void changeInfo()
        {
            Console.WriteLine("Change PrivateField1 to : ");
            _privateField1 = Console.ReadLine();
            Console.WriteLine("Change PrivateField2 to : ");
            _privateField2 = Console.ReadLine();
            Console.WriteLine("Change PrivateField3 to : ");
            _privateField3 = Console.ReadLine();
        }

        // display info method

        public virtual void display()
        {
            Console.WriteLine("[ ! ] DISPLAYING DATA [ ! ]");
            Console.WriteLine($"PrivateField1 = {_privateField1}");
            Console.WriteLine($"PrivateField2 = {_privateField2}");
            Console.WriteLine($"PrivateField3 = {_privateField3}");
        }
    }

    // derived class

    class DerivedClass : BaseClass
    {
        protected string _newPrivateField1;
        protected string _newPrivateField2;

        public DerivedClass()
            : base()
        {
            _newPrivateField1 = "newprvfield1";
            _newPrivateField2 = "newprvfield2";
        }

        public DerivedClass(string privateField1, string privateField2, string privateField3, string newPrivateField1, string newPrivateField2)
            : base(privateField1, privateField2, privateField3)
        {
            _newPrivateField1 = newPrivateField1;
            _newPrivateField2 = newPrivateField2;
        }

        // override change

        public override void changeInfo()
        {
            base.changeInfo();
            Console.WriteLine("Change newPrivateField1 to : ");
            _newPrivateField1 = Console.ReadLine();
            Console.WriteLine("Change newPrivateField2 to : ");
            _newPrivateField2 = Console.ReadLine();
        }

        // display info method

        public override void display()
        {
            base.display();
            Console.WriteLine($"newPrivateField1 = {_newPrivateField1}");
            Console.WriteLine($"newPrivateField2 = {_newPrivateField2}");
        }
    }

    // main
    class Program
    {
        static void Main(string[] args)
        {
            int basenum = 0;
            int derivenum = 0;

            Console.WriteLine("How many of base class would you want?");
            basenum = int.Parse(Console.ReadLine());
            Console.WriteLine("How many of dervied class would you want?");
            derivenum = int.Parse(Console.ReadLine());

            BaseClass[] BaseList = new BaseClass[basenum];
            DerivedClass[] DerivedList = new DerivedClass[derivenum];

            // here comes the fun part (doesnt work)

            int choice, rec, type;
            int baseCounter = 0, dervCounter = 0;
            choice = Menu();


            while (choice != 4)
            {
                Console.WriteLine("Enter 1 for Derived or 2 for Base");
                while (!int.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("1 for Derived or 2 for Base");
                try
                {
                    switch (choice)
                    {
                        case 1: // Add
                            if (type == 1)
                            {
                                if (dervCounter <= derivenum)
                                {
                                    DerivedList[dervCounter] = new DerivedClass(); // places an object in the array instead of null
                                    DerivedList[dervCounter].changeInfo();
                                    dervCounter++;
                                }
                                else
                                    Console.WriteLine("Max has been added");

                            }
                            else
                            {
                                if (baseCounter <= basenum)
                                {
                                    BaseList[baseCounter] = new BaseClass(); // places an object in the array instead of null
                                    BaseList[baseCounter].changeInfo();
                                    baseCounter++;
                                }
                                else
                                    Console.WriteLine("Max has been added");
                            }

                            break;
                        case 2: //Change
                            Console.Write("Enter the record number you want to change: ");
                            while (!int.TryParse(Console.ReadLine(), out rec))
                                Console.Write("Enter the record number you want to change: ");
                            rec--;  // subtract 1 because array index begins at 0
                            if (type == 1) //Manager
                            {
                                while (rec > dervCounter - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                DerivedList[rec].changeInfo();
                            }
                            else // Employee
                            {
                                while (rec > baseCounter - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                BaseList[rec].changeInfo();
                            }
                            break;
                        case 3: // Print All
                            if (type == 1) //Manager
                            {
                                for (int i = 0; i < dervCounter; i++)
                                    DerivedList[i].display();
                            }
                            else // Employee
                            {
                                for (int i = 0; i < baseCounter; i++)
                                    BaseList[i].display();
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
                            break;
                    }
                }


                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                choice = Menu();

            }
        }


        private static int Menu()
        {
            Console.WriteLine("Please make a selection from the menu");
            Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            return selection;
        }
    }
}

