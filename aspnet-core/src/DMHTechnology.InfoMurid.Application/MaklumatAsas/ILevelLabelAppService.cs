using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using DMHTechnology.InfoMurid.MaklumatAsas.Dto;

namespace DMHTechnology.InfoMurid.MaklumatAsas
{
    public interface ILevelLabelAppService : IAsyncCrudAppService<LevelLabelDto, long, PagedLevelLabelResultRequestDto, CreateLevelLabelDto, LevelLabelDto>
    {
        Task<IReadOnlyList<LevelDto>> GetAllLevels();
    }
}
