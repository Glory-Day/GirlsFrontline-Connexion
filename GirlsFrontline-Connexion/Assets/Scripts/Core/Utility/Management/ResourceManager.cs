using GloryDay.Utility;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Utility.Management
{
    public class ResourceManager : Singleton<ResourceManager>
    {
        private readonly List<Task> _tasks = new List<Task>();

        private ResourceManager() { }

        private void LoadGameObjectAssetsByLabel_Internal(string label)
        {

        }
    }
}
