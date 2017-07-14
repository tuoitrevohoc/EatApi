using System;
namespace EatApi.Services
{

    /// <summary>
    /// The notification
    /// </summary>
    public interface INotification
    {

        /// <summary>
        /// Send a message to user
        /// </summary>
        /// <param name="message">Message.</param>
        void SendMessage(string message);
    }
}
