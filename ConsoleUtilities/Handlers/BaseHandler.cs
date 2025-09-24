using Common.Interfaces;

namespace ConsoleUtilities.Handlers;

public abstract class BaseHandler : IHandler
{
    protected BaseHandler(ICrudFactory crudFactory)
    {
        CrudFactory = crudFactory;
    }

    protected ICrudFactory CrudFactory { get; set; }

    public abstract Task HandleAsync(string[] args);
    public abstract string GetHelpMessage();
    public abstract string GetName();
}