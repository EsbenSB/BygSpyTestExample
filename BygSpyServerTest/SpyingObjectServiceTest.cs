﻿using BygSpyWebAPI.Models;
using BygSpyWebAPI.Repositories.Interfaces;
using BygSpyWebAPI.Services;
using BygSpyWebAPI.Services.Interfaces;
using FluentAssertions;
using MongoDB.Bson;
using Moq;
using Moq.Protected;
using System.Net;

namespace BygSpyServerTest
{
    public class SpyingObjectServiceTest
    {
        [Fact]
        public async Task GetAddressId_Should_Return_SpyingObjectTempEntity_When_Successful()
        {
            // Arrange
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("[{\"id\": \"123\", \"adgangsadresse\": { \"vejstykke\": { \"navn\": \"Street\" }, \"postnummer\": { \"navn\": \"City\" }}}]")
            };

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(mockResponse);

            var httpClient = new HttpClient(handlerMock.Object);
            var service = new SpyingObjectService(httpClient, null);

            // Act
            var result = await service.GetAddressIdAsync("some address");

            // Assert
            result.Should().NotBeNull();
            result.AddressId.Should().Be("123");
            result.Street.Should().Be("Street");
            result.City.Should().Be("City");
        }

        [Fact]
        public async Task GetJordstykkeFromAddressId_Should_Return_Jordstykke_When_Successful()
        {
            // Arrange
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("[{\"husnummer\": { \"jordstykke\": \"some-jordstykke\" }}]")
            };

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(mockResponse);

            var httpClient = new HttpClient(handlerMock.Object);
            var service = new SpyingObjectService(httpClient, null);

            // Act
            var result = await service.GetJordstykkeFromAddressIdAsync("some-address-id");

            // Assert
            result.Should().Be("some-jordstykke");
        }

        [Fact]
        public async Task GetBfeFromJordstykke_Should_Return_BfeNummer_When_Successful()
        {
            // Arrange
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("[{\"bestemtFastEjendom\": { \"bfeNummer\": \"123\" }}]")
            };

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(mockResponse);

            var httpClient = new HttpClient(handlerMock.Object);
            var service = new SpyingObjectService(httpClient, null);

            // Act
            var result = await service.GetBfeFromJordstykkeAsync("some-jordstykke");

            // Assert
            result.Should().Be(123);
        }

        [Fact]
        public async Task GetGrundFromBfe_Should_Return_Status_When_Successful()
        {
            // Arrange
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("[{\"status\": 1}]")
            };

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(mockResponse);

            var httpClient = new HttpClient(handlerMock.Object);
            var service = new SpyingObjectService(httpClient, null);

            // Act
            var result = await service.GetGrundFromBfeAsync(123);

            // Assert
            result.Should().Be(1);
        }

        [Fact]
        public async Task PostSpyingObject_Should_Call_CreateSpyingObjectAsync_On_Repo()
        {
            // Arrange
            var mockRepo = new Mock<ISpyingObjectRepository>();
            mockRepo.Setup(repo => repo.CreateSpyingObjectAsync(It.IsAny<SpyingObject>())).Returns(Task.CompletedTask);

            var service = new SpyingObjectService(null, mockRepo.Object);
            var newSpyObject = new SpyingObject { Id = ObjectId.GenerateNewId().ToString(), Street = "Vejlevej 22" };

            // Act
            await service.CreateSpyObjectAsync(newSpyObject);

            // Assert
            mockRepo.Verify(repo => repo.CreateSpyingObjectAsync(It.Is<SpyingObject>(s => s.Id == newSpyObject.Id)), Times.Once);
        }

        [Fact]
        public async Task DeleteSpyingObject_Should_Call_DeleteSpyingObjectAsync_On_Repo()
        {
            // Arrange
            var mockRepo = new Mock<ISpyingObjectRepository>();
            mockRepo.Setup(repo => repo.DeleteSpyingObjectAsync(It.IsAny<string>())).Returns(Task.CompletedTask);

            var service = new SpyingObjectService(null, mockRepo.Object);
            var bfe = "some-bfe";

            // Act
            await service.DeleteSpyingObjectAsync(bfe);

            // Assert
            mockRepo.Verify(repo => repo.DeleteSpyingObjectAsync(bfe), Times.Once);
        }

        [Fact]
        public async Task GetAllSpyingObjectAsync_Should_Return_List_Of_SpyingObjects()
        {
            // Arrange
            var expectedSpyingObjects = new List<SpyingObject>
        {
            new SpyingObject { Id = ObjectId.GenerateNewId().ToString(), Street = "Vejlevej 22" },
            new SpyingObject { Id = ObjectId.GenerateNewId().ToString(), Street = "Vejlevej 23" }
        };

            var mockRepo = new Mock<ISpyingObjectRepository>();
            mockRepo.Setup(repo => repo.GetAllSpyingObjectsAsync()).ReturnsAsync(expectedSpyingObjects);

            var service = new SpyingObjectService(null, mockRepo.Object);

            // Act
            var result = await service.GetAllSpyingObjectAsync();

            // Assert
            result.Should().BeEquivalentTo(expectedSpyingObjects);
        }

        [Fact]
        public async Task GetSpyingObjectByIdAsync_Should_Return_SpyingObject()
        {
            // Arrange
            var spyId = ObjectId.GenerateNewId().ToString();
            var expectedSpyObject = new SpyingObject { Id = spyId, Street = "Vejlevej 24" };

            var mockRepo = new Mock<ISpyingObjectRepository>();
            mockRepo.Setup(repo => repo.GetSpyingObjectAsync(spyId.ToString())).ReturnsAsync(expectedSpyObject);

            var service = new SpyingObjectService(null, mockRepo.Object);

            // Act
            var result = await service.GetSpyingObjectByIdAsync(spyId.ToString());

            // Assert
            result.Should().BeEquivalentTo(expectedSpyObject);
        }

        [Fact]
        public async Task UpdateSpyingObjectAsync_Should_Call_UpdateSpyingObjectAsync_On_Repo()
        {
            // Arrange
            var mockRepo = new Mock<ISpyingObjectRepository>();
            mockRepo.Setup(repo => repo.UpdateSpyingObjectAsync(It.IsAny<string>(), It.IsAny<SpyingObject>())).Returns(Task.CompletedTask);

            var service = new SpyingObjectService(null, mockRepo.Object);
            var spyId = ObjectId.GenerateNewId().ToString();
            var updatedSpyObject = new SpyingObject { Id = spyId, Street = "Vejlevej 22" };

            // Act
            await service.UpdateSpyingObjectAsync(spyId.ToString(), updatedSpyObject);

            // Assert
            mockRepo.Verify(repo => repo.UpdateSpyingObjectAsync(spyId.ToString(), updatedSpyObject), Times.Once);
        }

        [Fact]
        public async Task MapToSpyingObject_Should_Return_Updated_SpyingObject()
        {
            // Arrange
            var tempEntity = new SpyingObjectTempEntity { City = "City", Street = "Street" };
            var spyObject = new SpyingObject();

            var service = new SpyingObjectService(null, null);

            // Act
            var result = await service.MapToSpyingObjectAsync(tempEntity, spyObject);

            // Assert
            result.Should().NotBeNull();
            result.City.Should().Be("City");
            result.Street.Should().Be("Street");
        }
    }
}