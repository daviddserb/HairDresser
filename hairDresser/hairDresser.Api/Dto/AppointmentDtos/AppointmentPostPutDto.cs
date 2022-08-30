﻿using hairDresser.Presentation.Dto.AppointmentHairServiceDtos;
using System.ComponentModel.DataAnnotations;

namespace hairDresser.Presentation.Dto.AppointmentDtos
{
    public class AppointmentPostPutDto
    {
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public List<int> HairServicesId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}