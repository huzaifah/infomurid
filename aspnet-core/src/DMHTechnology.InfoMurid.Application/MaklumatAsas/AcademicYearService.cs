using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Runtime.Session;
using DMHTechnology.InfoMurid.MaklumatAsas.Dto;

namespace DMHTechnology.InfoMurid.MaklumatAsas
{
    public class AcademicYearService : AsyncCrudAppService<TahunAkademik, TahunAkademikDto, int, PagedTahunAkademikResultRequestDto, CreateTahunAkademikDto, TahunAkademikDto>, IAcademicYearService
    {
        private readonly IAbpSession _abpSession;

        public AcademicYearService(IRepository<TahunAkademik, int> repository) : base(repository)
        {
        }

        protected override IQueryable<TahunAkademik> CreateFilteredQuery(PagedTahunAkademikResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Year.ToString().Contains(input.Keyword))
                .WhereIf(input.IsLocked.HasValue, x => x.IsLocked == input.IsLocked);
        }

        public override async Task<TahunAkademikDto> Create(CreateTahunAkademikDto input)
        {
            CheckCreatePermission();

            var tahunAkademik = ObjectMapper.Map<TahunAkademik>(input);
            tahunAkademik.TenantId = AbpSession.TenantId ?? 1;
            tahunAkademik.Id = await Repository.InsertAndGetIdAsync(tahunAkademik);

            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(tahunAkademik);
        }
    }
}
