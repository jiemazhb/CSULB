using DataAccessLayer;
using DataTransferObject;
using IBusinessLogicLayer;
using IDataAccessLayer;
using Playlistify.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLogicLayer
{
    public class UserManager : IUserManager
    {
        public async Task ChangePassword(string email, string oldPassword, string newPassword)
        {
            using (IUserService userSev = new UserService())
            {
                if(await userSev.GetAll().AnyAsync(m => m.Email == email && m.Password == oldPassword)){
                    var user = await userSev.GetAll().FirstAsync(u => u.Email == email);
                    user.Password = newPassword;
                    await userSev.EditAsync(user);
                }
            }
        }

        public async Task<UserInformation> GetUserByEmail(string email)
        {
            using (IUserService userSev = new UserService())
            {
                if (await userSev.GetAll().AnyAsync(m => m.Email == email)){
                    return await userSev.GetAll().Where(u => u.Email == email).Select(u => new UserInformation()
                    {
                        Id = u.Id,
                        Name = u.Name,
                        Email = u.Email
                    }).FirstAsync();
                }
                else
                {
                    throw new ArgumentException("Email does NOT exist!");
                }
            }
        }

        public async Task<bool> Login(string email, string password)
        {
            using (IUserService userSev = new UserService())
            {
                return await userSev.GetAll().AnyAsync(m => m.Email == email && m.Password == password);
            }
        }

        public async Task Register(string email, string password)
        {
            using (IUserService userSev = new UserService())
            {
                await userSev.CreateAsync(new User()
                {
                    Email = email,
                    Password = password
                });
            }
        }
    }
}
