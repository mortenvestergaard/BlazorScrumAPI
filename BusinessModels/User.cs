namespace BlazorScrumAPI.BusinessModels
{
    //Business model to send to the Blazor site without EF mapping properties so its easier for the website to handle calls
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
