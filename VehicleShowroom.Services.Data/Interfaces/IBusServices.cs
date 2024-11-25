using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleShowroom.Data.Models;
using VehicleShowroom.Web;

namespace VehicleShowroom.Services.Data.Interfaces
{
    public interface IBusServices
    {
        Task<IEnumerable<Vehicle>> GetAllBusesAsync();
        Task<BusDetailsViewModel> GetBusDetailsAsync(int id);
        Task<BusEditViewModel> GetBusForEditAsync(int id);
        Task<bool> EditBusAsync(BusEditViewModel models);
        Task<BusDeleteViewModel> DeleteBusAsync(int id);
        Task<bool> BusConfirmDeleteAsync(int id);
    }
}
