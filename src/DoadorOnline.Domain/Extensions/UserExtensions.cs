using Microsoft.AspNetCore.Identity;
namespace DoadorOnline.Domain
{
    public static class UserExtensions

    {
        public static void Validate(this Donator user, IdentityResult identityResult)
        {
            foreach(var error in  identityResult.Errors)
            {
                user.AddError(error.Description);
            }
        }
    }
}
