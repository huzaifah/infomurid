using System;
using System.Linq;
using DMHTechnology.InfoMurid.MaklumatAsas;

namespace DMHTechnology.InfoMurid.EntityFrameworkCore.Seed.Tenants
{
    public class InitialMaklumatAsasCreator
    {
        private readonly InfoMuridDbContext _context;

        public InitialMaklumatAsasCreator(InfoMuridDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            if (!IsYearExist(2019))
                _context.AcademicYears.Add(new TahunAkademik
                {
                    Year = 2019
                });

            if (!IsYearExist(2018))
                _context.AcademicYears.Add(new TahunAkademik
                {
                    Year = 2018
                });

            if (!_context.Classes.Any())
            {
                _context.Classes.Add(new Kelas
                {
                    Code = "1M",
                    Name = "1 Merah",
                    TenantId = 1,
                    Tahap = Tahap.MenengahRendah
                });

                _context.Classes.Add(new Kelas
                {
                    Code = "1B",
                    Name = "1 Biru",
                    TenantId = 1,
                    Tahap = Tahap.MenengahRendah
                });

                _context.Classes.Add(new Kelas
                {
                    Code = "1K",
                    Name = "1 Kuning",
                    TenantId = 1,
                    Tahap = Tahap.MenengahRendah
                });

                _context.Classes.Add(new Kelas
                {
                    Code = "4M",
                    Name = "4 Merah",
                    TenantId = 1,
                    Tahap = Tahap.MenengahAtas
                });

                _context.Classes.Add(new Kelas
                {
                    Code = "4B",
                    Name = "4 Biru",
                    TenantId = 1,
                    Tahap = Tahap.MenengahAtas
                });

                _context.Classes.Add(new Kelas
                {
                    Code = "4K",
                    Name = "4 Kuning",
                    TenantId = 1,
                    Tahap = Tahap.MenengahAtas
                });
            }

            if (!_context.Levels.Any())
            {
                _context.Levels.Add(new Level { Code = "T1", Name = "Tingkatan 1" });
                _context.Levels.Add(new Level { Code = "T2", Name = "Tingkatan 2" });
                _context.Levels.Add(new Level { Code = "T3", Name = "Tingkatan 3" });
                _context.Levels.Add(new Level { Code = "T4", Name = "Tingkatan 4" });
                _context.Levels.Add(new Level { Code = "T5", Name = "Tingkatan 5" });
                _context.Levels.Add(new Level { Code = "T6R", Name = "Tingkatan 6 Rendah" });
                _context.Levels.Add(new Level { Code = "T6A", Name = "Tingkatan 6 Atas" });

                _context.SaveChanges();
            }
            
            if(!_context.LevelLabels.Any())
            {
                _context.LevelLabels.Add(new LevelLabel
                {
                    Name = "Tingkatan 1",
                    TenantId = 1,
                    Level = _context.Levels.Single(l => l.Code == "T1")
                });

                _context.LevelLabels.Add(new LevelLabel
                {
                    Name = "Tingkatan 2",
                    TenantId = 1,
                    Level = _context.Levels.Single(l => l.Code == "T2")
                });
            }

            _context.SaveChanges();
        }

        private bool IsYearExist(int year)
        {
            var yearExist = _context.AcademicYears.Where(y => y.Year == year).Any();
            return yearExist;
        }
    }
}
