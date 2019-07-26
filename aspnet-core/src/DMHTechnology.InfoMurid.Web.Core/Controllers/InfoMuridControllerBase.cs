using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace DMHTechnology.InfoMurid.Controllers
{
    public abstract class InfoMuridControllerBase: AbpController
    {
        protected InfoMuridControllerBase()
        {
            LocalizationSourceName = InfoMuridConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
