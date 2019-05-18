using System.IO;

namespace AutoIISInstaller
{
    public class RunCMDCommand
    {
        public void ExecuteCommand(string ToPath)
        {
            System.Diagnostics.Process process1 = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo1 = new System.Diagnostics.ProcessStartInfo();
            startInfo1.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo1.FileName = "cmd.exe";
            startInfo1.Arguments = "/C mkdir " + ToPath;
            process1.StartInfo = startInfo1;
            process1.Start();

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C xcopy " + @"C:\Users\wasim.akhtar\Documents\TemWebsite\ " + ToPath + " /h/i/c/k/e/r/y";
            process.StartInfo = startInfo;
            process.Start();
        }
        public void CopyFiles(string SourcePath, string DestinationPath)
        {
            try
            {
                //Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(SourcePath, "*",
                    SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));

                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                    SearchOption.AllDirectories))
                    File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
            }
            catch (System.Exception e)
            {

                System.Console.WriteLine(e.Message);
            }

        }
    }
}
