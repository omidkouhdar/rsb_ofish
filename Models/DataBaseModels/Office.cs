using System.Collections.Generic;

namespace RSB_Ofish_System.Models.DataBaseModels
{
    public class Office
    {
        public Office()
        {
            this.Ofishes = new List<Ofish>();
            this.Staffs = new List<Staff>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ofish> Ofishes { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }

    }
}
