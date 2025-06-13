using Serilog.Context;

namespace Bookiby.Api.Middleware;

public class RequestContextLoggingMiddleware(RequestDelegate next)
{
    private const string CorrelationIdHeaderName = "X-Correlation-Id";
    
    private readonly RequestDelegate _next = next;      
    
    public Task Invoke(HttpContext httpContext)
    {
        using (LogContext.PushProperty("CorrelationId", GetCorrelationId(httpContext)))
        {
            var correlationId = GetCorrelationId(httpContext);
            Console.WriteLine($"Request {httpContext.Request.Path} received with correlation id {correlationId}");
            return _next.Invoke(httpContext);
        }
    }
    
    private static string GetCorrelationId(HttpContext httpContext)
    {
        httpContext.Request.Headers.TryGetValue(CorrelationIdHeaderName, out var correlationId);
        
        return correlationId.FirstOrDefault() ?? httpContext.TraceIdentifier;
    }
}