using Application.Services.ContextInterface;
using Application.Services.Interface;
using Core.Domain.Entities.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Services
{
    public class DegreeImagesService : IDegreeImagesService
    {
        private readonly IMyContext context;

        public DegreeImagesService(IMyContext context)
        {
            this.context = context;
        }
        public IEnumerable<Degree_Images> GetImages(int id)
        {
            return context.degreeImages.Where(x => x.UserId == id).ToList();
        }
    }
}
