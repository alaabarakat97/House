﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Application.HouseManagement.Model;
using House.Application.HouseManagement.Owners.Queries.GetOwnerById;
using House.Domain.Entities;
using House.Domain.Enums;

namespace House.Application.HouseManagement.Apartments.Queries.GetApartmentById;
public class GetApartmentQueryViewModel
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public Guid? NeighborhoodId { get; set; } = null;
    public Guid CityId { get; set; }
    public int Sequence { get; set; }
    public int ApartmentNumber { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public string Currency { get; set; } = string.Empty;
    public string? Description { get; set; } = null;
    public int FloorNumber { get; set; }
    public int NumberRoom { get; set; }
    public string DescriptionLocation { get; set; } = string.Empty;
    public HouseStatus HouseStatus { get; set; }
    public HouseType HouseType { get; set; }
    private class Mapping : Profile
    {
        public Mapping() 
        {
            CreateMap<Apartment, GetApartmentQueryViewModel>();
        }    
    }
}