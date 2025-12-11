using Linter.Models.Modelos;
using Microsoft.AspNetCore.Identity;

namespace Linter.Components.Account
{
    internal sealed class IdentityUserAccessor(UserManager<Users> userManager, IdentityRedirectManager redirectManager)
    {
        public async Task<Users> GetRequiredUserAsync(HttpContext context)
        {
            var user = await userManager.GetUserAsync(context.User);

            if (user is null)
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
            }

            return user;
        }
    }
}
