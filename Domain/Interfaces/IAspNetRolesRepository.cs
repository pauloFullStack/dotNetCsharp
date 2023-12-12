﻿using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAspNetRolesRepository
    {
        Task<IEnumerable<IdentityRole>> GetRoles();
    }
}
