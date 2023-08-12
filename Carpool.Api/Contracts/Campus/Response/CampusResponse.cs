namespace Carpool.Api.Contracts.Campus.Response
{
    public class CampusResponse
    {
        public int CampusId { get; set; }
        public String CampusName { get; set; }
        public String CompleteLineAddress { get; set; }
        public CollegeResult College { get; set; }
    }
    public class CollegeResult
    {
        public String Name { get; set; }
        public String Acronym { get; set; }
    }
    
}
