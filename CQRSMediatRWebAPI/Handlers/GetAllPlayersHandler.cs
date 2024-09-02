using CQRSMediatRWebAPI.Data;
using CQRSMediatRWebAPI.Models;
using CQRSMediatRWebAPI.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatRWebAPI.Handlers
{
    public class GetAllPlayersHandler : IRequestHandler<GetAllPlayersQuery, IEnumerable<Player>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllPlayersHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Player>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Players.ToListAsync(cancellationToken);
        }
    }
}
