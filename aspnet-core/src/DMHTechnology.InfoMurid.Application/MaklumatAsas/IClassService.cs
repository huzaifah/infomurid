using System;
using Abp.Application.Services;
using DMHTechnology.InfoMurid.MaklumatAsas.Dto;

namespace DMHTechnology.InfoMurid.MaklumatAsas
{
    public interface IClassService : IAsyncCrudAppService<KelasDto, long, PagedKelasResultRequestDto, CreateKelasDto, KelasDto>
    {
        
    }
}
