using OptimalPackage.Requests;

namespace OptimalPackage.Events
{
    public class OptimalEvent : IntegrationBaseEvent
    {
        public OptimalRequest Request { get; set; }
    }
}
