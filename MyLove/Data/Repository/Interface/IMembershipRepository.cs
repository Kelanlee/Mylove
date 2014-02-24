using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository.Interface
{
    public interface IMembershipRepository
    {
        bool ValidatePassword(int userId, string password);
    }
}
