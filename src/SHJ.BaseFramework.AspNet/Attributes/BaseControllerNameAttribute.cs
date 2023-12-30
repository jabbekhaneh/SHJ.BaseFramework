namespace Microsoft.AspNetCore.Mvc;

[AttributeUsage(AttributeTargets.Class)]
public class BaseControllerNameAttribute : Attribute
{
    public string Name { get; }
    public BaseControllerNameAttribute(string name)
    {
        Name = name;
    }

    public static string GetName(Type nameType)
    {
        return nameType
                   .GetCustomAttributes(true)
                   .OfType<BaseControllerNameAttribute>()
                   .FirstOrDefault()?.Name ?? nameType.Name;
    }
}

public class BaseControllerNameAttributeConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        var controllerNameAttribute = controller.Attributes.OfType<BaseControllerNameAttribute>().SingleOrDefault();
        if (controllerNameAttribute != null)
        {
            controller.ControllerName = controllerNameAttribute.Name;
        }
    }
}