﻿
namespace AssetManagement.Domain.Entities
{
    public class Department
    {
        int Id { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get;set; }
    }
}
