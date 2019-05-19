using Microsoft.Web.Administration;
using System;
using System.Reflection;

namespace AutoIISInstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            string smsPool = "schoolmanagement";
            ApplicationPool applicationPool;
            System.Console.WriteLine("IIS Installer Started");
            string appLocation = "";
            try
            {
                Console.WriteLine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
                appLocation = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                appLocation = appLocation + @"\Publish\";
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
            createWebsite.AddWebsite("schoolmanagement", @"C:\inetpub\schoolmanagement\", applicationPool);
            RunCMDCommand runCMDCommand = new RunCMDCommand();
            runCMDCommand.CopyFiles(appLocation, @"C:\inetpub\schoolmanagement\");

            System.Console.WriteLine("IIS Installer Ended");


            System.Diagnostics.Process.Start("http://localhost/");
            Console.ReadLine();

        }
    }
}
