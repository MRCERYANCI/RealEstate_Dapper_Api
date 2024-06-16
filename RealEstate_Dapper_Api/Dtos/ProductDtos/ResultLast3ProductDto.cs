namespace RealEstate_Dapper_Api.Dtos.ProductDtos
{
    public class ResultLast3ProductDto
    {
        public int ProductId { get; set; }
        public string ProductCoverImage { get; set; }
        public string SlugUrl { get; set; }
        public string ProductTitle { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
