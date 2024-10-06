using CQRS_Implementation.Features.Users.Commands.Create;
using MediatR;
using System.Text.Json;

namespace CQRS_Implementation.Behaviors
{
    public class RequestResponseLoggingBehavior<TRequest, TResponse>(ILogger<RequestResponseLoggingBehavior<TRequest, TResponse>> logger)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var correlationId = Guid.NewGuid();

            // Request Logging
            // Serialize the request
            if (request is CreateUserCommand)
            {
                var requestJson = JsonSerializer.Serialize(request);
                // Log the serialized request
                logger.LogInformation("Handling request {CorrelationID}: {Request}", correlationId, requestJson);
            }

            // Response logging
            var response = await next();
            if (request is CreateUserCommand)
            {
                // Serialize the request
                var responseJson = JsonSerializer.Serialize(response);
                // Log the serialized request
                logger.LogInformation("Response for {Correlation}: {Response}", correlationId, responseJson);
            }

            // Return response
            return response;
        }
    }
}
