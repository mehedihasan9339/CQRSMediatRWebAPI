using MediatR;

namespace CQRSMediatRWebAPI.Commands
{
    public class CreatePlayerCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
}
