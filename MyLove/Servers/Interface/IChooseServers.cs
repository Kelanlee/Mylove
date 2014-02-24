using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using  DataContract;
namespace Servers.Interface
{
    public interface IChooseServers
    {
        IList<LocationData> GetLocations(int userId);

        bool DeleteLocation(int Id);

        bool AddALocation(int userId, string addressName);
    }
}
