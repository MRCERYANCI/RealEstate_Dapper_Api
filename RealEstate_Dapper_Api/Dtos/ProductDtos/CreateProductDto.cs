namespace RealEstate_Dapper_Api.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductTitle { get; set; }
        public int ProductPrice { get; set; }
        public string ProductCoverImage { get; set; }
        public string ProductCity { get; set; }
        public string ProductDistrict { get; set; }
        public string ProductAdress { get; set; }
        public string ProductType { get; set; }
        public string ProductDescription { get; set; }
        public byte ProductCategory { get; set; }
        public int EmployeeID { get; set; }
        public bool DealOfTheDay { get; set; }
        public bool Status { get; set; }
    }
}
