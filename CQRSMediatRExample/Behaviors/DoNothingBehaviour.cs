using MediatR;

namespace CQRSMediatRExample.Behaviors
{
    public class DoNothingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
        where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Console.WriteLine("DoNothing: in");
            var response = await next();
            Console.WriteLine("DoNothing: out");

            return response;
        }
    }
}
