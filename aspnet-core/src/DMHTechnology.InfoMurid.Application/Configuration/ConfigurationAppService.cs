using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using DMHTechnology.InfoMurid.Configuration.Dto;

namespace DMHTechnology.InfoMurid.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : InfoMuridAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
