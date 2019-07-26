using System.Threading.Tasks;
using DMHTechnology.InfoMurid.Configuration.Dto;

namespace DMHTechnology.InfoMurid.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
