﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using House.Application.Common.Models;
using House.Application.HouseManagement.Model;
using House.Domain.Entities;
using House.Domain.Enums;

namespace House.Application.HouseManagement.Owners.Commands.CreateOwner;
public class CreateOwnerCommand : IRequest<Result<string>>
{
    public Guid CityId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateOwnerCommand, Owner>();
        }
    }
}
