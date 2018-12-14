using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Exam2.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Exam2.Controllers
{
    [Route("")]
    public class LoginRegController : Controller
    {
        private Exam2Context dbContext;
        public LoginRegController(
            Exam2Context context)
        {
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult LoginReg()
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                Users user = dbContext.users.FirstOrDefault(u => u.UsersId == HttpContext.Session.GetInt32("UserId"));
                if (user == null)
                {
                    return RedirectToAction("Logout");
                }
                return RedirectToAction("Dashboard", "Home");
            }
            return View();
        }
        [HttpPost("register")]
        public IActionResult Registering(Register model)
        {
            if (ModelState.IsValid)
            {
                if (dbContext.users.Any(u => u.Email == model.Email))
                {
                    ModelState.AddModelError("Email", "This email is already in use");
                    return View("LoginReg");
                }
                Users new_user = new Users
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };
                PasswordHasher<Users> Hasher = new PasswordHasher<Users>();
                new_user.Password = Hasher.HashPassword(new_user, model.Password);
                dbContext.Add(new_user);
                dbContext.SaveChanges();
                Users user = dbContext.users.FirstOrDefault(u => u.Email == new_user.Email);
                HttpContext.Session.SetInt32("UserId", user.UsersId);
                return RedirectToAction("Dashboard", "Home");
            }
            return View("LoginReg");
        }
        [HttpPost("logging")]
        public IActionResult Logging(Login model)
        {
            if (ModelState.IsValid)
            {
                if(!dbContext.users.Any(u => u.Email == model.LogEmail))
                {
                    ModelState.AddModelError("LogEmail", "Your Email did not match any in the database");
                    return View("LoginReg");
                }
                Users user= dbContext.users.FirstOrDefault(u => u.Email == model.LogEmail);
                PasswordHasher<Users> Hasher = new PasswordHasher<Users>();
                PasswordVerificationResult result = Hasher.VerifyHashedPassword(user, user.Password, model.LogPassword);
                if (result == 0)
                {
                    ModelState.AddModelError("LogPassword", "Your Password did not match the Email you provided");
                    return View("LoginReg");
                }
                HttpContext.Session.SetInt32("UserId", user.UsersId);
                return RedirectToAction("Dashboard", "Home");
            }
            return View("LoginReg");
        }
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginReg");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
