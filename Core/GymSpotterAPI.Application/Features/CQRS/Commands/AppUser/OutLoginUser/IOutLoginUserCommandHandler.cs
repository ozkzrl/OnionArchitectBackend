namespace GymSpotterAPI.Application.Commands.AppUser.OutLoginUser
{
    public interface IOutLoginUserCommandHandler
    {
        Task<OutLoginUserCommandResponse> Handle(OutLoginUserCommandRequest request, CancellationToken cancellationToken);
    }
}