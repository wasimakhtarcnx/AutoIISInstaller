namespace AutoIISInstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("IIS Installer Started");
            CreateApplicationPool createApplicationPool = new CreateApplicationPool();
            createApplicationPool.CreatePoolIIS("sms.local");
            System.Console.WriteLine("IIS Installer Ended");

        }
    }
}
