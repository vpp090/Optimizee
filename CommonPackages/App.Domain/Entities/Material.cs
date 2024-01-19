namespace App.Domain.Entities
{
    public class Material : BaseEntity
    {
        public string Publisher { get; set; }
        public string Type { get; set; }

        public string DOI { get; set; }
        public int ReferenceCount { get; set; }

    }
}
