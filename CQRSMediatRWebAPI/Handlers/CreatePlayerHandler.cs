using CQRSMediatRWebAPI.Commands;
using CQRSMediatRWebAPI.Data;
using CQRSMediatRWebAPI.Models;
using MediatR;

namespace CQRSMediatRWebAPI.Handlers
{
    public class CreatePlayerHandler : IRequestHandler<CreatePlayerCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreatePlayerHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Player
            {
                Name = request.Name,
                Score = request.Score
            };

            _context.Players.Add(player);
            await _context.SaveChangesAsync(cancellationToken);

            return player.Id;
        }
    }
}
