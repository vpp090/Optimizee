namespace ArtificialIntel.Services.Contracts
{
    public interface IGptService
    {
        Task<object> SendToGpt(string topic);
    }
}
