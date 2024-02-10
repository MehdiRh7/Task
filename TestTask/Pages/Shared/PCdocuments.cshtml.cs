using Application.Services.Interface;
using Core.Domain.Entities;
using Core.Domain.Entities.Images;
using Infrastructure.Persistance.Context;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestTask.Pages.Shared
{
    public class PCdocumentsModel : PageModel
    {
        private readonly MyContext context;
        private readonly IUserService _userService;
        private readonly IBirthCertificateService _birthCertificateService;
        private readonly IDegreeService _degreeService;
        private readonly IProfessionalCertService _professionalCertService;
        private readonly IBCImagesService _bCImagesService;
        private readonly IDegreeImagesService _degreeImagesService;
        private readonly IPCImagesService _pCImagesService;


        public PCdocumentsModel(MyContext context, IUserService userService,  IProfessionalCertService professionalCertService,  IPCImagesService pCImagesService)
        {
            this.context = context;
            _userService = userService;
            _professionalCertService = professionalCertService;
            _pCImagesService = pCImagesService;
        }
        [BindProperty(Name = "Check")]
        
        public string? Check { get; set; }

        [BindProperty]
        public Users? Users { get; set; }

        [BindProperty]
        public IEnumerable<ProfessionalCert>? professionalCert { get; set; }

        [BindProperty]
        public IEnumerable<ProfessionalCert_Images>? pCImages { get; set; }

        
        public IActionResult OnGet(string NIN)
        {
            if (Check != null)
            {
                Users = _userService.GetUser(NIN);
                if (Users != null)
                {
                    professionalCert = _professionalCertService.GetByUserID(Users.Id).ToList();
                }

                if (professionalCert != null)
                {
                    pCImages = _pCImagesService.GetImages(professionalCert.FirstOrDefault().UserId).ToList();
                }
                return Page();
            }
            else
            {
                return NotFound();
            }

        }
        
        public IActionResult OnPost()
        {
            return OnGet(Check);
        }
    }
}
