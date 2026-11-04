
using Algorist.Mcp;

namespace AlgoristMcp;

public class Program
{
    public static void Main (string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAlgoristMcpServer(name: "Algorist MCP Server", version: "0.0.1");

        builder.Services.AddOpenApi();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.MapMcp("/mcp");

        app.Run();
    }
}
