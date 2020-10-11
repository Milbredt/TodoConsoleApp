using System;
using System.Collections.Generic;

namespace TodoApp
{
    class Program
    {
        static void Main()
        {
            ToDoManager toDoManager = new ToDoManager();

            bool outerMenuLoop = true;

            do
            {
                int menuChoice = 0;

                int toDoListCount;

                bool middleMenuLoop = true;

                do
                {
                    bool innerMenuLoop = true;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Vad vill du göra?");
                        Console.WriteLine("[1] Lägga till ToDo.");
                        Console.WriteLine("[2] Uppdatera ToDo.");
                        Console.WriteLine("[3] Skriva ut ToDos.");
                        Console.WriteLine("[4] Ta bort ToDo.");
                        Console.WriteLine("[5] Avsluta.");
                        Console.Write("\nVal: ");

                        menuChoice = GetNumber();
                        if (menuChoice > 0 && menuChoice < 6)
                        {
                            innerMenuLoop = false;
                            middleMenuLoop = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Du kan endast välja ett tal mellan 1-5.");
                            Console.ReadKey();
                        }
                    } while (innerMenuLoop);

                } while (middleMenuLoop);

                switch (menuChoice)
                {
                    case 1: //Lägg till ToDo
                        string toDoName = GetString();
                        toDoManager.AddToDoItem(toDoName);
                        break;

                    case 2: //Uppdatera ToDo

                        toDoListCount = toDoManager.GetToDoListCount();

                        bool updateNumberLoop = true;

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Fyll i indextalet på den ToDo som är klar.");
                            Console.Write("Todo som är klar: ");
                            int doneToDo = GetNumber();

                            if (doneToDo > 0 && doneToDo <= toDoListCount)
                            {
                                toDoManager.SetToDoItemStatus(doneToDo);
                                updateNumberLoop = false;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Du kan endast välja ett tal mellan 1 och " + toDoListCount + ".");
                                Console.ReadKey();
                            }
                        } while (updateNumberLoop);
                        break;

                    case 3: //Skriv ut Todos
                        Console.Clear();
                        string print = toDoManager.PrintToDoList();
                        if (string.IsNullOrEmpty(print))
                        {
                            Console.WriteLine("Det finns inga ToDos i listan.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine(print);
                            Console.ReadKey();
                        }
                        break;

                    case 4: //Ta bort ToDo

                        toDoListCount = toDoManager.GetToDoListCount();

                        bool removeToDoItemLoop = true;

                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Fyll i indextalet på den ToDo du vill ta bort.");
                            Console.Write("Todo att ta bort: ");
                            int numberToRemove = GetNumber();

                            if (numberToRemove > 0 && numberToRemove <= toDoListCount)
                            {
                                toDoManager.RemoveToDoItem(numberToRemove);
                                removeToDoItemLoop = false;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Du kan endast välja ett tal mellan 1 och " + toDoListCount + ".");
                                Console.ReadKey();
                            }
                        } while (removeToDoItemLoop);
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Programmet avslutas.\n\n");
                        Environment.Exit(0);
                        break;
                }
            } while (outerMenuLoop);
        }

        //GetNumber
        private static int GetNumber()
        {
            int number = 0;

            bool numberLoop = true;

            do
            {
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                    numberLoop = false;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Du måste fylla i ett heltal");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("tal: ");
                }
            } while (numberLoop);
            return number;
        }

        private static string GetString()
        {
            string text = "";

            bool textLoop = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Vad ska din ToDo heta?");
                Console.Write("Namn på ToDo: ");

                text = Console.ReadLine();

                if (string.IsNullOrEmpty(text))
                {
                    Console.Clear();
                    Console.WriteLine("Du måste fylla i något.");
                    Console.ReadKey();
                }
                else
                {
                    textLoop = false;
                }
            } while (textLoop);

            return text;
        }
    }
}


