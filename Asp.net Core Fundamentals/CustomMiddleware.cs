using System.Text;

namespace Asp.net_Core_Fundamentals
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Read information from the request
            var schema = context.Request.Scheme;
            var host = context.Request.Host;
            var path = context.Request.Path;
            var queryString = context.Request.QueryString.ToString();
            var requestBody = await ReadRequestBodyAsync(context.Request);

            // Log the information 
            LogToFile($"Schema: {schema}, Host: {host}, Path: {path}, QueryString: {queryString}, RequestBody: {requestBody}");

            // Call the next middleware in the pipeline
            await _next(context);
        }

        /// <summary>
        /// Use to get request body
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private async Task<string> ReadRequestBodyAsync(HttpRequest request)
        {
            request.EnableBuffering();
            using var reader = new StreamReader(request.Body, encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false, leaveOpen: true);
            var body = await reader.ReadToEndAsync();
            request.Body.Position = 0;
            return body;
        }

        /// <summary>
        /// Use to write log to file
        /// </summary>
        /// <param name="logMessage"></param>
        private void LogToFile(string logMessage)
        {
            string logFileName = $"Log_{DateTime.Now:yyyyMMdd}.txt";
            File.AppendAllText(logFileName, logMessage + Environment.NewLine);
        }
    }
}
