namespace RealEstate_Dapper_UI.Dtos.ServicesDtos
{
	public class UpdateServiceDto
	{
		public byte ServiceId { get; set; }
		public string ServiceName { get; set; }
		public bool ServiceStatus { get; set; }
	}
}
