using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleShowroom.Data.Models;
using VehicleShowroom.Web;

namespace VehicleShowroom.Services.Data.Interfaces
{
    public interface ITruckServices
    {
        Task<IEnumerable<Vehicle>> GetAllTrucksAsync();
        Task<TruckDetailsViewModel> GetTruckDetailsAsync(int id);
        Task<TruckEditViewModel> GetTruckForEditAsync(int id);
        Task<bool> EditTruckAsync(TruckEditViewModel models);
        Task<TruckDeleteViewModel> GetTruckForDeleteAsync(int id);
        Task<bool> ConfirmDeleteAsync(int id);
    }
}
