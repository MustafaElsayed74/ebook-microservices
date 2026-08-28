namespace Order.Api.Entities
{
    public class DeliviryMethod : BaseEntity
    {
        public DeliviryMethod()
        {
            
        }
        public DeliviryMethod(string shortName, string devileryTime, string description, decimal cost)
        {
            ShortName = shortName;
            DevileryTime = devileryTime;
            Description = description;
            Cost = cost;
        }
        
        public string ShortName { get; set; }
        public string DevileryTime { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
    }
}