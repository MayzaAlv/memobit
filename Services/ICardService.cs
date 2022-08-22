using FluentResults;
using memobit.Data.Dto;
using memobit.Models;

namespace memobit.Services
{
    public interface ICardService
    {
        IEnumerable<CardDto> GetCard();
        Card GetCardId(int id);
        IEnumerable<Card> GetReview(int groupId);
        Card CreateCard(CardCreateDto cardDto);
        Result PostReview(int cardId, AnswerDto answerDto);
        Result UpdateCard(int id, CardDto cardDto);
        Result DeleteCard(int id);
    }
}
