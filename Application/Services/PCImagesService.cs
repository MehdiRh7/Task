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
    public class PCImagesService : IPCImagesService
    {
        private readonly IMyContext context;

        public PCImagesService(IMyContext context)
        {
            this.context = context;
        }
        public IEnumerable<ProfessionalCert_Images> GetImages(int id)
        {
            return context.professionalCertImages.Where(x => x.UserId == id).ToList();
        }
    }
}
