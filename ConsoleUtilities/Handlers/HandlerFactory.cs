using Common.Interfaces;

namespace ConsoleUtilities.Handlers;

public class HandlerFactory
{
    private readonly List<BaseHandler> _handlers;

    public HandlerFactory(ICrudFactory crudFactory)
    {
        _handlers = new List<BaseHandler>
        {
            new GetExampleDataHandler(crudFactory)
        };
    }

    public IHandler GetHandler(string handlerName)
    {
        var handler =
            _handlers.FirstOrDefault(h => h.GetName().Equals(handlerName, StringComparison.OrdinalIgnoreCase));
        if (handler == null) throw new ArgumentException($"Handler '{handlerName}' not found.");
        return handler;
    }

    public List<string> GetHandlerOptions()
    {
        return _handlers.Select(h => $"{h.GetName()} - {h.GetHelpMessage()}").ToList();
    }
}