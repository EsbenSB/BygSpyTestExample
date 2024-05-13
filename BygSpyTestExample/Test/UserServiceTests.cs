//using BygSpyTestExample.Model;
//using BygSpyTestExample.Services;
//using FluentAssertions;
//using Xunit;

//namespace BygSpyTestExample
//{
//    public class UserServiceTests
//    {
//        [Fact]
//        public void CreateUser_AddsUserToList()
//        {
//            //Arrange
//           var userService = new UserService();
//            var newUser = new UserModel
//            {
//                Id = 1,
//                username = "testuser",
//                password = "password",
//                Role = RoleType.User
//            };
//            //Act
//            userService.CreateUser(newUser);
//            var createdUser = userService.GetUserById(newUser.Id);           
//            var createdUser = "1";
//            var test = "1";
//            createdUser.Should().Be(test);

//            //Assert
//            createdUser.Should().NotBeNull();
//            createdUser.Should().BeEquivalentTo(newUser);
//        }

//        [Fact]
//        public void UpdateUser_UpdatesUserDetails()
//        {
//            // Arrange
//            var userService = new UserService();
//            var userToUpdate = new UserModel
//            {
//                Id = 2,
//                username = "oldusername",
//                password = "oldpassword",
//                Role = RoleType.User
//            };
//            userService.CreateUser(userToUpdate);
//            var updatedUserDetails = new UserModel
//            {
//                Id = 2,
//                username = "newusername",
//                password = "newpassword",
//                Role = RoleType.Admin
//            };

//            // Act
//            userService.UpdateUser(updatedUserDetails);
//            var updatedUser = userService.GetUserById(userToUpdate.Id);

//            // Assert
//            updatedUser.Should().NotBeNull();
//            updatedUser.Should().BeEquivalentTo(updatedUserDetails);
//        }

//        [Fact]
//        public void DeleteUser_RemovesUserFromList()
//        {
//            // Arrange
//            var userService = new UserService();
//            var userToDelete = new UserModel
//            {
//                Id = 3,
//                username = "todeleteuser",
//                password = "password",
//                Role = RoleType.User
//            };
//            userService.CreateUser(userToDelete);

//            // Act
//            userService.DeleteUser(userToDelete.Id);
//            var deletedUser = userService.GetUserById(userToDelete.Id);

//            // Assert
//            //overvejer om det er mere relevant og tjekke for et response 200
//            deletedUser.Should().BeNull();
//        }

//        [Fact]
//        public void Login_ReturnsUserIfCredentialsAreCorrect()
//        {
//            // Arrange
//            var userService = new UserService();
//            var user = new UserModel
//            {
//                Id = 4,
//                username = "testuser",
//                password = "password",
//                Role = RoleType.User
//            };
//            userService.CreateUser(user);

//            // Act
//            var loggedInUser = userService.Login(user.username, user.password);

//            // Assert
//            //burde jeg tjekke om det er 200 her os?
//            loggedInUser.Should().NotBeNull();
//            loggedInUser.Should().BeEquivalentTo(user);
//        }

//        [Fact]
//        public void Login_ReturnsNullIfCredentialsAreIncorrect()
//        {
//            // Arrange
//            var userService = new UserService();
//            var user = new UserModel
//            {
//                Id = 5,
//                username = "testuser",
//                password = "password",
//                Role = RoleType.User
//            };
//            userService.CreateUser(user);

//            // Act
//            var loggedInUser = userService.Login("testuser", "wrongpassword");

//            // Assert
//            //burde vær error jeg tjekker efter
//            loggedInUser.Should().BeNull();
//        }
//    }
//}
