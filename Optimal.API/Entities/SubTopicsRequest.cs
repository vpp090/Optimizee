﻿namespace Optimal.API.Entities
{
    public class SubTopicsRequest
    {
        public List<string> SubTopics { get; set; }
        public int Rows { get; set; }
        public int Offset { get; set; }
    }
}