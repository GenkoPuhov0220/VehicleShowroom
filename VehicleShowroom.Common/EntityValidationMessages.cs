using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleShowroom.Common
{
    public static class EntityValidationMessages
    {
        //Vehicle
        public const string VehicleTypeMessages = "Vehicle type is required";
        public const string VehicleMakeMessages = "Make is required.";
        public const string VehicleMakeMinLenght = "Make cannot exceed 2 characters.";
        public const string VehicleMakeMaxLenght = "Make cannot exceed 150 characters.";


    }
}
