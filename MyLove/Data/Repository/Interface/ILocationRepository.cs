using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;

namespace Data.Repository.Interface
{
    public interface ILocationRepository
    {
        IList<Location> GetLocations(int userId);

        bool DeleteLocation(int Id);

        bool AddLocation(int userId, string addressName);
    }
}
