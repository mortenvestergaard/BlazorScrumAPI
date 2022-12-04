namespace BlazorScrumAPI.BusinessModels
{
    //Business model to send to the Blazor site without EF mapping properties so its easier for the website to handle calls
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
