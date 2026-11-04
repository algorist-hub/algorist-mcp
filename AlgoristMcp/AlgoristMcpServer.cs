using System.Reflection;

namespace Algorist.Mcp;

public static class AlgoristMcpServer
{
    public static IMcpServerBuilder AddAlgoristMcpServer (
        this IServiceCollection services,
        string name = "Algorist MCP Server",
        string version = "",
        Assembly? toolsAssembly = null)
    {
        toolsAssembly ??= Assembly.GetCallingAssembly();

        return services
            .AddMcpServer(options => options.ServerInfo = new() { Name = name, Version = version })
            .WithHttpTransport(options => options.Stateless = true)
            .WithToolsFromAssembly(toolsAssembly);
    }
}