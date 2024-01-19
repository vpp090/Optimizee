namespace OptimalPackage.Models
{
    public class CrossrefRequest
    {
        public List<string> SubTopics {get; set;}
        public int Rows { get; set;}
        public int Offset { get; set; }

        public string RequestId { get; set; }
    }
}
