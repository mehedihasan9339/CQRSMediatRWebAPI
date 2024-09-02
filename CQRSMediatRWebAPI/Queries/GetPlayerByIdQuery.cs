using CQRSMediatRWebAPI.Models;
using MediatR;

namespace CQRSMediatRWebAPI.Queries
{
    public class GetPlayerByIdQuery : IRequest<Player>
    {
        public int Id { get; set; }
    }
}
