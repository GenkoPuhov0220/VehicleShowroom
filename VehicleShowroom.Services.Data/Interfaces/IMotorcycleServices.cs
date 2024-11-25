using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleShowroom.Data.Models;
using VehicleShowroom.Web;

namespace VehicleShowroom.Services.Data.Interfaces
{
    public interface IMotorcycleServices
    {
        Task<IEnumerable<Vehicle>> GetAllMotorcycleAsync();
        Task<MotorcycleDeteilsViewModel> GetMotrocycleDetailsAsync(int id);
        Task<MotorcycleEditViewModel> GetMotorcycleForEditAsync(int id);
        Task<bool> EditMotorcycleAsync(MotorcycleEditViewModel models);
        Task<MotorcycleDeleteViewModel> DeleteMotorcycleAsync(int id);
        Task<bool> MotorcycleConfirmDeleteAsync(int id);
    }
}
