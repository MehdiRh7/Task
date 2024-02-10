using Application.Services.Interface;
using Core.Domain.Entities;
using Core.Domain.Entities.Images;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Presentation.TestTask.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUserService _userService;
        private readonly IBirthCertificateService _birthCertificateService;
        private readonly IDegreeService _degreeService;
        private readonly IProfessionalCertService _professionalCertService;
        private readonly IBCImagesService _bCImagesService;
        private readonly IDegreeImagesService _degreeImagesService;
        private readonly IPCImagesService _pCImagesService;

        public IndexModel(ILogger<IndexModel> logger, IUserService userService, IBirthCertificateService birthCertificateService, IDegreeService degreeService, IProfessionalCertService professionalCertService, IBCImagesService bCImagesService, IDegreeImagesService degreeImagesService , IPCImagesService pCImagesService)
        {
            _logger = logger;
            _userService = userService;
            _birthCertificateService = birthCertificateService;
            _degreeService = degreeService;
            _bCImagesService = bCImagesService;
            _degreeImagesService = degreeImagesService;
            _professionalCertService = professionalCertService;
            _pCImagesService = pCImagesService;
        }
        
        public Users? Users { get; set; }
        
        public BirthCertificate? birthCertificate { get; set; }
        
        public IEnumerable<Degree>? degree { get; set; }
        
        public IEnumerable<ProfessionalCert>? professionalCert { get; set; }
        
        public IEnumerable<BirthCertificate_Images>? bCImages { get; set; }
        
        public IEnumerable<Degree_Images>? degreeImages { get; set; }
        
        public IEnumerable<ProfessionalCert_Images>? pCImages { get; set; }
        public void OnGet()
        {
           
        }
        public IActionResult OnPost(string NIN)
        {
            if (string.IsNullOrEmpty(NIN))
            {
                ViewData["NotFoundUser"] = "لطفا کد ملی را وارد کنید";
                return Page();
            }
            Users = _userService.GetUser(NIN);
            if (Users != null)
            {
                birthCertificate = _birthCertificateService.GetByUserID(Users.Id);
            }
            else
            {
                ViewData["NotFoundUser"] = "کاربری با این کد ملی یافت نشد";
            }
            if(Users != null)
            {
                degree = _degreeService.GetByUserID(Users.Id).ToList();
            }
            if(Users != null)
            {
                professionalCert = _professionalCertService.GetByUserID(Users.Id);
            }
            if(birthCertificate != null)
            {
                bCImages = _bCImagesService.GetImages(birthCertificate.Id);
            }
            if(degree != null)
            {
                degreeImages = _degreeImagesService.GetImages(degree.FirstOrDefault().UserId);
            }
            if(professionalCert != null)
            {
                pCImages = _pCImagesService.GetImages(professionalCert.FirstOrDefault().UserId);
            }

            return Page();
        }
    }
}
