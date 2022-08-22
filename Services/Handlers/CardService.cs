using AutoMapper;
using FluentResults;
using memobit.Data;
using memobit.Data.Dto;
using memobit.Models;

namespace memobit.Services.Handlers
{
    public class CardService : ICardService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CardService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<CardDto> GetCard()
        {
            return _mapper.Map<IEnumerable<CardDto>>(_context.Cards.ToList());
        }

        public Card GetCardId(int id)
        {
            try
            {
                return _context.Cards.First(card => card.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Card> GetReview(int groupId)
        {
            try
            {
                List<Card> cards = _context.Cards.Where(c => c.Group.Id == groupId).ToList();
                List<Card> reviewCards = new List<Card>();

                foreach (Card card in cards)
                {
                    DateTime reviewDate = card.LastAnswerDate.AddDays(card.DaysNextAnswer);
                    if (reviewDate.Date == DateTime.Today.Date)
                    {
                        reviewCards.Add(card);
                    }
                }
                return reviewCards;
            } 
            catch
            {
                return null;
            }
        }

        public Result PostReview(int cardId, AnswerDto answerDto)
        {
            try
            {
                Answer answer = _mapper.Map<Answer>(answerDto);
                Card card = _context.Cards.First(card => card.Id == cardId);
                int days = DateTime.Now.Subtract(card.LastAnswerDate).Days;

                card.LastAnswerDate = DateTime.Now;
                card.DaysNextAnswer = (int)Math.Pow(5, (int)answerDto.status);
                card.Answers.Add(answer);

                _context.Cards.Update(card);
                _context.Answers.Add(answer);
                _context.SaveChanges();
                return Result.Ok();
            } 
            catch
            {
                return Result.Fail("Search Error");
            }
        }

        public Card CreateCard(CardCreateDto cardDto)
        {
            try
            {
                Card card = _mapper.Map<Card>(cardDto);
                card.DaysNextAnswer = 0;
                card.LastAnswerDate = DateTime.Now;

                Group group = _context.Groups.First(g => g.Id == cardDto.GroupId);
                group.Cards.Add(card);

                _context.Groups.Update(group);
                _context.Cards.Add(card);
                _context.SaveChanges();
                return card;
            }
            catch
            {
                return null;
            }
        }

        public Result UpdateCard(int id, CardDto cardDto)
        {
            try
            {
                Card card = _context.Cards.First(card => card.Id == id);

                _mapper.Map(cardDto, card);
                _context.SaveChanges();
                return Result.Ok();
            }
            catch
            {
                return Result.Fail("Search Error");
            }
        }

        public Result DeleteCard(int id)
        {
            try
            {
                Card card = _context.Cards.First(card => card.Id == id);
                _context.Cards.Remove(card);
                _context.SaveChanges();
                return Result.Ok();
            }
            catch
            {
                return Result.Fail("Search Error");
            }
        }
    }
}
