using Application.Services.Interface;
using Core.Domain.Entities;
using Core.Domain.Entities.Images;
using Infrastructure.Persistance.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presentation.TestTask.Pages.Shared
{
    public class DegreeDocumentsModel : PageModel
    {
        private readonly MyContext context;
        private readonly IUserService _userService;
        private readonly IBirthCertificateService _birthCertificateService;
        private readonly IDegreeService _degreeService;
        private readonly IProfessionalCertService _professionalCertService;
        private readonly IBCImagesService _bCImagesService;
        private readonly IDegreeImagesService _degreeImagesService;
        private readonly IPCImagesService _pCImagesService;


        public DegreeDocumentsModel(MyContext context, IUserService userService, IDegreeService degreeService, IDegreeImagesService degreeImagesService)
        {
            this.context = context;
            _userService = userService;
            _degreeService = degreeService;
            _degreeImagesService = degreeImagesService;

        }
        [BindProperty(Name = "Check")]

        public string? Check { get; set; }
        [BindProperty]
        public Users? Users { get; set; }

        [BindProperty]
        public IEnumerable<Degree>? degree { get; set; }

        [BindProperty]
        public IEnumerable<Degree_Images>? degreeImages { get; set; }

        public IActionResult OnGet(string NIN)
        {
            if (Check != null)
            {
                Users = _userService.GetUser(NIN);

                if (Users != null)
                {
                    degree = _degreeService.GetByUserID(Users.Id).ToList();
                }
                if (degree != null)
                {
                    degreeImages = _degreeImagesService.GetImages(degree.FirstOrDefault().UserId).ToList();
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
