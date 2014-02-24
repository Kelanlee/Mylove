using Data.Models;

namespace Data.Repository.Interface
{
    public interface IUserRepository
    {
        User getUserByUsername(string username);

        User getUserByUserId(int userId);


    }
}
