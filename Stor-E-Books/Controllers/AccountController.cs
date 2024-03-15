using Firebase.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mono.TextTemplating;
using Stor_E_Books.Models;

namespace Stor_E_Books.Controllers
{
    public class AccountController : Controller
    {
        public static string ApiKey = "AIzaSyDRz7ANRNprp8lFU9tQ1Jx5QQE6chSY2KA";
        public static string Bucket = "asp-mvc-with-android.appspot,com";
        public IActionResult singUp()
        {
           return View();
        }

        [AllowAnonymous]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignUp(SignUpModel model)
        {
            try
            {
                var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));

                var a = await auth.CreateUserWithEmailAndPasswordAsync(model.Email, model.Password, model.Name, true);
                ModelState.AddModelError(string.Empty, "please verify your email then login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }


        //get account
        [HttpGet]

        public IActionResult Login(string returnUrl)
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                  //  return this.RedirectToLocal(returnUrl)
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return this.View();
        }

    }
}

