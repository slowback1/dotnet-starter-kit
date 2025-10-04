using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Interfaces;

namespace InMemory;

public abstract class InMemoryCrud<T> : ICrud<T> where T : class, IIdentifyable
{
    private static readonly Dictionary<Type, List<T>> ItemsByType = new();
    private static int _nextId = 1;

    public virtual Task<T> CreateAsync(T item)
    {
        var type = typeof(T);
        if (!ItemsByType.ContainsKey(type))
            ItemsByType[type] = new List<T>();
        item.Id = (_nextId++).ToString();
        ItemsByType[type].Add(item);
        return Task.FromResult(item);
    }

    public virtual Task<T?> GetByIdAsync(string id)
    {
        var type = typeof(T);
        if (!ItemsByType.ContainsKey(type))
            return Task.FromResult<T?>(null);
        var item = ItemsByType[type].FirstOrDefault(i => i.Id == id);
        return Task.FromResult<T?>(item);
    }

    public virtual Task<T?> UpdateAsync(string id, T item)
    {
        var type = typeof(T);
        if (!ItemsByType.ContainsKey(type))
            return Task.FromResult<T?>(null);
        var existingItem = ItemsByType[type].FirstOrDefault(i => i.Id == id);
        if (existingItem == null) return Task.FromResult<T?>(null);
        var index = ItemsByType[type].IndexOf(existingItem);
        if (index < 0) return Task.FromResult<T?>(null);
        ItemsByType[type][index] = item;
        return Task.FromResult(existingItem)!;
    }

    public virtual Task<bool> DeleteAsync(string id)
    {
        var type = typeof(T);
        if (!ItemsByType.ContainsKey(type))
            return Task.FromResult(false);
        var item = ItemsByType[type].FirstOrDefault(i => i.Id == id);
        if (item == null) return Task.FromResult(false);
        ItemsByType[type].Remove(item);
        return Task.FromResult(true);
    }

    public virtual Task<T?> GetByQueryAsync(Func<T, bool> query)
    {
        var type = typeof(T);
        if (!ItemsByType.ContainsKey(type))
            return Task.FromResult<T?>(null);
        var item = ItemsByType[type].FirstOrDefault(query);
        return Task.FromResult<T?>(item);
    }

    public virtual Task<IEnumerable<T>> QueryAsync(Func<T, bool> query)
    {
        var type = typeof(T);
        if (!ItemsByType.ContainsKey(type))
            return Task.FromResult(Enumerable.Empty<T>());
        var results = ItemsByType[type].Where(query).ToList();
        return Task.FromResult(results.AsEnumerable());
    }

    public static void ClearStaticState()
    {
        ItemsByType.Clear();
        _nextId = 1;
    }
}