﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleShowroom.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<ApplicationUserVehicle> ApplicationUserVehicles { get; set; }
            = new HashSet<ApplicationUserVehicle>();
    }
}
