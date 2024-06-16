namespace RealEstate_Dapper_Api.Dtos.PopularLocationDtos
{
	public class ResultPopularLocationDto
	{
        public short LocationId { get; set; }
        public int PropertyCount { get; set; }
        public string CityName { get; set; }
        public string ImageUrl { get; set; }
    }
}
