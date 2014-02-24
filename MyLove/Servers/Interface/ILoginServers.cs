using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataContract;

namespace Servers.Interface
{
    public interface ILoginServers
    {

        bool LoginAccount(List<DataElement> db, out int UserID);
    }
}
