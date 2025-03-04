var server = new HttpListener();
server.Prefixes.Add("http://localhost:8888/");
server.Start();

Console.WriteLine("server started");

while (true)
{
    var context = await server.GetContextAsync();
    var response = context.Response;
    var path = context.Request.Url?.AbsolutePath;

    var text = path switch
    {
        "/wtf" => "wtf",
        "/hello" => "<h1>Hello, world!<h1>",
        "/time" => DateTime.Now.ToString(),
        _ => "Unknown route"
    };


    var bytes = Encoding.Default.GetBytes(text);
    response.ContentLength64 = bytes.Length;

    await response.OutputStream.WriteAsync(bytes);
    response.OutputStream.Close();
    response.Close();

    
}


