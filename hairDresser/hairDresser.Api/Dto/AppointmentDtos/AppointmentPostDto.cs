﻿using hairDresser.Presentation.Dto.AppointmentHairServiceDtos;
using System.ComponentModel.DataAnnotations;

namespace hairDresser.Presentation.Dto.AppointmentDtos
{
    public class AppointmentPostDto
    {
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
