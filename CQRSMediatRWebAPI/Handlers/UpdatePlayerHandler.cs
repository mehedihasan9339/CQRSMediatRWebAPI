using CQRSMediatRWebAPI.Commands;
using CQRSMediatRWebAPI.Data;
using CQRSMediatRWebAPI.Exceptions;
using MediatR;

namespace CQRSMediatRWebAPI.Handlers
{
    public class UpdatePlayerHandler : IRequestHandler<UpdatePlayerCommand>
    {
        private readonly ApplicationDbContext _context;

        public UpdatePlayerHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = await _context.Players.FindAsync(request.Id);

            if (player == null)
            {
                throw new NotFoundException("Player not found");
            }

            player.Name = request.Name;
            player.Score = request.Score;

            _context.Players.Update(player);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
