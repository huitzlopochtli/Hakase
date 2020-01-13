using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApplication1.Data;

namespace WebApplication1.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public LoginModel(ApplicationDbContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            try
            {
                returnUrl = returnUrl ?? Url.Content("~/");

                if (ModelState.IsValid)
                {
                    // This doesn't count login failures towards account lockout
                    // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                    var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: true);
                    if (result.Succeeded)
                    {
                        var currentUser = await _userManager.Users.Where(u => u.Email == Input.Email).SingleOrDefaultAsync();

                        var roles = await _userManager.GetRolesAsync(currentUser);

                        if (roles.Any(r => r == "Admin"))
                        {
                            HttpContext.Session.SetString("Role", "Admin");
                            returnUrl = Url.Content("~/Admin");
                        }

                        else if (roles.Any(r => r == "Customer"))
                        {
                            HttpContext.Session.SetString("Role", "Customer");

                            if (!_context.Customers.Any(c => c.User.UserName == Input.Email))
                            {
                                await _signInManager.SignOutAsync();
                                return Unauthorized();

                            }

                            var customer = await _context.Customers.Where(c => c.User.UserName == Input.Email)
                                .SingleOrDefaultAsync();

                            customer.LastLoginDate = DateTime.Now;

                            _context.Update(customer);
                            await _context.SaveChangesAsync();

                            returnUrl = Url.Content("~/customerPanel/index");
                        }

                        _logger.LogInformation("User logged in.");
                        return LocalRedirect(returnUrl);
                    }
                    if (result.RequiresTwoFactor)
                    {
                        return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                    }
                    if (result.IsLockedOut)
                    {
                        _logger.LogWarning("User account locked out.");
                        return RedirectToPage("./Lockout");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "メールまたはパスワードが間違っています");
                        return Page();
                    }
                }

                // If we got this far, something failed, redisplay form
                return Page();
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "メールまたはパスワードが間違っています");
                return Page();
            }

            
        }
    }
}
