//using BygSpyWebAPI.Models;
//using BygSpyWebAPI.Repositories;
//using BygSpyWebAPI.Services;
//using FluentAssertions;
//using Moq;

//namespace BygSpyServerTest
//{
//    public class UserServiceTest
//    {
//        private readonly UserService _userService;
//        public UserServiceTest(UserService userService)
//        {
//            _userService = userService;
//        }
//        // Handrolled mock
//        [Fact]
//        public void CreateUser_Should_ReturnNewUser()
//        {
//            // Arrange
//            var user = new User
//            {

//                Name = "John",
//                Email = "john@example.com",
//                Password = "testitestpassword",
//                PhoneNumber = "1234567890"
//            };


//            // Act
//            var newUser = _userService.CreateUserAsync(user);

//            // Assert
//            newUser.Should().Be(user);

//        }


//        [Theory]
//        [InlineData("invalid-email")]
//        [InlineData("missing@symbol")]
//        [InlineData("missing.domain.com")]
//        public async Task CreateUser_WithInvalidEmail_Should_ThrowArgumentExceptionAsync(string invalidEmail)
//        {
//            // Arrange
//            var mockRepository = new Mock<UserRepository>();
//            var userService = new UserService(mockRepository.Object);

//            var userWithInvalidEmail = new User { Id = "", Email = invalidEmail };

//            // Act
//            Func<Task> createUserAction = async () => await userService.CreateUserAsync(userWithInvalidEmail);

//            // Assert
//            await createUserAction.Should().ThrowAsync<ArgumentException>()
//                .WithMessage("Invalid email format.");
//        }

//        [Theory]
//        [InlineData("invalid-email")]
//        [InlineData("missing@symbol")]
//        [InlineData("missing.domain.com")]
//        public async Task CreateUser_WithInvalidEmail_Should_ThrowArgumentException(string invalidEmail)
//        {
//            // Arrange
//            var mockRepository = new Mock<UserRepository>();
//            var userService = new UserService(mockRepository.Object);

//            var userWithInvalidEmail = new User { Id = "", Email = invalidEmail };

//            // Act
//            Func<Task> createUserAction = async () => await userService.CreateUserAsync(userWithInvalidEmail);

//            // Assert
//            await createUserAction.Should().ThrowAsync<ArgumentException>()
//                .WithMessage("Invalid email format.");
//        }

//        [Fact]
//        public void CreateUser_WithExistingEmail_Should_ThrowInvalidOperationException1()
//        {
//            // Arrange
//            var existingUser = new User { Id = "", Name = "JohnJohn", Email = "john@gmail.com", PhoneNumber = "128845678" };

//            // Act & Assert
//            FluentActions.Invoking(() => new User { Id = "", Name = "NotJohn", Email = existingUser.Email })
//                .Should().Throw<InvalidOperationException>()
//                .WithMessage("Email is already registered");
//        }

//        [Fact]
//        public async Task CreateUser_WithValidUser_Should_CreateUserSuccessfully()
//        {
//            // Arrange
//            var mockRepository = new Mock<UserRepository>();
//            var userService = new UserService(mockRepository.Object);

//            var newUser = new User { Id = "", Email = "newuser@example.com", Name = "New User" };

//            mockRepository.Setup(repo => repo.GetUserByEmailAsync(newUser.Email)).ReturnsAsync((User)null); // Simulate no existing user with the same email

//            // Act
//            var createdUser = await userService.CreateUserAsync(newUser);

//            // Assert
//            createdUser.Should().NotBeNull();
//            createdUser.Id.Should().NotBe(Guid.Empty);
//            createdUser.Email.Should().Be(newUser.Email);
//            createdUser.Name.Should().Be(newUser.Name);

//            mockRepository.Verify(repo => repo.CreateUserAsync(newUser), Times.Once);
//        }

//    }
//}