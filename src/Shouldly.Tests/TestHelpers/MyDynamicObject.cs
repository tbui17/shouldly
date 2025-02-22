namespace Shouldly.Tests.TestHelpers;

class MyDynamicObject : DynamicObject
{
    private readonly Dictionary<string, object?> properties = new();

    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        var key = binder.Name;
        return properties.TryGetValue(key, out result);
    }

    public override bool TrySetMember(SetMemberBinder binder, object? value)
    {
        var key = binder.Name;
        properties[key] = value;
        return true;
    }
}