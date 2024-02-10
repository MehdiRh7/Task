using Application.Services.ContextInterface;
using Application.Services.Interface;
using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMyContext context;

        public UserService(IMyContext context)
        {
            this.context = context;
        }
        public Users GetUser(string NIN)
        {
            return context.users.Where(u=>u.NIN == NIN).FirstOrDefault();
        }
    }
}
