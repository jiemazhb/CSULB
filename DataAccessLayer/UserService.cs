using IDataAccessLayer;
using Playlistify.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService() : base(new PlaylistifyContext())
        {
        }
    }
}
