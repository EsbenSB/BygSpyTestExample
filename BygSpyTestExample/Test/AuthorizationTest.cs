using BygSpyTestExample.Model;
using BygSpyTestExample.Services;
using FluentAssertions;
using Xunit;

namespace BygSpyTestExample.Test
{
    public class AuthorizationTest
    {
        [Fact]
        public void AdminShouldHaveAccess()
        {
            // Arrange
            var authService = new AuthorizationService();
            var user = new UserModel { Role = RoleType.Admin };

            // Act
            bool hasAccess = authService.CheckAccess(user);

            // Assert
            hasAccess.Should().BeTrue();
        }

        [Fact]
        public void ModeratorShouldHaveAccess()
        {
            // Arrange
            var authService = new AuthorizationService();
            var user = new UserModel { Role = RoleType.Moderator };

            // Act
            bool hasAccess = authService.CheckAccess(user);

            // Assert
            hasAccess.Should().BeTrue();
        }

        [Fact]
        public void UserShouldNotHaveAdminAccess()
        {
            // Arrange
            var authService = new AuthorizationService();
            var user = new UserModel { Role = RoleType.User };

            // Act
            bool hasAccess = authService.CheckAccess(user);

            // Assert
            hasAccess.Should().BeFalse();
        }

        [Fact]
        public void GuestShouldHaveLimitedAccess()
        {
            // Arrange
            var authService = new AuthorizationService();
            var user = new UserModel { Role = RoleType.Guest };

            // Act
            bool hasAccess = authService.CheckAccess(user);

            // Assert
            hasAccess.Should().BeTrue();
        }
    }
}
