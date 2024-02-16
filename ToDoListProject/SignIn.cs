using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListProject
{
    internal class SignIn
    {
        public void signin()
        {
            ToDoList toDoList = new ToDoList();
            string username = "", password = "",path = "D:/NewProjects/ToDoListProject/ToDoListProject/bin/UsersAndAdmins";
            Point:
            Console.Write("Sign in\nBack[Back]\nUsername: ");
            username = Console.ReadLine();
            if (username.ToLower() == "back")
            {
                Console.Clear();
                return;
            }
            string[] Info = { };
            if (File.Exists($"{path}/{username}.txt"))
            {
                Info = File.ReadAllText($"{path}/{username}.txt").Split(" ");
                //if (Info[0] != username) 
                //{
                //    Console.WriteLine("This username does not exist!!!");
                //    Thread.Sleep(2500);
                //    Console.Clear();
                //    goto Point;
                //}
                Console.Write("Password: ");
                password = Console.ReadLine();
                if (Info[0] == username && Info[1] == password && Info[2] == "ADMIN")
                {
                    Console.Clear();
                    toDoList.ToDoAdminAndUsers(username);
                    Console.Clear();
                }
                else if (Info[0] == username && Info[1] == password && Info[2] == "USER")
                {
                    Console.Clear();
                    toDoList.ToDoAdminAndUsers(username);
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
            else
            {
                Console.WriteLine("This username does not exist!!!");
                Thread.Sleep(2500);
                Console.Clear();
                goto Point;
            }
        }
    }
}
