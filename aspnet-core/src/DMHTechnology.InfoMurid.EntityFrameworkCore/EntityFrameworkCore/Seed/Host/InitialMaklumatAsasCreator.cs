using System;
using System.Linq;
using DMHTechnology.InfoMurid.MaklumatAsas;

namespace DMHTechnology.InfoMurid.EntityFrameworkCore.Seed.Host
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
        }

        private bool IsYearExist(int year)
        {
            var yearExist = _context.AcademicYears.Where(y => y.Year == year).Any();
            return yearExist;
        }
    }
}
