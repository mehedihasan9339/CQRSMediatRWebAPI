using MediatR;

namespace CQRSMediatRWebAPI.Commands
{
    public class DeletePlayerCommand : IRequest
    {
        public int Id { get; set; }
    }
}
