using CQRSMediatRWebAPI.Data;
using CQRSMediatRWebAPI.Models;
using CQRSMediatRWebAPI.Queries;
using MediatR;

namespace CQRSMediatRWebAPI.Handlers
{
    public class GetPlayerByIdHandler : IRequestHandler<GetPlayerByIdQuery, Player>
    {
        private readonly ApplicationDbContext _context;

        public GetPlayerByIdHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Player> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Players.FindAsync(request.Id);
        }
    }
}
