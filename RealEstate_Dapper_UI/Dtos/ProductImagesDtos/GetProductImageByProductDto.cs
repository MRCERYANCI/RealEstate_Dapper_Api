﻿namespace RealEstate_Dapper_UI.Dtos.ProductImagesDtos
{
    public class GetProductImageByProductDto
    {
        public int ProductImageId { get; set; }
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }
    }
}
