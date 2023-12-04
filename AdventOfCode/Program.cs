using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();

var namespaceYear2022 = "Y2022";
var namespaceYear2023 = "Y2023";

var types = assembly.GetTypes().Where(x => x.Name.StartsWith("Day") && x.Namespace != null && x.Namespace.EndsWith(namespaceYear2023));

foreach (var type in types)
{
    if (type.Name == "Day")
        continue;

    var instance = Activator.CreateInstance(type);

    instance?.GetType()
            .GetMethod("Execute")?
            .Invoke(instance, null);
}

Console.ReadKey();