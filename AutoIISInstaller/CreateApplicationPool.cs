using Microsoft.Web.Administration;
using System.Linq;

namespace AutoIISInstaller
{
    public class CreateApplicationPool
    {
        public void CreatePoolIIS(string PoolName)
        {
            ServerManager server = new ServerManager();

            ApplicationPool myApplicationPool = null;

            //we will create a new ApplicationPool named 'MyApplicationPool'
            //we will first check to make sure that this pool does not already exist
            //since the ApplicationPools property is a collection, we can use the Linq FirstOrDefault method
            //to check for its existence by name
            if (server.ApplicationPools != null && server.ApplicationPools.Count > 0)
            {
                if (server.ApplicationPools.Where(p => p.Name == PoolName).Count() > 0)
                {
                    //if we find the pool already there, we will get a referecne to it for update
                    myApplicationPool = server.ApplicationPools.FirstOrDefault(p => p.Name == PoolName);
                }
                else
                {
                    //if the pool is not already there we will create it
                    myApplicationPool = server.ApplicationPools.Add(PoolName);
                }
            }
            else
            {
                //if the pool is not already there we will create it
                myApplicationPool = server.ApplicationPools.Add(PoolName);
            }

            if (myApplicationPool != null)
            {
                //for this sample, we will set the pool to run under the NetworkService identity
                myApplicationPool.ProcessModel.IdentityType = ProcessModelIdentityType.NetworkService;

                //we set the runtime version
                myApplicationPool.ManagedRuntimeVersion = "No Managed Code";

                //we save our new ApplicationPool!
                server.CommitChanges();
            }
        }
    }
}
