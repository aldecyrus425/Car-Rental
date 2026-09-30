using MyApp.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repository
{
    public class VehicleTypesRepository
    {
        private readonly ApplicationDBContext _context;

        public VehicleTypesRepository(ApplicationDBContext context)
        {
            _context = context;
        };
    }
}
