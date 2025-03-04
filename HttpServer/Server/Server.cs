public static class RequestHandler
{
    public static async void HandleRequest(HttpListenerContext context)
    {
        try
        {
            var response = context.Response;
            var path = context.Request.Url?.AbsolutePath;

            var text = path switch
            {
                "/wtf" => "wtf",
                "/hello" => "<h1>Hello, world!</h1>",
                "/time" => DateTime.Now.ToString(),
                _ => "Unknown route"
            };

            var bytes = Encoding.UTF8.GetBytes(text);
            response.ContentLength64 = bytes.Length;

            await response.OutputStream.WriteAsync(bytes);
            response.OutputStream.Close();
            response.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] {ex.Message}");
        }
    }
}
