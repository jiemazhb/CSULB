using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusinessLogicLayer
{
    public interface IUserManager
    {
        Task Register(string email, string password);
        Task<bool> Login(string email, string password);
        Task ChangePassword(string email, string oldPassword, string newPassword);
        Task<UserInformation> GetUserByEmail(string email);
    }
}
