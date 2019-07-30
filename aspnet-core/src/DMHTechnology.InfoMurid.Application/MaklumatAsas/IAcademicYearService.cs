using System;
using Abp.Application.Services;
using DMHTechnology.InfoMurid.MaklumatAsas.Dto;

namespace DMHTechnology.InfoMurid.MaklumatAsas
{
    public interface IAcademicYearService : IAsyncCrudAppService<TahunAkademikDto, int, PagedTahunAkademikResultRequestDto, CreateTahunAkademikDto, TahunAkademikDto>
    {
    }
}
