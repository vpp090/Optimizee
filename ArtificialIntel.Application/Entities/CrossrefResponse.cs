using Newtonsoft.Json;
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
        public string Description { get; set; }

        [JsonProperty("reference-count")]
        public int ReferenceCount { get; set; }

        public string Publisher { get; set; }
        public string DOI { get; set; }

        public string Type { get; set; }
        public DateTime TimeStamp { get; set; }
        public List<string> Title { get; set; }

        public Resource Resource { get; set; }

        public List<Author> Author { get; set; }

        public string URL { get; set; }
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
        public string Sequence { get; set; }
        public List<string> Affiliation { get; set; }
    }
}
