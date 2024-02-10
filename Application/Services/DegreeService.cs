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
    public class DegreeService : IDegreeService
    {
        private readonly IMyContext context;

        public DegreeService(IMyContext context)
        {
            this.context = context;
        }
        public List<Degree> GetByUserID(int userId)
        {
            return context.degrees.Where(d=>d.UserId==userId).ToList();
        }
    }
}
