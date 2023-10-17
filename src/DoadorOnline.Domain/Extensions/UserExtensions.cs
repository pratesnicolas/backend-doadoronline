﻿using Microsoft.AspNetCore.Identity;
namespace DoadorOnline.Domain
{
    public static class UserExtensions
    {
        public static void Validate(this User user, IdentityResult identityResult)
        {
            foreach(var error in  identityResult.Errors)
            {
                user.AdicionarErro(error.Description);
            }
        }
    }
}
