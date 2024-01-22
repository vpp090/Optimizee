using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialIntel.Application.Entities
{
    public class CrossrefResponse
    {
        public string Status { get; set; }
        [JsonProperty("message-type")]
        public string MessageType { get; set; }
        public Message Message { get; set; }
    }

    public class Message
    {
        [JsonProperty("total-results")]
        public int Total { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public Indexed Indexed { get; set; }
        public string Description { get; set; }

        [JsonProperty("reference-count")]
        public int ReferenceCount { get; set; }

        public string Publisher { get; set; }
        public string DOI { get; set; }

        public string Type { get; set; }
        public List<string> Title { get; set; }

        public Resource Resource { get; set; }

        [JsonProperty("author")]
        public List<Author> Authors { get; set; }

        public string URL { get; set; }
    }

    public class Indexed
    {
        [JsonProperty("date-time")]
        public DateTime DateTime { get; set; }
    }

    public class Resource
    {
        public Primary Primary { get; set; }
    }

    public class Primary
    {
        public string URL { get; set; }
    }

    public class Author
    {
        public string Name { get; set; }
        public string Given { get; set; }
        public string Family { get; set; }
        public string Sequence { get; set; }
       // public List<string> Affiliation { get; set; }
    }
}
