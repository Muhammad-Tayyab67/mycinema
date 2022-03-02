using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mycinema.Data;
using mycinema.Models;
using System;

namespace mycinema.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDBContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDBContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

    }
}
