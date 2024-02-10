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
    public class BCImagesService : IBCImagesService
    {
        private readonly IMyContext context;

        public BCImagesService(IMyContext context)
        {
            this.context = context;
        }
        public IEnumerable<BirthCertificate_Images> GetImages(int id)
        {
            return context.birthCertificatesImages.Where(x => x.BirthCertificateID == id).ToList();
        }
    }
}
