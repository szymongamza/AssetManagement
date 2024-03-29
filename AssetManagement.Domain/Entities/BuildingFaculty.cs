﻿
using AssetManagement.Domain.Common;

namespace AssetManagement.Domain.Entities;
public class BuildingFaculty : BaseEntity
{
    public int FacultyId { get; set; }
    public int BuildingId { get; set; }
    public Faculty Faculty { get; set; }
    public Building Building { get; set; }
}
