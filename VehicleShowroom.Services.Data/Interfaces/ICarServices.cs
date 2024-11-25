using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleShowroom.Data.Models;
using VehicleShowroom.Web;

namespace VehicleShowroom.Services.Data.Interfaces
{
    public interface ICarServices
    {
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
        Task<CarDetailsViewModel> GetCarDetailsAsync(int id);
        Task<CarEditViewModel> GetCarForEditAsync(int id);
        Task<bool> EditCarAsync(CarEditViewModel models);
        Task<CarDeleteVehicleViewModel> GetCarForDeleteAsync(int id);
        Task<bool> ConfirmDeleteAsync(int id);
    }
}
