using Microsoft.Web.Administration;
using System;

namespace AutoIISInstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            string smsPool = "sms.local";
            ApplicationPool applicationPool;
            System.Console.WriteLine("IIS Installer Started");
            CreateApplicationPool createApplicationPool = new CreateApplicationPool();
            applicationPool = createApplicationPool.CreatePoolIIS(smsPool);
            CreateWebsite createWebsite = new CreateWebsite();

            System.Console.WriteLine("IIS Installer Ended");
            Console.ReadLine();

        }
    }
}
