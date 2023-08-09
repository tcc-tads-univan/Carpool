namespace Carpool.DAL.Domain
{
    public class College
    {
        public int CollegeId { get; set; }
        public String CollegeName { get; set; }
        public String Acronym { get; set; }
        public ICollection<Campus> Campi { get; set; }

    }
}
