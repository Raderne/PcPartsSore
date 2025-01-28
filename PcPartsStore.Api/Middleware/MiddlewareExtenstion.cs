namespace PcPartsStore.Api.Middleware
{
    public static class MiddlewareExtenstion
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
