using Examen.Contracts;
using Examen.Models.ConfigurationModels;
using Examen.Models.InputModels;
using Examen.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Examen.Controllers
{

    [Route("accounts")]
    public class AccountsController : Controller
    {
        public AccountsController
             ( //IOptions<ConfiguracionRecaptcha> configuracion, IRecaptchaValidator recaptcha,
                 IServer server,
                 UserManager<IdentityUser> userManager, SignInManager<IdentityUser> sessionManager)
        {
            _server = server;
            _userManager = userManager;
            _sessionManager = sessionManager;
            //Configuracion = configuracion.Value;
            //Recaptcha = recaptcha;
        }

        readonly IServer _server;
        readonly UserManager<IdentityUser> _userManager;
        readonly SignInManager<IdentityUser> _sessionManager;
        ConfiguracionRecaptcha Configuracion;
        IRecaptchaValidator Recaptcha;

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login()
        {
            LoginInputModel model =
                new LoginInputModel
                {
                    ExternalLogins =
                        (await _sessionManager.GetExternalAuthenticationSchemesAsync()).ToList()
                };

            return View(model);
        }



        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _sessionManager.PasswordSignInAsync
                        (model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError(string.Empty, "Session could not be started!");
            }

            return View(model);
        }


        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            RegisterInputModel model =
                new RegisterInputModel();

            return View(model);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterInputModel model)
        {
            if (ModelState.IsValid)
            {
                var email = model.Email;

                var user =
                    new IdentityUser
                    {
                        UserName = email,
                        Email = email
                    };

                var result =
                    await _userManager.CreateAsync(user, password: model.Password);

                if (result.Succeeded)
                {
                    await _sessionManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        //Posible código de Login, por favor verificar



        



        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _sessionManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }


        [HttpPost]
        [Route("externallogin")]
        [AllowAnonymous]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl =
                Url.Action
                    (action: "ExternalLoginCallback", new { ReturnUrl = returnUrl });

            var properties =
                _sessionManager.ConfigureExternalAuthenticationProperties
                    (provider, redirectUrl);

            return new ChallengeResult(provider, properties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if (string.IsNullOrEmpty(returnUrl))
                returnUrl = Url.Content("~/");

            LoginInputModel model =
            new LoginInputModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _sessionManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if (!string.IsNullOrEmpty(remoteError))
            {
                ModelState.AddModelError(string.Empty, $"Provider has reported the following error: {remoteError}");
                return View(model);
            }

            var info =
                await _sessionManager.GetExternalLoginInfoAsync();

            var result =
                await _sessionManager.ExternalLoginSignInAsync
                    (info.LoginProvider, info.ProviderKey, isPersistent: false);

            if (result.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                var email = info.Principal.FindFirst(ClaimTypes.Email).Value;

                if (!string.IsNullOrEmpty(email))
                {
                    var user = await _userManager.FindByEmailAsync(email);

                    if (user == null)
                    {
                        user =
                            new IdentityUser
                            {
                                Email = email,
                                UserName = email
                            };

                        await _userManager.CreateAsync(user);
                    }

                    await _userManager.AddLoginAsync(user, info);
                    await _sessionManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
            }

            ModelState.AddModelError(string.Empty, $"{info.ProviderDisplayName} has not responded.");
            return View(model);
        }





        [Route("checkemail")]
        [AllowAnonymous]
        public async Task<JsonResult> CheckEmail(string email)
        {
            var user =
                await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Json(true);
            }

            return Json($"Email {email} already exists!");
        }



        [HttpGet]
        [Route("forgetpassword")]
        public IActionResult ForgetPassword()
        {
            Fpassword model =
                new Fpassword();

            return View(model);
        }

        [HttpPost]
        [Route("forgetpassword")]
        public async Task<IActionResult> ForgetPassword(Fpassword model)
        {
            if (ModelState.IsValid)
            {
                var email = model.Email;

                var user =
                    await _userManager.FindByEmailAsync(email);

                if (user != null)
                {
                    var token =
                        await _userManager.GeneratePasswordResetTokenAsync(user);

                    var resetPasswordUrl =
                        string.Concat
                            (
                                _server.Features.Get<IServerAddressesFeature>().Addresses.FirstOrDefault(),
                                Url.Action(nameof(ResetPassword)),
                                "?email=",
                                WebUtility.UrlEncode(email),
                                "&token=",
                                WebUtility.UrlEncode(token)
                            );

                    /* CODIGO PARA ENVIAR CORREO */
                }
                return View(nameof(ForgetPasswordConfirmation));
            }
            return View(model);
        }

        [Route("forgetpasswordconfirmation")]
        public IActionResult ForgetPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        [Route("resetpassword")]
        [AllowAnonymous]
        public IActionResult ResetPassword(string email, string token)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
            {
                ModelState.AddModelError
                    (string.Empty, "Email and Token are required!");
            }

            return View();
        }

        [HttpPost]
        [Route("resetpassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPassword model)
        {
            if (ModelState.IsValid)
            {
                var user =
                    await _userManager.FindByEmailAsync(model.Email);

                if (user == null)
                {
                    RedirectToAction("index", "home");
                }

                var result =
                    await _userManager.ResetPasswordAsync
                        (user, model.Token, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(ResetPasswordConfirmation));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }


        [Route("resetpasswordconfirmation")]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

    }
}
