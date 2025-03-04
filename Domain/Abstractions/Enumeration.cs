using System.Reflection;

namespace Domain.Abstractions;

public class Enumeration<TEnum> : IEquatable<Enumeration<TEnum>>
    where TEnum : Enumeration<TEnum>
{
    private static readonly Dictionary<int, TEnum> Enumerations = CreateEnumerations();

    protected Enumeration(int value, string name)
    {
        Value = value;
        Name = name;
    }

    public int Value { get; protected init; }

    public string Name { get; protected init; }

    public static TEnum? FromValue(int value)
    {
        return Enumerations.TryGetValue(value, out var result) ? result : null;
    }

    public static TEnum? FromName(string name)
    {
        return Enumerations.Values.SingleOrDefault(enumValue => enumValue.Name == name);
    }

    public bool Equals(Enumeration<TEnum>? other)
    {
        if (other is null) return false;

        return GetType() == other.GetType()
               && Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is Enumeration<TEnum> other && Equals(other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return Name;
    }

    private static Dictionary<int, TEnum> CreateEnumerations()
    {
        var enumerationType = typeof(TEnum);

        var fieldsForType = enumerationType
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fieldInfo => enumerationType.IsAssignableFrom(fieldInfo.FieldType))
            .Select(fieldInfo => (TEnum)fieldInfo.GetValue(null)!);
        
        return fieldsForType.ToDictionary(x => x.Value, x => x);
    }
}