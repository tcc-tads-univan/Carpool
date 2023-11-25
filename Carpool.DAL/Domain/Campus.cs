namespace Carpool.DAL.Domain
{
    public class Campus
    {
        public int CampusId { get; set; }
        public String CampusName { get; set; }
        public String LineAddress { get; set; }
        public String Neighborhood { get; set; }
        public String PlaceId { get; set; }
        public String CEP { get; set; }
        public int CollegeId { get; set; }
        public College College { get; set; }
    }
}
