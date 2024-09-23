internal sealed class Servers
{
    private static Servers singlet;
    private List<string> servers = new List<string>();

    private Servers() { }

    internal static Servers Instance
    { 
        get { return singlet ?? (singlet = new Servers()); }
    }

    internal bool AddServer(string server)
    {
        if (server.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || server.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            if (!servers.Contains(server))
            {
                servers.Add(server);
                return true;
            }
        }
        return false;
    }

    internal List<string> GetHttpServers()
    {
        return servers.Where(s => s.StartsWith("http://", StringComparison.OrdinalIgnoreCase)).ToList();
    }

    internal List<string> GetHttpsServers()
    {
        return servers.Where(s => s.StartsWith("https://", StringComparison.OrdinalIgnoreCase)).ToList();
    }
}

internal class Program
{
    internal static void Main()
    {
        var servers = Servers.Instance;

        servers.AddServer("http://example_singlt.com");
        servers.AddServer("https://example_singlt.com");
        servers.AddServer("http://example2_singlt.com");

        var httpServers = servers.GetHttpServers();
        var httpsServers = servers.GetHttpsServers();

        Console.WriteLine("HTTP сервера:");
        foreach (var server in httpServers)
        {
            Console.WriteLine(server);
        }

        Console.WriteLine("HTTPS сервера:");
        foreach (var server in httpsServers)
        {
            Console.WriteLine(server);
        }
    }
}