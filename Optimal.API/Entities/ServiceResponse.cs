namespace Optimal.API.Entities
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public Exception  Error { get; set;} 
    }
}
