using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Models;

namespace Logic.FeatureFlags;

public class DictionaryFeatureFlagProvider : IFeatureFlagProvider
{
    private readonly Dictionary<string, bool> _featureFlags;

    public DictionaryFeatureFlagProvider(Dictionary<string, bool> featureFlags)
    {
        _featureFlags = featureFlags;
    }

    public Task<IEnumerable<FeatureFlag>> GetFeatureFlags()
    {
        return Task.FromResult(_featureFlags.Select(kvp => new FeatureFlag
        {
            Name = kvp.Key,
            IsEnabled = kvp.Value
        }));
    }
}