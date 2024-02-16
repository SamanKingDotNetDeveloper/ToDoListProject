using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListProject
{
    internal class CreateAccount
    {
        public void CreateAUAccount()
        {
            string AdminPathAndUser = "D:/NewProjects/ToDoListProject/ToDoListProject/bin/UsersAndAdmins";
            Point:
            Console.Write("Sign up\nBack[Back]\nUsername: ");
            string Username = Console.ReadLine(), Password = "";
            if(Username.ToLower() == "back")
            {
                Console.Clear();
                return;
            }
            bool Exist = File.Exists($"{AdminPathAndUser}/{Username}.txt");
            if (Exist)
            {
                Console.WriteLine("This Username is already taken");
                Thread.Sleep(2500);
                Console.Clear();
                goto Point;
            }
            else
            {
                Console.Write("Password: ");
                Password = Console.ReadLine();
                Console.Write("Role [Admin] [User]: ");
                string Role = Console.ReadLine().ToLower();
                if(Role == "admin")
                {
                    Console.Write("Enter password to create Admin account: ");
                    string password = Console.ReadLine();
                    if (password == "AdminCreationPassIs0197")
                    {
                        File.Create($"{AdminPathAndUser}/{Username}.txt").Close();
                        File.WriteAllText($"{AdminPathAndUser}/{Username}.txt", $"{Username} {Password} {Role.ToUpper()}");
                        Console.WriteLine("Account created succesfully");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Password is incorrect!!!");
                        Thread.Sleep(2500);
                        Console.Clear();
                        goto Point;
                    }
                }
                else if (Role == "user")
                {
                    File.Create($"{AdminPathAndUser}/{Username}.txt").Close();
                    File.WriteAllText($"{AdminPathAndUser}/{Username}.txt", $"{Username} {Password} {Role.ToUpper()}");
                    Console.WriteLine("Account created succesfully");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                
            }
        }
    }
}
