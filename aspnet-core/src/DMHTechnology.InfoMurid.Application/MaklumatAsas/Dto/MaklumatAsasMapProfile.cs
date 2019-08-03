using System;
using AutoMapper;

namespace DMHTechnology.InfoMurid.MaklumatAsas.Dto
{
    public class MaklumatAsasMapProfile : Profile
    {
        public MaklumatAsasMapProfile()
        {
            CreateMap<TahunAkademikDto, TahunAkademik>();
            CreateMap<CreateTahunAkademikDto, TahunAkademik>();
            CreateMap<KelasDto, Kelas>();
            CreateMap<CreateKelasDto, Kelas>();
            CreateMap<LevelLabelDto, LevelLabel>();
            CreateMap<CreateLevelLabelDto, LevelLabel>();
            CreateMap<LevelDto, Level>();
        }
    }
}
