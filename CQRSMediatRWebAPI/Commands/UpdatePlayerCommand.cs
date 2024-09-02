using MediatR;

namespace CQRSMediatRWebAPI.Commands
{
    public class UpdatePlayerCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
}
