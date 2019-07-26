using Abp.MultiTenancy;
using DMHTechnology.InfoMurid.Authorization.Users;

namespace DMHTechnology.InfoMurid.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
