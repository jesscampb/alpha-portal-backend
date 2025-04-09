using System.Reflection;

namespace Infrastructure.Extensions;

public static class MappingExtensions
{
    public static TDestination MapTo<TDestination>(this object source)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));

        TDestination destination = Activator.CreateInstance<TDestination>()!;

        var sourceProperties = source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var destinationProperties = destination.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var dProperty in destinationProperties)
        {
            var sProperty = sourceProperties.FirstOrDefault(x => x.Name == dProperty.Name && x.PropertyType == dProperty.PropertyType);

            if (sProperty != null && dProperty.CanWrite)
            {
                var value = sProperty.GetValue(source);
                dProperty.SetValue(destination, value);
            }
        }

        return destination;
    }
}
