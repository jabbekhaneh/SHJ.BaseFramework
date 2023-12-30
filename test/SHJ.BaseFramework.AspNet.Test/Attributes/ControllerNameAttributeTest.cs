using Microsoft.AspNetCore.Mvc;

namespace SHJ.BaseFramework.AspNet.Test.Attributes;

public class ControllerNameAttributeTest
{

    [Fact]
    public void SetName_ControllerNameAttribute_Should()
    {
        string name = "Dummy-name";

        var services = new ControllerNameAttribute(name);

         Assert.Equal(name, services.Name);
    } 
}
