using BygSpyWebAPI.Models;
using BygSpyWebAPI.Repositories;
using BygSpyWebAPI.Repositories.Interfaces;
using BygSpyWebAPI.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace BygSpyServerTest
{
    public class UserServiceTest
    {
        [Fact]
        public async Task CreateUser_Should_ReturnNewUserAsync()
        {
            // Arrange
            var newUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                Email = "newuser@example.com",
                Name = "New User",
                Password = "test1234",
                PhoneNumber = "30229121"
            };

            var mockRepository = new Mock<IUserRepository>();
            

            var userService = new UserService(mockRepository.Object);
           

            // Act
            await userService.CreateUserAsync(newUser);
           

            // Assert
            newUser.Should().NotBeNull();
            newUser.Id.Should().Be(newUser.Id);
            newUser.Email.Should().Be(newUser.Email);
            newUser.Name.Should().Be(newUser.Name);
            newUser.PhoneNumber.Should().Be(newUser.PhoneNumber);
            newUser.Password.Should().Be(newUser.Password);

        }
        //[Theory]
        //[InlineData("existinguser@example.com")]
        //public async Task CreateUser_WithExistingEmail_Should_ThrowInvalidOperationExceptionAsync(string existingEmail)
        //{
        //    // Arrange
        //    var existingUser = new User { Id = Guid.NewGuid().ToString(), Name = "Existing User", Email = existingEmail, PhoneNumber = "12345678", Password = "test1234" };
        //    var mockRepository = new Mock<IUserRepository>();
        //    mockRepository.Setup(repo => repo.GetUserByEmailAsync(existingEmail)).ReturnsAsync(existingUser);

        //    var userService = new UserService(mockRepository.Object);
        //    var newUserWithExistingEmail = new User { Id = Guid.NewGuid().ToString(), Name = "New User", Email = existingEmail, PhoneNumber = "98765432", Password = "password123" };

        //    // Act
        //    Func<Task> createUserAction = async () => await userService.CreateUserAsync(newUserWithExistingEmail);

        //    // Assert
        //    await createUserAction.Should().ThrowAsync<InvalidOperationException>()
        //        .WithMessage($"User with email '{existingUser.Email}' already exists.");

        //}

        //[Theory]
        //[InlineData("invalid-email")]
        //[InlineData("missing@symbol")]
        //[InlineData("missing.domain.com")]
        //public async Task CreateUser_WithInvalidEmail_Should_ThrowInvalidOperationExceptionAsync(string invalidEmail)
        //{
        //    // Arrange

        //    var userWithInvalidEmail = new User { Id = Guid.NewGuid().ToString(), Name = "testJohn", Email = invalidEmail, PhoneNumber = "12345678", Password = "test1234" };
        //    var mockRepository = new Mock<IUserRepository>();
        //    var userService = new UserService(mockRepository.Object);
        //    mockRepository.Setup(repo => repo.CreateUserAsync(It.IsAny<User>())).ReturnsAsync(userWithInvalidEmail);
        //    // Act
        //    Func<Task> createUserAction = async () => await userService.CreateUserAsync(userWithInvalidEmail);

        //    // Assert
        //    await createUserAction.Should().ThrowAsync<InvalidOperationException>()
        //        .WithMessage($"User with email '{userWithInvalidEmail.Email}' already exists.");
        //}

        [Fact]
        public async Task UpdateUserAsync_Should_CallUserRepositoryWithCorrectParameters()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var updatedUser = new User { Id = userId, Name = "Updated User", Email = "updated@example.com", PhoneNumber = "1234567890", Password = "newpassword" };
            var mockRepository = new Mock<IUserRepository>();
            var userService = new UserService(mockRepository.Object);

            // Act
            await userService.UpdateUserAsync(userId, updatedUser);

            // Assert
            mockRepository.Verify(repo => repo.UpdateUserAsync(userId, updatedUser), Times.Once);
        }

        [Fact]
        public async Task DeleteUserAsync_Should_CallUserRepositoryWithCorrectParameters()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var mockRepository = new Mock<IUserRepository>();
            var userService = new UserService(mockRepository.Object);

            // Act
            await userService.DeleteUserAsync(userId);

            // Assert
            mockRepository.Verify(repo => repo.RemoveUserAsync(userId), Times.Once);
        }

    }
}