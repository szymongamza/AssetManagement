﻿using AssetManagement.Application.Interfaces;
using AssetManagement.Domain.Entities;
using AssetManagement.Infrastructure.Data;

namespace AssetManagement.Infrastructure.Repositories;
public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(AssetManagementContext dbContext) : base(dbContext)
    {
    }
}