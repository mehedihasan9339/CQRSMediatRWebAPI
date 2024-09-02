using MediatR;
using CQRSMediatRWebAPI.Commands;
using CQRSMediatRWebAPI.Models;
using CQRSMediatRWebAPI.Data;
using CQRSMediatRWebAPI.Exceptions;

namespace CQRSMediatRWebAPI.Handlers
{
    public class DeletePlayerHandler : IRequestHandler<DeletePlayerCommand>
    {
        private readonly ApplicationDbContext _context;

        public DeletePlayerHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = await _context.Players.FindAsync(request.Id);

            if (player == null)
            {
                // Handle the case where the player is not found
                throw new NotFoundException("Player not found");
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
