namespace RSB_Ofish_System.Models.DataBaseModels
{
    public class Staff
    {
        public int Id { get; set; }
        public string  firstName { get; set; }
        public  string sureName{ get; set; }
        public string FullName => firstName + " " + sureName;
        public Sexual sexual { get; set; }
        public int OfficeId { get; set; }
        public virtual Office  Office { get; set; }

    }
}
