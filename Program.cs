using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject2
{    
    class Program
    {
        static int setPIN, amt = 10000, a, current, newAMT;
        static void Main(string[] args)
        {                        
            CreatePIN();
            
            string MyChoice = " ";
            
            do
            {
                Menu();
                MyChoice = Console.ReadLine();
                MyChoice = Procedures(MyChoice);

            } while (MyChoice == "0" || MyChoice == "1" || MyChoice == "2" || MyChoice == "3" || MyChoice == "4" || MyChoice == "5");
        }       
        public static void CreatePIN()
        {                        
            beginning:
            Console.Clear();            
            Console.Write("Please set a 4 digit PIN code: ");
            int PIN1 = int.Parse(Console.ReadLine());            
                if (PIN1 >= 1000 && PIN1 <= 9999)
                {
                    Console.WriteLine("");
                    Console.Write("Please reenter your 4 digit PIN code: ");
                    int PIN2 = int.Parse(Console.ReadLine());

                    if (PIN1 == PIN2)
                    {
                        StartTitle("Your PIN code has been successfully created. Please press a button to continue.");
                        Console.ReadKey();
                        beginning2:
                        Console.Clear();
                        Console.Write("Please enter your 4 digit PIN code: ");


                        if (PIN2 == int.Parse(Console.ReadLine()))
                        {
                        StartTitle("You successfully logged into your account. Please press a button to continue.");
                        setPIN = PIN2;
                        }
                        else
                        {
                            Console.WriteLine("");
                            EndTitle("Your PIN code is wrong. Please try again.");
                            goto beginning2;
                        }
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("");
                        EndTitle("Your PIN codes do not match. Please try again.");
                        goto beginning;
                    }
                }
                else
                {
                    Console.WriteLine("");
                    EndTitle("Your PIN code is not within the parameters. Please try again.");
                    goto beginning;
                }            
        }    
        static void Menu()
        {
            Console.Clear();
            MenuTitle("ATM SERVICE");
            Console.WriteLine("Please select the following options:");
            Console.WriteLine("");
            Console.WriteLine("[1] Withdraw money.");
            Console.WriteLine("[2] Deposit money.");
            Console.WriteLine("[3] Check your balance.");
            Console.WriteLine("[4] Change your password.");
            Console.WriteLine("[5] Cancel.");
            Console.WriteLine("");
            Console.Write("Your selection: ");            
           
        }
        static string Procedures(string MyChoice)
        {
            switch (MyChoice)
            {
                case "1":
                    Withdraw();
                    break;
                case "2":
                    Deposit();
                    break;
                case "3":
                    Balance();
                    break;
                case "4":
                    ChangePIN();
                    break;
                case "5":
                    MyChoice=Cancel();
                    break;

                default:
                    Menu();
                    MyChoice = "0";
                    break;
            }
            return MyChoice;
        }
        static void Withdraw()
        {            
            Console.Clear();            
            Console.Write("Enter the amount you want to withdraw: ");
            a = int.Parse(Console.ReadLine());
            if (amt >= a)
            {
                Console.Clear();
                Text("Please collect the cash: " + a);
                current = amt - a;
                newAMT = current;
                Text("Your current balance is: " + current);                
                Text("Please click a button to go back");                
                Console.ReadKey();
            }
            else
                EndTitle("Your account does not have sufficient balance. Click a button to go back.");
        }
        static void Deposit()
        {            
            Console.Clear();
            Console.Write("Please enter the amount to be deposited: ");            
            a = int.Parse(Console.ReadLine());
            current = amt + a;
            Text("Your current balance is " + current);            
            Text("Please click a button to go back.");
            Console.ReadKey();
        }
        static void Balance()
        {
            Console.Clear();
            if (newAMT==10000)
            {
                Console.WriteLine("Your current balance is: " + amt);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Your current balance is: " + newAMT);
                Console.ReadKey();
            }            
        }
        static void ChangePIN()
        {
            beginning0:
            Console.Clear();
            Console.Write("Please enter your current PIN code: ");
            int sPIN=int.Parse(Console.ReadLine());
            if(sPIN==setPIN)
            {            
                beginning:
                Console.Clear();
                Console.Write("Please set a new 4 digit PIN code: ");
                int PIN1 = int.Parse(Console.ReadLine());
                if (PIN1 >= 1000 && PIN1 <= 9999)
                {
                    Console.WriteLine("");
                    Console.Write("Please reenter your 4 digit PIN code: ");
                    int PIN2 = int.Parse(Console.ReadLine());
                
                    if (PIN1 == PIN2)
                    {
                        StartTitle("Your PIN code has been successfully created. Please press a button to continue.");
                        setPIN = PIN2;
                    }
                    else
                    {
                        Console.WriteLine("");
                        EndTitle("Your PIN codes do not match. Please try again.");
                        goto beginning;
                    }
                }
                else
                {
                    Console.WriteLine("");
                    EndTitle("Your PIN code is not within the parameters. Please try again.");
                    goto beginning;
                }
            }
            else
            {
                Console.Clear();
                EndTitle("Your current PIN is wrong. Please try again.");
                goto beginning0;
            }
            Console.ReadKey();
        }
        static string Cancel()
        {
            EndTitle("Thank you for using our service. Please press a button to cancel.");            
            return "6";            
        }
        static void EndTitle (string title)
        {
            Console.Clear();
            Console.WriteLine(title);
            for (int i = 0; i < title.Length; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine(string.Empty);
            Console.ReadKey();
        }
        static void StartTitle(string title)
        {
            Console.Clear();
            Console.WriteLine(title);
            for (int i = 0; i < title.Length; i++)
            {
                Console.Write("-");
            }            
        }
        static void MenuTitle(string title)
        {
            Console.Clear();
            Console.WriteLine("*******"+title+"*******");
            Console.WriteLine("");
        }
        static void Text (string title)
        {
            Console.WriteLine("");
            Console.WriteLine(title);            
        }        
    }
}
