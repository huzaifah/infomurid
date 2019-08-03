using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using DMHTechnology.InfoMurid.MaklumatAsas.Dto;
using Microsoft.EntityFrameworkCore;

namespace DMHTechnology.InfoMurid.MaklumatAsas
{
    public class LevelLabelAppService : AsyncCrudAppService<LevelLabel, LevelLabelDto, long, PagedLevelLabelResultRequestDto, CreateLevelLabelDto, LevelLabelDto>, ILevelLabelAppService
    {
        private readonly IAbpSession _abpSession;
        private readonly IRepository<Level> _levelRepository;

        public LevelLabelAppService(IRepository<LevelLabel, long> repository,
            IRepository<Level> levelRepository,
            IAbpSession abpSession) : base(repository)
        {
            _levelRepository = levelRepository;
            _abpSession = abpSession;
        }

        public async Task<IReadOnlyList<LevelDto>> GetAllLevels()
        {
            var query = await _levelRepository.GetAll().ToListAsync();
            return ObjectMapper.Map<IReadOnlyList<LevelDto>>(query);
        }

        protected override IQueryable<LevelLabel> CreateFilteredQuery(PagedLevelLabelResultRequestDto input)
        {
            return Repository.GetAllIncluding(r => r.Level)
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), r => r.Name.Contains(input.Keyword))
                .WhereIf(input.LevelId != 0, r => r.LevelId == input.LevelId);
        }

        public async override Task<LevelLabelDto> Create(CreateLevelLabelDto input)
        {
            CheckCreatePermission();

            var levelLabel = ObjectMapper.Map<LevelLabel>(input);
            levelLabel.TenantId = AbpSession.TenantId ?? 1;
            levelLabel.Id = await Repository.InsertAndGetIdAsync(levelLabel);

            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(levelLabel);
        }
    }
}
