var server = new HttpListener();
server.Prefixes.Add("http://localhost:8888/");
server.Start();

Console.WriteLine("server started");

while (true)
{
    var context = await server.GetContextAsync();
    _ = Task.Run(() => RequestHandler.HandleRequest(context));
}