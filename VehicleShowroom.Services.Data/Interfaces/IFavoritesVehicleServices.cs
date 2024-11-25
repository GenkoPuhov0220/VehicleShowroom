using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleShowroom.Web;

namespace VehicleShowroom.Services.Data.Interfaces
{
    public interface IFavoritesVehicleServices
    {
        Task<IEnumerable<ApplicationUserFavoriteList>> GetIndexFavoritesAsync(string userId);
        Task<bool> AddToFavoritesAsync(string userId, int vehicleId);
        Task<bool> RemoveFromFavoritesAsync(string userId, int vehicleId);
    }
}
