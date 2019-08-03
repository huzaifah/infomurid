using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using DMHTechnology.InfoMurid.MaklumatAsas.Dto;

namespace DMHTechnology.InfoMurid.MaklumatAsas
{
    public class ClassAppService : AsyncCrudAppService<Kelas, KelasDto, long, PagedKelasResultRequestDto, CreateKelasDto, KelasDto>, IClassAppService
    {
        private readonly IAbpSession _abpSession;

        public ClassAppService(IRepository<Kelas, long> repository, IAbpSession abpSession) : base(repository)
        {
            _abpSession = abpSession;
        }

        protected override IQueryable<Kelas> CreateFilteredQuery(PagedKelasResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), r => r.Code.Contains(input.Keyword) || r.Name.Contains(input.Keyword))
                .OrderBy(r => r.Code).ThenBy(r => r.Name);

        }

        public override async Task<KelasDto> Create(CreateKelasDto input)
        {
            CheckCreatePermission();

            var kelas = ObjectMapper.Map<Kelas>(input);
            kelas.TenantId = _abpSession.TenantId ?? 1;
            kelas.Id = await Repository.InsertAndGetIdAsync(kelas);

            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(kelas);
        }
    }
}
