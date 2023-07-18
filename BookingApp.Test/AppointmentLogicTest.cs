using BookingApp.Logic.Classes;
using BookingApp.Models.Models;
using BookingApp.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BookingApp.Test
{
    [TestFixture]
    public class AppointmentLogicTest
    {
        AppointmentLogic logic;
        Mock<IRepository<Appointment>> mockAppointmentRepo;

        [SetUp]
        public void Init()
        {
            mockAppointmentRepo = new Mock<IRepository<Appointment>>();
            logic = new AppointmentLogic(mockAppointmentRepo.Object);
        }

        [Test]
        public void Create_ValidAppointment_CallsRepositoryCreate()
        {
            // Arrange
            var appointment = new Appointment
            {
                Id = "1",
                OwnerId = "user1",
                Time = DateTime.Now,
                Cost = 100,
                FullTime = 60,
                ServicesAsJson = "[{\"ServiceId\": 1, \"ServiceName\": \"Service 1\"}]"
            };

            // Act
            logic.Create(appointment);

            // Assert
            mockAppointmentRepo.Verify(r => r.Create(appointment), Times.Once);
        }

        [Test]
        public void Delete_ValidAppointmentId_CallsRepositoryDelete()
        {
            // Arrange
            var appointmentId = "1";

            // Act
            logic.Delete(appointmentId);

            // Assert
            mockAppointmentRepo.Verify(r => r.Delete(appointmentId), Times.Once);
        }

        [Test]
        public void Read_ValidAppointmentId_ReturnsAppointment()
        {
            // Arrange
            var appointmentId = "1";
            var expectedAppointment = new Appointment
            {
                Id = appointmentId,
                OwnerId = "user1",
                Time = DateTime.Now,
                Cost = 100,
                FullTime = 60,
                ServicesAsJson = "[{\"ServiceId\": 1, \"ServiceName\": \"Service 1\"}]"
            };
            mockAppointmentRepo.Setup(r => r.Read(appointmentId)).Returns(expectedAppointment);

            // Act
            var result = logic.Read(appointmentId);

            // Assert
            Assert.AreEqual(expectedAppointment, result);
        }

        [Test]
        public void ReadAll_ReturnsAllAppointments()
        {
            // Arrange
            var expectedAppointments = new List<Appointment>
            {
                new Appointment
                {
                    Id = "1",
                    OwnerId = "user1",
                    Time = DateTime.Now,
                    Cost = 100,
                    FullTime = 60,
                    ServicesAsJson = "[{\"ServiceId\": 1, \"ServiceName\": \"Service 1\"}]"
                },
                new Appointment
                {
                    Id = "2",
                    OwnerId = "user2",
                    Time = DateTime.Now.AddDays(1),
                    Cost = 200,
                    FullTime = 120,
                    ServicesAsJson = "[{\"ServiceId\": 2, \"ServiceName\": \"Service 2\"}]"
                }
            };
            mockAppointmentRepo.Setup(r => r.ReadAll()).Returns(expectedAppointments.AsQueryable());

            // Act
            var result = logic.ReadAll();

            // Assert
            Assert.AreEqual(expectedAppointments, result);
        }

        [Test]
        public void Update_ValidAppointment_CallsRepositoryUpdate()
        {
            // Arrange
            var appointment = new Appointment
            {
                Id = "1",
                OwnerId = "user1",
                Time = DateTime.Now,
                Cost = 100,
                FullTime = 60,
                ServicesAsJson = "[{\"ServiceId\": 1, \"ServiceName\": \"Service 1\"}]"
            };

            // Act
            logic.Update(appointment);

            // Assert
            mockAppointmentRepo.Verify(r => r.Update(appointment), Times.Once);
        }

    }
}
