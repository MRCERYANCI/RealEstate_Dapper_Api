using Dapper;
using RealEstate_Dapper_Api.Dtos.MessageDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.MessageRepositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultInBoxMessageDto>> GetInBoxMessageListReceiver(int id)
        {
            string query = "Select * From Message inner join Users on  Message.Sender = Users.Id Where Receiver = @receiver";
            var paremeters = new DynamicParameters();
            paremeters.Add("@receiver", id);
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultInBoxMessageDto>(query, paremeters);
                return values.ToList();
            }
        }
    }
}
