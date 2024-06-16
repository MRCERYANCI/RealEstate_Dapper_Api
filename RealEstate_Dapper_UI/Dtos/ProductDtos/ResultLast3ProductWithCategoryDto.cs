namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class ResultLast3ProductWithCategoryDto
    {
        public int ProductID { get; set; }
        public string ProductTitle { get; set; }
        public string ProductCoverImage { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCity { get; set; }
        public DateTime CreateDate { get; set; }
        public string ProductDistrict { get; set; }
        public string CategoryName { get; set; }
    }
}
