using BygSpyWebAPI.Models;
using BygSpyWebAPI.Repositories.Interfaces;
using BygSpyWebAPI.Services;
using FluentAssertions;
using Moq;

namespace BygSpyServerTest
{
    public class SpyServiceTest
    {
        [Fact]
        public async Task DeleteSpyAsync_Should_Call_DeleteSpyAsync_On_Repo()
        {
            // Arrange
            var mockRepo = new Mock<ISpyRepository>();
            var spyService = new SpyService(mockRepo.Object);
            var spyId = "htrehtrehtrhrte";

            // Act
            await spyService.DeleteSpyAsync("any-id");

            // Assert
            mockRepo.Verify(repo => repo.DeleteSpyAsync(spyId), Times.Once);
        }

        [Fact]
        public async Task UpdateSpyAsync_Should_Call_UpdateSpyAsync_On_Repo()
        {
            // Arrange
            var mockRepo = new Mock<ISpyRepository>();
            var spyService = new SpyService(mockRepo.Object);
            var spyId = "some-id";
            var updatedSpy = new Spy { Id = spyId, Name = "Updated Spy" };

            // Act
            await spyService.UpdateSpyAsync(spyId, updatedSpy);

            // Assert
            mockRepo.Verify(repo => repo.UpdateSpyAsync(spyId, updatedSpy), Times.Once);
        }

        [Fact]
        public async Task GetAllSpies_Should_Return_List_Of_Spies()
        {
            // Arrange
            var expectedSpies = new List<Spy>
        {
            new Spy { Id = "1", Name = "Spy 1" },
            new Spy { Id = "2", Name = "Spy 2" }
        };
            var mockRepo = new Mock<ISpyRepository>();
            mockRepo.Setup(repo => repo.GetAllSpyAsync()).ReturnsAsync(expectedSpies);

            var spyService = new SpyService(mockRepo.Object);

            // Act
            var result = await spyService.GetAllSpiesAsync();

            // Assert
            result.Should().BeEquivalentTo(expectedSpies);
        }

        [Fact]
        public async Task GetSpyByIdAsync_Should_Return_Spy()
        {
            // Arrange
            var spyId = "some-id";
            var expectedSpy = new Spy { Id = spyId, Name = "Spy" };
            var mockRepo = new Mock<ISpyRepository>();
            mockRepo.Setup(repo => repo.GetSpyByIdAsync(spyId)).ReturnsAsync(expectedSpy);

            var spyService = new SpyService(mockRepo.Object);

            // Act
            var result = await spyService.GetSpyAsync(spyId);

            // Assert
            result.Should().BeEquivalentTo(expectedSpy);
        }

        [Fact]
        public async Task PostSpy_Should_Call_CreateSpyAsync_On_Repo()
        {
            // Arrange
            var newSpy = new Spy { Name = "New Spy" };
            var mockRepo = new Mock<ISpyRepository>();
            mockRepo.Setup(repo => repo.CreateSpyAsync(It.IsAny<Spy>())).Returns(Task.CompletedTask);

            var spyService = new SpyService(mockRepo.Object);

            // Act
            await spyService.CreateSpyAsync(newSpy);

            // Assert
            mockRepo.Verify(repo => repo.CreateSpyAsync(It.Is<Spy>(s => s.Name == "New Spy" && !string.IsNullOrEmpty(s.Id))), Times.Once);
        }


    }
}
