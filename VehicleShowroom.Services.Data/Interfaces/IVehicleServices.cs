using NPOI.SS.Formula.Functions;
using System.Runtime.CompilerServices;
using VehicleShowroom.Data.Models;
using VehicleShowroom.Web;

namespace VehicleShowroom.Services.Data.Interfaces
{
    public interface IVehicleServices
    {
        Task<IEnumerable<Vehicle>> IndexGetAllAsync();
        Task AddVehicleAsync(AddVehicleViewModel models);

    }
}
