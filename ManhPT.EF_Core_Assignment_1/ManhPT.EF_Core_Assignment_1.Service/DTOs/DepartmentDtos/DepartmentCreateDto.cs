﻿using System.ComponentModel.DataAnnotations;

namespace ManhPT.EF_Core_Assignment_1.Service.DTOs.DepartmentDtos
{
    public class DepartmentCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
