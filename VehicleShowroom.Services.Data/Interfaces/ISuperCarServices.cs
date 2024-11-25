using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleShowroom.Data.Models;
using VehicleShowroom.Web;

namespace VehicleShowroom.Services.Data.Interfaces
{
    public interface ISuperCarServices
    {
        Task<IEnumerable<Vehicle>> GetAllSuperCarAsync();
        Task<SuperCarDetailsViewModel> GetSuperCarDetailsAsync(int id);
        Task<SuperCarEditVieModel> GetSuperForEditAsync(int id);
        Task<bool> EditCarAsync(SuperCarEditVieModel models);
        Task<SuperCarDeleteViewModel> GetSuperCarForDeleteAsync(int id);
        Task<bool> ConfirmDeleteAsync(int id);
    }
}
