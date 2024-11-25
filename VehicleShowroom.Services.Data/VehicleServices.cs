using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleShowroom.Data;
using VehicleShowroom.Data.Models;
using VehicleShowroom.Services.Data.Interfaces;
using VehicleShowroom.Web;


namespace VehicleShowroom.Services.Data
{
    public class VehicleServices : IVehicleServices
    {
        private readonly VehicleDbContext context;
         public VehicleServices(VehicleDbContext _context)
         {
                context = _context;
         }
        public async Task<IEnumerable<Vehicle>> IndexGetAllAsync()
        {
            return await context.Vehicles
               .Where(v => v.IsDelete == false)
               .ToListAsync();
        }
        public Task AddVehicleAsync(AddVehicleViewModel models)
        {
            throw new NotImplementedException();
        }

    }
}
