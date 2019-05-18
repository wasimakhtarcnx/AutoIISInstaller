using Microsoft.Web.Administration;
using System.Linq;

namespace AutoIISInstaller
{
    public class CreateWebsite
    {
        public void AddWebsite(string WebSiteName, string WebsiteLocalPath, ApplicationPool myApplicationPool)
        {

            ServerManager server = new ServerManager();
            try
            {
                server.Sites.First(s => s.Name.Equals("Default Web Site")).Stop();
            }
            catch (System.InvalidOperationException e)
            {
                System.Console.WriteLine(e.Message);
            }
            //Create W
            if (server.Sites != null && server.Sites.Count > 0)
            {
                //we will first check to make sure that the site isn't already there
                if (server.Sites.FirstOrDefault(s => s.Name == WebSiteName) == null)
                {
                    //we will just pick an arbitrary location for the site
                    string path = WebsiteLocalPath;

                    //we must specify the Binding information
                    string ip = "*";
                    string port = "80";
                    string hostName = "*";

                    string bindingInfo = string.Format(@"{0}:{1}:{2}", ip, port, hostName);

                    //add the new Site to the Sites collection
                    Site site = server.Sites.Add(WebSiteName, "http", bindingInfo, path);

                    //set the ApplicationPool for the new Site
                    site.ApplicationDefaults.ApplicationPoolName = myApplicationPool.Name;

                    //save the new Site!
                    server.CommitChanges();
                    site.Start();
                }
                else
                {
                    try
                    {
                        server.Sites.First(s => s.Name.Equals(WebSiteName)).Start();
                    }
                    catch (System.Exception e)
                    {

                        System.Console.WriteLine(e.Message);
                    }

                }
            }
        }

    }
}
