namespace Microsoft.AspNetCore.Mvc;

[AttributeUsage(AttributeTargets.Class)]
public class ControllerNameAttribute : Attribute
{
    public string Name { get; }
    public ControllerNameAttribute(string name)
    {
        Name = name;
    }

    public static string GetName(Type nameType)
    {
        return nameType
                   .GetCustomAttributes(true)
                   .OfType<ControllerNameAttribute>()
                   .FirstOrDefault()?.Name ?? nameType.Name;
    }
}

public class ControllerNameAttributeConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        var controllerNameAttribute = controller.Attributes.OfType<ControllerNameAttribute>().SingleOrDefault();
        if (controllerNameAttribute != null)
        {
            controller.ControllerName = controllerNameAttribute.Name;
        }
    }
}