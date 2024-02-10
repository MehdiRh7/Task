using Application.Services.Interface;
using Core.Domain.Entities;
using Core.Domain.Entities.Images;
using Infrastructure.Persistance.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Presentation.TestTask.Pages.Shared
{
    public class BCdocumentsModel : PageModel
    {
        private readonly MyContext context;
        private readonly IUserService _userService;
        private readonly IBirthCertificateService _birthCertificateService;
        private readonly IDegreeService _degreeService;
        private readonly IProfessionalCertService _professionalCertService;
        private readonly IBCImagesService _bCImagesService;
        private readonly IDegreeImagesService _degreeImagesService;
        private readonly IPCImagesService _pCImagesService;


        public BCdocumentsModel(MyContext context, IUserService userService, IBirthCertificateService birthCertificateService, IBCImagesService bCImagesService)
        {
            this.context = context;
            _userService = userService;
            _birthCertificateService = birthCertificateService;
            _bCImagesService = bCImagesService;
        }
        [BindProperty(Name = "Check")]

        public string? Check { get; set; }
        [BindProperty]
        public Users? Users { get; set; }
        [BindProperty]
        public BirthCertificate? birthCertificate { get; set; }
        [BindProperty]
        public IEnumerable<BirthCertificate_Images>? bCImages { get; set; }

        public IActionResult OnGet(string NIN)
        {
            if (Check != null)
            {
                Users = _userService.GetUser(NIN);
                if (Users != null)
                {
                    birthCertificate = _birthCertificateService.GetByUserID(Users.Id);
                }

                if (birthCertificate != null)
                {
                    bCImages = _bCImagesService.GetImages(birthCertificate.Id);
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
