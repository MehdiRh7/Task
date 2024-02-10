using Infrastructure.Infrastructures.Generator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestTask.Pages
{
    public class ValidationModel : PageModel
    {
        public OtpCode otp = new OtpCode();
        public void OnGet(string id , string doc)
        {
            if (id.StartsWith('0'))
            {
                ViewData["id"] = id;
            }
            else
            {
                ViewData["id"] = "00" + id;
            }
            ViewData["doc"] = doc;
            var code = otp.Generate();
            //SendEmail mail = new SendEmail();
            //mail.Send("mehdirh025@gmail.com", "??????????", code);


        }
    }
}
