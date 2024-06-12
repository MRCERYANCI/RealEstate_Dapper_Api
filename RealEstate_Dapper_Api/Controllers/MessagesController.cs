using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.MessageRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet("GetInBoxMessageListReceiver/{id}")]
        public async Task<IActionResult> GetInBoxMessageListReceiver(int id)
        {
            return Ok(await _messageRepository.GetInBoxMessageListReceiver(id));
        }
    }
}
