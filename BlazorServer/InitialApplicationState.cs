namespace BlazorServer
{
    public class InitialApplicationState
    {
        public bool IsAuthenticated { get; set; } = false;
        public string? UserName { get; set; }
    }
}
