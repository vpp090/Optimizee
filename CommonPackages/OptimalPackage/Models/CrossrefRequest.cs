namespace OptimalPackage.Models
{
    public class CrossrefRequest
    {
        public List<string> SubTopics {get; set;}
        public int Rows { get; set;}
        public int Offset { get; set; }

        public string RequestId { get; set; }

        public override string ToString()
        {
            var result = "";

            foreach (var t in SubTopics)
            {
                result += t.ToString() + "_";
            }

            result += Rows.ToString() + "_" + Offset.ToString() + "_" + RequestId.ToString();

            return result;
        }
    }
}
