namespace BlazorScrumAPI
{
    public class EmailSenderService : IEmailSender
    {

        public Task<string> SendEmailAsync(string recipientEmail, string recipientFirstName, string link)
        {
            throw new NotImplementedException();
        }
    }
}
