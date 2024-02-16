namespace ToDoListProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateAccount createAUAdmin = new CreateAccount();
            SignIn signIn = new SignIn();
            Point:
            Console.WriteLine("[1] Sign up\n[2] Sign in");
            string Sign = Console.ReadLine();
            if(int.TryParse(Sign, out int sign))
            {
                if(sign == 1)
                {
                    Console.Clear();
                    createAUAdmin.CreateAUAccount();
                    goto Point;
                }
                else if(sign == 2)
                {
                    Console.Clear();
                    //sign in and ToDolist management
                    signIn.signin();
                    goto Point;
                }
                else
                {
                    Console.WriteLine("Wrong command!!!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    goto Point;
                }
            }
            else
            {
                Console.WriteLine("Only number allowed!!!");
                Thread.Sleep(2000);
                Console.Clear();
                goto Point;
            }
        }
    }
}
