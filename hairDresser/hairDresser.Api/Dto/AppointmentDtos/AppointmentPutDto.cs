﻿
namespace hairDresser.Presentation.Dto.AppointmentDtos
{
    public class AppointmentPutDto
    {
        public int EmployeeId { get; set; }
        public List<int> HairServicesId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
