using CQRSMediatRWebAPI.Models;
using MediatR;

namespace CQRSMediatRWebAPI.Queries
{
    public class GetAllPlayersQuery : IRequest<IEnumerable<Player>>
    {
    }
}
