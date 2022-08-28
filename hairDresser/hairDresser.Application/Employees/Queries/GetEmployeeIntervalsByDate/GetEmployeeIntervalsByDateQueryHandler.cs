﻿using hairDresser.Application.Interfaces;
using hairDresser.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hairDresser.Application.Employees.Queries.GetEmployeeIntervalsForAppointmentByDate
{
    public class GetEmployeeIntervalsByDateQueryHandler : IRequestHandler<GetEmployeeIntervalsByDateQuery, List<(DateTime startDate, DateTime endDate)>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetEmployeeIntervalsByDateQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<(DateTime startDate, DateTime endDate)>> Handle(GetEmployeeIntervalsByDateQuery request, CancellationToken cancellationToken)
        {
            Console.WriteLine("\nGetEmployeeIntervalsByDateQueryHandler:");

            var appointmentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, request.Date);
            Console.WriteLine($"appointment (ignoram Time-ul, am setat doar Date-ul, adica Day, in Anul curent si Luna curenta)= '{appointmentDate}'");

            var duration = TimeSpan.FromMinutes(request.DurationInMinutes);
            Console.WriteLine($"duration, from minutes to TimeSpan,= '{duration}'");

            var employeeAppointmentsDates = new List<(DateTime startDate, DateTime endDate)>();
            Console.WriteLine("\nAll the appointments from the selected employee and the selected date:");
            foreach (var appointment in await _unitOfWork.AppointmentRepository.GetAllAppointmentsByEmployeeIdByDateAsync(request.EmployeeId, appointmentDate))
            {
                // ??? Inainte aveam asa: employeeAppointmentsDates.Add((appointment.StartDate, appointment.EndDate));. A trebuit sa schimb pt. ca in clasa Appointment, am adaugat ? dupa DateTime.
                employeeAppointmentsDates.Add(((DateTime startDate, DateTime endDate))(appointment.StartDate, appointment.EndDate));
                Console.WriteLine($"{appointment.Id} - customer= '{appointment.Customer.Name}', employee='{appointment.Employee.Name}', start= '{appointment.StartDate}', end= '{appointment.EndDate}'");
            }

            Console.WriteLine("\nSorted appointments:");
            var sorted_employeeAppointmentsDates = employeeAppointmentsDates.OrderBy(date => date.startDate);
            foreach (var sortedAppointment in sorted_employeeAppointmentsDates)
            {
                Console.WriteLine($"start= '{sortedAppointment.startDate}', end= '{sortedAppointment.endDate}'");
            }

            var nameOfDay = appointmentDate.ToString("dddd");
            Console.WriteLine($"\nname of the day based on the selected date is= '{nameOfDay}'");

            var workingDay = await _unitOfWork.WorkingDayRepository.GetWorkingDayByNameAsync(nameOfDay);

            var employeeWorkingIntervals = await _unitOfWork.WorkingIntervalRepository.GetWorkingIntervalByEmployeeIdByWorkingDayIdAsync(request.EmployeeId, workingDay.Id);
            var possibleIntervals = new List<DateTime>();
            foreach (var intervals in employeeWorkingIntervals)
            {
                Console.WriteLine($"day intervals (start - end): '{intervals.StartTime}' - '{intervals.EndTime}'");
                possibleIntervals.Add(appointmentDate.Add(intervals.StartTime));
                foreach (var app in sorted_employeeAppointmentsDates)
                {
                    if (intervals.StartTime <= app.startDate.TimeOfDay && app.endDate.TimeOfDay <= intervals.EndTime)
                    {
                        possibleIntervals.Add(app.startDate);
                        possibleIntervals.Add(app.endDate);
                    }
                }
                possibleIntervals.Add(appointmentDate.Add(intervals.EndTime));
            }
            Console.WriteLine("\nPossible Intervals:");
            foreach (var intervals in possibleIntervals)
            {
                Console.WriteLine(intervals);
            }

            var validIntervals = new List<(DateTime startDate, DateTime endDate)>();
            Console.WriteLine("\nCheck for valid intervals:");
            for (int i = 0; i < possibleIntervals.Count - 1; i += 2)
            {
                var startOfInterval = possibleIntervals[i];
                var copy_startOfInterval = startOfInterval;
                var endOfInterval = possibleIntervals[i + 1];
                Console.WriteLine($"intervals (start - end): '{startOfInterval.TimeOfDay}' - '{endOfInterval.TimeOfDay}'");
                Console.WriteLine("Valid dates:");
                while ((startOfInterval += duration) <= endOfInterval)
                {
                    Console.WriteLine(copy_startOfInterval.TimeOfDay + " - " + startOfInterval.TimeOfDay);
                    validIntervals.Add((copy_startOfInterval, startOfInterval));
                    copy_startOfInterval = startOfInterval;
                }
            }
            //Console.WriteLine("\nAll valid intervals:");
            //foreach (var intervals in validIntervals)
            //{
            //    Console.WriteLine($"start= '{intervals.startDate}', end= '{intervals.endDate}'");
            //}
            return await Task.FromResult(validIntervals);
        }
    }
}