using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            string query = "insert into Product(ProductTitle,ProductPrice,ProductCoverImage,ProductCity,ProductDistrict,ProductAdress,ProductType,ProductDescription,ProductCategory,EmployeeID,DealOfTheDay,Status) values(@productTitle,@productPrice,@productCoverImage,@productCity,@productDistrict,@productAdress,@productType,@productDescription,@productCategory,@employeeID,@dealOfTheDay,@status)";
            var paremeters = new DynamicParameters();
            paremeters.Add("@productTitle", createProductDto.ProductTitle);
            paremeters.Add("@productPrice", createProductDto.ProductPrice);
            paremeters.Add("@productCoverImage", createProductDto.ProductCoverImage);
            paremeters.Add("@productCity", createProductDto.ProductCity);
            paremeters.Add("@productDistrict", createProductDto.ProductDistrict);
            paremeters.Add("@productAdress", createProductDto.ProductAdress);
            paremeters.Add("@productType", createProductDto.ProductType);
            paremeters.Add("@productDescription", createProductDto.ProductDescription);
            paremeters.Add("@productCategory", createProductDto.ProductCategory);
            paremeters.Add("@employeeID", createProductDto.EmployeeID);
            paremeters.Add("@dealOfTheDay", createProductDto.DealOfTheDay);
            paremeters.Add("@status", createProductDto.Status);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paremeters);
            }
        }

        public async Task<List<ResultProductAndProductDetailDto>> GetAllProductAndProductDetailsAsync()
        {
            string query = "Select Product.SlugUrl,Users.Name,Users.Surname,Users.Image,Product.ProductID,Product.ProductAdress,Product.ProductPrice,Product.ProductTitle,Product.ProductCoverImage,Product.ProductType,Category.CategoryName,ProductDetails.ProductSize,ProductDetails.BathCount,ProductDetails.BedRoomCount,ProductDetails.RoomCount From Product inner join ProductDetails On Product.ProductID = ProductDetails.ProductID inner join Category On Product.ProductCategory = Category.CategoryId inner join Users On Product.UserId = Users.Id Order By Product.ProductID desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAndProductDetailDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * From Product";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "Select product.ProductID,product.ProductTitle,product.ProductPrice,product.ProductCity,product.ProductDistrict,product.ProductAdress,product.ProductDescription,product.ProductCoverImage,product.ProductType,category.CategoryName,Product.DealOfTheDay " +
                "From Product product inner join Category category on product.ProductCategory=category.CategoryId";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast3ProductWithCategoryDto>> GetLast3ProductAsync()
        {
            string query = "SELECT TOP(3) product.CreateDate,product.ProductID,product.ProductTitle,product.ProductPrice,product.ProductCity,product.ProductDistrict,category.CategoryName FROM Product inner join Category ON Product.ProductCategory = Category.CategoryId ORDER BY product.CreateDate DESC ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast3ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = "SELECT TOP(5) product.ProductID,product.ProductTitle,product.ProductPrice,product.ProductCity,product.ProductDistrict,category.CategoryName FROM Product inner join Category ON Product.ProductCategory = Category.CategoryId WHERE ProductType = 'Kiralık' ORDER BY ProductID DESC ";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductByDealOfTheDayTrueWithCategoryAsync()
        {
            string query = "Select product.ProductID,product.ProductTitle,product.ProductPrice,product.ProductCity,product.ProductDistrict,product.ProductAdress,product.ProductDescription,product.ProductCoverImage,product.ProductType,category.CategoryName,Product.DealOfTheDay " +
                "From Product product inner join Category category on product.ProductCategory=category.CategoryId Where product.DealOfTheDay = 1";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetProductByProductIdDto> GetProductByProductIdAsync(int id)
        {
            string query = "Select Product.SlugUrl,ProductDetails.VideoUrl,ProductDetails.Location,ProductDetails.GarageSize,ProductDetails.BuildYear,Users.Id As 'UserId',Users.Name,Users.Surname,Users.Image,Users.PhoneNumber,Users.Email,Product.ProductID,Product.ProductDescription,Product.CreateDate,Product.ProductAdress,Convert(varchar(15),Cast(Product.ProductPrice as money),1) as 'ProductPrice',Product.ProductTitle,Product.ProductCoverImage,Product.ProductType,Category.CategoryName,ProductDetails.ProductSize,ProductDetails.BathCount,ProductDetails.BedRoomCount,ProductDetails.RoomCount From Product inner join ProductDetails On Product.ProductID = ProductDetails.ProductID inner join Category On Product.ProductCategory = Category.CategoryId inner join Users On Product.UserId = Users.Id Where Product.ProductId = @productId Order By Product.ProductID desc";
            var paremeters = new DynamicParameters();
            paremeters.Add("@productId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetProductByProductIdDto>(query,paremeters);
                return values;
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> ProductAdvertsListByFalseEmployeId(int EmployeeId)
        {
            string query = "Select product.ProductID,product.ProductTitle,product.ProductPrice,product.ProductCity,product.ProductDistrict,product.ProductAdress,product.ProductDescription,product.ProductCoverImage,product.ProductType,category.CategoryName,Product.DealOfTheDay From Product product inner join Category category on product.ProductCategory=category.CategoryId Where EmployeeID = @employeeID AND Status = @status";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", EmployeeId);
            parameters.Add("@status", false);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> ProductAdvertsListByTrueEmployeId(int EmployeeId)
        {
            string query = "Select product.ProductID,product.ProductTitle,product.ProductPrice,product.ProductCity,product.ProductDistrict,product.ProductAdress,product.ProductDescription,product.ProductCoverImage,product.ProductType,category.CategoryName,Product.DealOfTheDay From Product product inner join Category category on product.ProductCategory=category.CategoryId Where EmployeeID = @employeeID AND Status = @status";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", EmployeeId);
            parameters.Add("@status", true);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query, parameters);
                return values.ToList();
            }
        }

        public async void ProductDealOfTheDayStatusChangeTo(int ProductId, bool ProductStatus)
		{
            string Query = "Update Product Set DealOfTheDay=@status Where ProductId=@productıd";
            var parameters = new DynamicParameters();
            parameters.Add("@status", ProductStatus);
            parameters.Add("@productıd", ProductId);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(Query, parameters);
            }
		}

        public async Task<List<ResultLast3ProductDto>> ResultLast3ProductAsync(int id)
        {
            string query = "Select top 3 SlugUrl,ProductId,ProductCoverImage,ProductTitle,CreateDate From Product Where UserId = @userId Order by CreateDate Desc";
            var paremeters = new DynamicParameters();
            paremeters.Add("@userId", id);
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast3ProductDto>(query, paremeters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchListAsync(string searchKeyValue, int propertyCategoryId, string city)
        {
            string query = "Select Users.Name,Users.Surname,Users.Image,Product.ProductID,Product.ProductAdress,Product.ProductPrice,Product.ProductTitle,Product.ProductCoverImage,Product.ProductType,Category.CategoryName,ProductDetails.ProductSize,ProductDetails.BathCount,ProductDetails.BedRoomCount,ProductDetails.RoomCount From Product inner join ProductDetails On Product.ProductID = ProductDetails.ProductID inner join Category On Product.ProductCategory = Category.CategoryId inner join Users On Product.UserId = Users.Id Where Product.ProductTitle Like '%"+searchKeyValue+"%' And Product.ProductCategory = @productCategory And Product.ProductCity = @productCity";
            var parameters = new DynamicParameters();
            parameters.Add("@productCategory", propertyCategoryId);
            parameters.Add("@productCity", city);
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithSearchListDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}
