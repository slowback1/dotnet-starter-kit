using System;
using System.Linq;

namespace Common.Utilities.Attributes;

public class MatchingPropertyAttribute(string propertyA, string propertyB, string? errorMessage = null) : ValidationAttribute
{
    private readonly string? _errorMessage = errorMessage;
    private readonly string _propertyA = propertyA;
    private readonly string _propertyB = propertyB;

    public override string? CheckForValidationError(object? value)
    {
        if (_propertyA == _propertyB) throw new InvalidOperationException("Both properties are the same!");

        if (value is null) return null;

        var properties = value.GetType().GetProperties();

        var propertyA = properties.FirstOrDefault(p => p.Name == _propertyA);
        var propertyB = properties.FirstOrDefault(p => p.Name == _propertyB);

        if (propertyA is null || propertyB is null) throw new InvalidOperationException("Given invalid property name");

        var valueA = propertyA.GetValue(value);
        var valueB = propertyB.GetValue(value);

        var bothValuesAreNull = valueA == null && valueB == null;
        var bothValuesHaveTheSameNotNullValue = valueA != null && valueA.Equals(valueB);

        if (bothValuesAreNull || bothValuesHaveTheSameNotNullValue) return null;

        return _errorMessage ?? $"'{_propertyA}' must equal '{_propertyB}'.";
    }
}