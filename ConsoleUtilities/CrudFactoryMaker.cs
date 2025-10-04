using Common.Interfaces;
using FileData;
using InMemory;
using Microsoft.Extensions.Configuration;

namespace ConsoleUtilities;

public class CrudFactoryMaker
{
    public static ICrudFactory ConfigureCrudFactory(IConfiguration configuration)
    {
        var crudFactoryImpl = configuration["CrudFactory:Implementation"] ?? "InMemory";

        switch (crudFactoryImpl.ToLower())
        {
            case "filedata":
                var dataDirectory = configuration["FileData:Directory"] ?? "data";
                return new FileCrudFactory(dataDirectory);
            case "inmemory":
            default:
                return new InMemoryCrudFactory();
        }
    }
}