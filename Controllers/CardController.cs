using FluentResults;
using memobit.Data.Dto;
using memobit.Models;
using memobit.Services;
using Microsoft.AspNetCore.Mvc;

namespace memobit.Controllers
{
    [ApiController]
    [Route("api/v1/memobit/cards")]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet("card")]
        public IActionResult GetCard()
        {
            IEnumerable<CardDto> cardDto = _cardService.GetCard();

            if (cardDto == null) return NoContent();
            return Ok(cardDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetCardId(int id)
        {
            Card readCard = _cardService.GetCardId(id);

            return Ok(readCard);
        }

        [HttpGet("review/{groupId}")]
        public IActionResult GetReview(int groupId)
        {
            List<Card> cards = _cardService.GetReview(groupId).ToList();

            if (cards == null) return NoContent();
            return Ok(cards);
        }

        [HttpPost("review/{cardId}")]
        public IActionResult PostReview(int cardId, [FromBody] AnswerDto answerDto)
        {
            Result result = _cardService.PostReview(cardId, answerDto);
            
            if (result.IsFailed) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("card")]
        public IActionResult CreateCard([FromBody] CardCreateDto cardDto)
        {
            Card readCard = _cardService.CreateCard(cardDto);

            if (readCard == null) return NoContent();
            return CreatedAtAction(nameof(GetCardId), new { Id = readCard.Id }, readCard);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCard(int id, [FromBody] CardDto cardDto)
        {
            Result result = _cardService.UpdateCard(id, cardDto);

            if (result.IsFailed) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCard(int id)
        {
            Result result = _cardService.DeleteCard(id);

            if (result.IsFailed) return BadRequest();
            return Ok(result);
        }
    }
}
