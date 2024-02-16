using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ToDoListProject
{
    internal class ToDoList
    {
        public void ToDoAdminAndUsers(string Username)
        {
            Console.Clear();
            string path = "D:/NewProjects/ToDoListProject/ToDoListProject/bin/ToDoList/Todo.txt", comm = "", Command = "",
                path2 = "D:/NewProjects/ToDoListProject/ToDoListProject/bin/UsersAndAdmins";
        Point:
            List<string> tasks = new List<string>();
            string[] path_2 = File.ReadAllText($"{path2}/{Username}.txt").Split(" ");
            Console.WriteLine($"Username: {path_2[0]}\nRole: {path_2[2]}\n");
            if (File.Exists(path))
            {
                tasks = File.ReadAllLines(path).ToList();
            }
            else
            {
                File.Create(path).Close();
                tasks = File.ReadAllLines(path).ToList();
            }

            if (File.ReadAllText(path) == "")
            {
                Console.WriteLine("There are no tasks for today\nAdd task[Add]\nLog out[Out] " );
                comm = Console.ReadLine().ToLower();
                if (comm != "add" && comm != "out") { Console.WriteLine("Wrong command!!!"); Thread.Sleep(2500); Console.Clear(); goto Point; }
                else if(comm == "out") return;
            }
            else
            {
                Console.WriteLine("ToDoList: ");
                for (int i = 0; i < tasks.Count; i++)
                {
                    List<string> list = new List<string>();
                    list = tasks[i].Split(' ').ToList();
                    string Last = list[list.Count - 1];
                    list.RemoveAt(list.Count - 1);
                    Console.Write($"{i + 1}         ");
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (j == list.Count() - 1)
                        {
                            Console.Write(list[j] + $" - By @{Last}");
                        }
                        else Console.Write(list[j]+" ");
                    }
                    Console.Write("\n");
                }
                Console.WriteLine("\nAdd task[Add]\nEdit task[Edit]\nDelete task[Delete]\nLog out[Out]");
                Command = Console.ReadLine().ToLower();
            }
            if (comm == "add" || Command == "add")
            {
                Console.Write($"Name of the task: ");
                Command = Console.ReadLine();
                File.AppendAllText($"{path}", $"{Command} {Username}\n");
                Console.WriteLine("Task is added succesfully");
                comm = ""; Command = "";
                Thread.Sleep(2500);
                Console.Clear();
                goto Point;

            }
            else if (Command == "delete")
            {
                Console.Write("Task name: ");
                string TName = Console.ReadLine().ToLower();
                for (int i = 0; i < tasks.Count; i++)
                {
                    List<string> list = new List<string>();
                    list = tasks[i].Split(' ').ToList();
                    string Last = list[list.Count - 1];
                    list.RemoveAt(list.Count - 1);
                    string ElementsInOne = "";
                    for (int j = 0; j < list.Count; j++)
                    {
                        if(j == list.Count - 1) ElementsInOne += list[j];

                        else ElementsInOne += list[j]+" ";
                    }
                    if (TName == ElementsInOne.ToLower() )
                    {
                        if (Username == Last || path_2[2].ToLower() == "admin")
                        {
                            List<string> items = tasks.ToList();
                            items.RemoveAt(i);
                            File.WriteAllText(path, "");
                            foreach (string task in items) File.AppendAllText(path, $"{task}\n");
                            Console.WriteLine("Succesfully deleted");
                            Thread.Sleep(2500);
                            Console.Clear();
                            goto Point; 
                        }
                        else
                        {
                            Console.WriteLine("This task is not yours");
                            Thread.Sleep(2500);
                            Console.Clear();
                            goto Point;
                        }
                    }
                    else
                    {
                        if (i == tasks.Count - 1)
                        {
                            Console.WriteLine("There is not a task in this name!!!");
                            Thread.Sleep(2500);
                            Console.Clear();
                            goto Point;
                        }
                    }
                }

            }
            else if (Command == "out")
            {
                return;
            }
            else if (Command == "edit")
            {
                Console.Write("Task name: ");
                string TName = Console.ReadLine();
                Console.Write("Edition form: ");
                string EditForm = Console.ReadLine();
                for(int i =0;i<tasks.Count();i++)
                {

                    List<string> list = new List<string>();
                    list = tasks[i].Split(' ').ToList();
                    string Last = list[list.Count - 1];
                    list.RemoveAt(list.Count - 1);
                    string ElementsInOne = "";
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (j == list.Count - 1) ElementsInOne += list[j];

                        else ElementsInOne += list[j] + " ";
                    }
                    List<string> Tasks = tasks.ToList();
                    if (TName == ElementsInOne )
                    {
                        if(Username == Last || path_2[2].ToLower() == "admin")
                        {
                            int index = Tasks.IndexOf($"{TName} {Last}");
                            Tasks[index] = EditForm + " " + Last;
                            File.WriteAllText(path, "");
                            for (int j = 0; j < Tasks.Count; j++)
                            {
                                File.AppendAllText(path, $"{Tasks[j]}\n");
                            }
                            Console.WriteLine("Succesfully edited");
                            Thread.Sleep(2500);
                            Console.Clear();
                            goto Point;
                        }
                        else
                        {
                            Console.WriteLine("This task is not yours");
                            Thread.Sleep(2500);
                            Console.Clear();
                            goto Point;
                        }
                    }
                    else
                    {
                        if(i == tasks.Count - 1)
                        {
                            Console.WriteLine("There is no task in this name!!!");
                            Thread.Sleep(2500);
                            Console.Clear();
                            goto Point;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Wrong command!!!");
                Thread.Sleep(2500);
                Console.Clear();
                goto Point;
            }
        }
    }
}
