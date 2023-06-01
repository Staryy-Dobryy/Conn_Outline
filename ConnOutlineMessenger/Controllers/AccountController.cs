using ConnOutlineMessenger.BuisnessLogic.Services;
using ConnOutlineMessenger.BuisnessLogic.Services.Interfaces;
using ConnOutlineMessenger.BuisnessLogic.Services.Realization;
using ConnOutlineMessenger.DTO;
using ConnOutlineMessenger.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Principal;

namespace ConnOutlineMessenger.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;
        private readonly IJwtTokenService _jwtTokenService;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService, IJwtTokenService jwtTokenService)
        {
            _accountService = accountService;
            _logger = logger;
            _jwtTokenService = jwtTokenService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _accountService.Register(model);
                return View(model);
            }

            model.Modal = true;
            return View(model);
        }

        [HttpGet]
        public IActionResult FastRegistration()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        [HttpPost("/token")]
        public IActionResult Token(string email, string password)
        {
            var token = _jwtTokenService.CreateToken(email, password);
            if (token == null)
            {
                return BadRequest(new { errorText = "Ivalid values" });
            }
            var response = new
            {
                access_token = token,
            };
            return Json(response);
        }
    }
}