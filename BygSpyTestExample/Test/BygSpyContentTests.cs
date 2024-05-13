using BygSpyTestExample.Model;
using BygSpyTestExample.Service;
using FluentAssertions;
using System;
using Xunit;

namespace BygSpyTestExample.Tests
{
    public class BygSpyContentTests
    {
        [Fact]
        public void BygSpyContentModel_CreateNotification_Success()
        {
            // Arrange
            var service = new BygSpyContentService();
            var expectedDate = DateTime.Now;

            // Act
            service.AddNotification(new BygSpyContentModel
            {
                Id = 1,
                projectName = "Project1",
                status = "Pending",
                message = "New task added",
                dateIsChecked = expectedDate
            });
            var notification = service.GetNotificationById(1);

            // Assert
            notification.Should().NotBeNull();
            notification.Id.Should().Be(1);
            notification.projectName.Should().Be("Project1");
            notification.status.Should().Be("Pending");
            notification.message.Should().Be("New task added");
            notification.dateIsChecked.Should().Be(expectedDate);
        }

        [Fact]
        public void BygSpyContentService_AddNotification_Success()
        {
            // Arrange
            var service = new BygSpyContentService();
            var notification = new BygSpyContentModel
            {
                Id = 1,
                projectName = "Project1",
                status = "Pending",
                message = "New task added",
                dateIsChecked = DateTime.Now
            };

            // Act
            service.AddNotification(notification);

            // Assert
            // den her er nok ikke relevant da jeg har notificationtest der enlig gør det samme
            var notifications = service.GetNotifications();
            notifications.Should().ContainSingle()
                .Which.Should().BeEquivalentTo(notification);
        }

        [Fact]
        public void BygSpyContentService_UpdateNotification_Success()
        {
            // Arrange
            var service = new BygSpyContentService();
            var notification = new BygSpyContentModel
            {
                Id = 1,
                projectName = "Project1",
                status = "Pending",
                message = "New task added",
                dateIsChecked = DateTime.Now
            };
            service.AddNotification(notification);

            // Act
            service.UpdateNotification(1, "Completed", "Task completed successfully");

            // Assert
            var updatedNotification = service.GetNotificationById(1);
            updatedNotification.Should().NotBeNull();
            updatedNotification.status.Should().Be("Completed");
            updatedNotification.message.Should().Be("Task completed successfully");
            updatedNotification.dateIsChecked.Should().NotBe(notification.dateIsChecked);
        }

        [Fact]
        public void BygSpyContentService_DeleteNotification_Success()
        {
            // Arrange
            var service = new BygSpyContentService();
            var notification = new BygSpyContentModel
            {
                Id = 1,
                projectName = "Project1",
                status = "Pending",
                message = "New task added",
                dateIsChecked = DateTime.Now
            };
            service.AddNotification(notification);

            // Act
            service.DeleteNotification(1);

            // Assert
            var notifications = service.GetNotifications();
            notifications.Should().BeEmpty();
        }

        [Fact]
        public void Notification_HasCorrectStatus()
        {
            // Arrange
            var service = new BygSpyContentService();
            var expectedStatus = "Pending"; // Set the expected status here
            var notification = new BygSpyContentModel
            {
                Id = 1,
                projectName = "Project1",
                status = "Pending",
                message = "New task added",
                dateIsChecked = DateTime.Now
            };
            service.AddNotification(notification);

            // Act
            var retrievedNotification = service.GetNotificationById(notification.Id);

            // Assert
            retrievedNotification.Should().NotBeNull();
            retrievedNotification.status.Should().Be(expectedStatus);
        }

        [Fact]
        public void Notification_HasCorrectDate()
        {
            // Arrange
            var service = new BygSpyContentService();
            var expectedDate = DateTime.Now.Date; // Set the expected date here
            var notification = new BygSpyContentModel
            {
                Id = 1,
                projectName = "Project1",
                status = "Pending",
                message = "New task added",
                dateIsChecked = DateTime.Now // Use DateTime.Now or a specific date
            };
            service.AddNotification(notification);

            // Act
            var retrievedNotification = service.GetNotificationById(notification.Id);

            // Assert
            retrievedNotification.Should().NotBeNull();
            retrievedNotification.dateIsChecked.Date.Should().Be(expectedDate);
        }
    }
}
