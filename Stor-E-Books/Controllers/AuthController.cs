using Firebase.Auth;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Stor_E_Books.Controllers
{
    public class AuthController
    {
        FirebaseAuthProvider auth;
        public AuthController()
        {
            auth = new FirebaseAuthProvider(new FirebaseConfig(Environment.GetEnvironmentVariable("FirebaseMathApp")));

        }

    }
   

 
}
