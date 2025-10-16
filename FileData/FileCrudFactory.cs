using Common.Interfaces;

namespace FileData;

public class FileCrudFactory(string dataDirectory = "data") : ICrudFactory
{
    private readonly string _dataDirectory = dataDirectory;

    public ICrud<T> GetCrud<T>() where T : class, IIdentifyable
    {
        return new FileGenericCrud<T>(_dataDirectory);
    }
}