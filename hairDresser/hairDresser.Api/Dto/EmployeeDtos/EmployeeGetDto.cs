﻿using hairDresser.Presentation.Dto.EmployeeHairServiceDtos;
using hairDresser.Presentation.Dto.EmployeeWorkingIntervalDtos;

namespace hairDresser.Presentation.Dto.EmployeeDtos
{
    public class EmployeeGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<EmployeeHairServiceDto> EmployeeHairServices { get; set; }
        public ICollection<EmployeeWorkingIntervalDto> EmployeeWorkingIntervals { get; set; }
    }
}
