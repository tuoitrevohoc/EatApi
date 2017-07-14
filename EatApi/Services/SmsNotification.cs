using System;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace EatApi.Services
{

    /// <summary>
    /// Send sms notification
    /// </summary>
    public class SmsNotification: INotification
    {

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="message">Message.</param>
        public void SendMessage(string message)
        {
            
        }
    }
}
