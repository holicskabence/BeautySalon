using BookingApp.Logic.Classes;
using BookingApp.Models.Models;
using BookingApp.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace BookingApp.Test
{
    [TestFixture]
    public class ServiceLogicTest
    {
        private ServiceLogic logic;
        private Mock<IRepository<Service>> mockServiceRepo;

        [SetUp]
        public void Setup()
        {
            mockServiceRepo = new Mock<IRepository<Service>>();
            logic = new ServiceLogic(mockServiceRepo.Object);
        }

        [Test]
        public void Create_WithValidService_CallsRepositoryCreate()
        {
            // Arrange
            var service = new Service { Id = "1", Name = "Haircut", Cost = 20, Time = 30, Category = "Hair" };

            // Act
            logic.Create(service);

            // Assert
            mockServiceRepo.Verify(r => r.Create(service), Times.Once);
        }

        [Test]
        public void Delete_WithValidId_CallsRepositoryDelete()
        {
            // Arrange
            string serviceId = "1";

            // Act
            logic.Delete(serviceId);

            // Assert
            mockServiceRepo.Verify(r => r.Delete(serviceId), Times.Once);
        }

        [Test]
        public void Read_WithExistingId_ReturnsService()
        {
            // Arrange
            string serviceId = "1";
            var expectedService = new Service { Id = serviceId, Name = "Massage", Cost = 50, Time = 60, Category = "Spa" };
            mockServiceRepo.Setup(r => r.Read(serviceId)).Returns(expectedService);

            // Act
            var result = logic.Read(serviceId);

            // Assert
            Assert.AreEqual(expectedService, result);
        }

        [Test]
        public void Read_WithNonExistingId_ThrowsArgumentException()
        {
            // Arrange
            string serviceId = "1";
            mockServiceRepo.Setup(r => r.Read(serviceId)).Returns((Service)null);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => logic.Read(serviceId));
        }

        [Test]
        public void ReadAll_ReturnsAllServices()
        {
            // Arrange
            var expectedServices = new[]
            {
                new Service { Id = "1", Name = "Haircut", Cost = 20, Time = 30, Category = "Hair" },
                new Service { Id = "2", Name = "Massage", Cost = 50, Time = 60, Category = "Spa" },
                new Service { Id = "3", Name = "Manicure", Cost = 15, Time = 45, Category = "Nails" }
            };
            mockServiceRepo.Setup(r => r.ReadAll()).Returns(expectedServices.AsQueryable());

            // Act
            var result = logic.ReadAll();

            // Assert
            Assert.AreEqual(expectedServices, result);
        }

        [Test]
        public void Update_WithValidService_CallsRepositoryUpdate()
        {
            // Arrange
            var service = new Service { Id = "1", Name = "Haircut", Cost = 25, Time = 30, Category = "Hair" };

            // Act
            logic.Update(service);

            // Assert
            mockServiceRepo.Verify(r => r.Update(service), Times.Once);
        }
    }
}
