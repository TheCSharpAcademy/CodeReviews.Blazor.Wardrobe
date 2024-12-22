using System.ComponentModel.DataAnnotations;

namespace WardrobeInventory.Blazor.Extensions;

/// <summary>
/// Provides extension methods for enumerations.
/// </summary>
public static class EnumExtensions
{
    public static string GetDisplayName(this Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        var attributes = fieldInfo!.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];

        var output = (attributes != null && attributes.Length > 0) ? attributes.First().Name : null;

        return output ?? value.ToString();
    }
}
