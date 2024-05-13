//using BygSpyTestExample.Model;
//using BygSpyTestExample.Services;
//using FluentAssertions;
//using Xunit;
//cdswacwqcwqcwq
//namespace BygSpyTestExample.Test
//{
//    public class NotificationTest
//    {
//        [Fact]
//        public void SendNotification_AddsNotificationToList()
//        {
//            // Arrange
//            var notificationService = new NotificationService();
//            string message = "This is a test notification";

//            // Act
//            notificationService.SendNotification(message);
//            var notifications = notificationService.GetNotifications();

//            // Assert
//            notifications.Should().ContainSingle()
//                .Which.Message.Should().Be(message);
//        }

//        [Fact]
//        public void GetNotifications_ReturnsCorrectNotifications()
//        {
//            // Arrange
//            var notificationService = new NotificationService();
//            string message1 = "Message 1";
//            string message2 = "Message 2";

//            // Act
//            notificationService.SendNotification(message1);
//            notificationService.SendNotification(message2);
//            var notifications = notificationService.GetNotifications();

//            // Assert
//            notifications.Should().HaveCount(2);
//            notifications[0].Message.Should().Be(message1);
//            notifications[1].Message.Should().Be(message2);
//        }
//    }
//}
