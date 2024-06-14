namespace RealEstate_Dapper_Api.Dtos.ProductDtos
{
    public class GetProductByProductIdDto
    {
        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public DateTime CreateDate { get; set; }
        public string ProductAdress { get; set; }
        public string ProductDescription { get; set; }
        public string ProductTitle { get; set; }
        public string ProductCoverImage { get; set; }
        public string ProductType { get; set; }
        public string CategoryName { get; set; }
        public int ProductSize { get; set; }
        public byte BedRoomCount { get; set; }
        public byte BathCount { get; set; }
        public byte RoomCount { get; set; }
    }
}
