using Common.Interfaces;

namespace FileData;

public class FileCrudFactory : ICrudFactory
{
    private readonly string _dataDirectory;

    public FileCrudFactory(string dataDirectory = "data")
    {
        _dataDirectory = dataDirectory;
    }

    public ICrud<T> GetCrud<T>() where T : class, IIdentifyable
    {
        return new FileGenericCrud<T>(_dataDirectory);
    }
}