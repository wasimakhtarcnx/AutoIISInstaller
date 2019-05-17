using Microsoft.Web.Administration;
using System;
using System.Reflection;

namespace AutoIISInstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            string smsPool = "sms.local";
            ApplicationPool applicationPool;
            System.Console.WriteLine("IIS Installer Started");
            string appLocation = "";
            try
            {
                Console.WriteLine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
                appLocation = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            }
            catch (System.IO.IOException)
            {
            }
            catch (Exception)
            {
            }

            CreateApplicationPool createApplicationPool = new CreateApplicationPool();
            applicationPool = createApplicationPool.CreatePoolIIS(smsPool);
            CreateWebsite createWebsite = new CreateWebsite();
            createWebsite.AddWebsite("ncstcsmsoffline", @"C:\inetpub\ncstcsmsoffline\", applicationPool);
            RunCMDCommand runCMDCommand = new RunCMDCommand();
            runCMDCommand.CopyFiles(@"C:\Users\wasim.akhtar\Documents\TemWebsite\", @"C:\inetpub\ncstcsmsoffline\");

            System.Console.WriteLine("IIS Installer Ended");
            Console.ReadLine();

        }
    }
}
