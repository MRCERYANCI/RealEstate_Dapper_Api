namespace RealEstate_Dapper_Api.Dtos.ServiceDtos
{
	public class GetByIdServiceDto
	{
		public byte ServiceId { get; set; }
		public string ServiceName { get; set; }
		public bool ServiceStatus { get; set; }
	}
}
