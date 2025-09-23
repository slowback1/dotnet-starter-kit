using Common.Interfaces;

namespace FileData;

public class FileGenericCrud<T> : FileCrud<T> where T : class, IIdentifyable
{
    public FileGenericCrud(string dataDirectory = "data") : base(dataDirectory)
    {
    }
}