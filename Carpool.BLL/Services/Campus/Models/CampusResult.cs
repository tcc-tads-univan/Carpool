namespace Carpool.BLL.Services.Campus.Models
{
    public class CampusResult
    {
        public int CampusId { get; set; }
        public String CampusName { get; set; }
        public String LineAddress { get; set; }
        public String Neighborhood { get; set; }
        public String PlaceId { get; set; }
        public String CEP { get; set; }
        public CollegeResult College { get; set; }
    }
    public class CollegeResult
    {
        public String CollegeName { get; set; }
        public String Acronym { get; set; }
    }
}
