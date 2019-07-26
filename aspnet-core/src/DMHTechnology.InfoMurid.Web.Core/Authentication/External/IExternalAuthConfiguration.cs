using System.Collections.Generic;

namespace DMHTechnology.InfoMurid.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
