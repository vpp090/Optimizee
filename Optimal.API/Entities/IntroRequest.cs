namespace Optimal.API.Entities
{
    public class IntroRequest
    {
        public string Topic { get; set; }
        public List<string> Questions { get; set; }

        public List<string> KeyWords { get; set; }
    }
}
