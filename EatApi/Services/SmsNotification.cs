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
            try
            {
                MessageResource.Create(
                        to: new PhoneNumber("+6591442622"), // To number, if using Sandbox see note above
                        body: message);
            } 
            catch (Exception exception) 
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
