using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaDay.Models;
using SpaDay.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SpaDay.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            AddUserViewModel addUserViewModel = new AddUserViewModel();

            return View(addUserViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {
                if (addUserViewModel.Password == addUserViewModel.VerifyPassword)
                {
                    User newUser = new User
                    {
                        Username = addUserViewModel.Username,
                        Email = addUserViewModel.Email,
                        Password = addUserViewModel.Password
                    };
                    return View("Index", newUser);
                }
                else
                {
                    return View("Add");
                }
            }

            return View(addUserViewModel);

            //if (newUser.Password == verify)
            //{
            //    ViewBag.user = newUser;
            //    return View("Index");
            //}
            //else
            //{
            //    ViewBag.error = "Passwords do not match! Try again!";
            //    ViewBag.userName = newUser.Username;
            //    ViewBag.eMail = newUser.Email;
            //    return View("Add");
            //}
        }

    }
}
