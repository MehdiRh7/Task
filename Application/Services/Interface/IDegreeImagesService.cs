using Core.Domain.Entities.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interface
{
    public interface IDegreeImagesService
    {
        IEnumerable<Degree_Images> GetImages(int id);
    }
}
