using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();

var types = assembly.GetTypes().Where(x => x.Name.StartsWith("Day"));

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