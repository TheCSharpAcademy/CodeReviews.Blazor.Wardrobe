using System.Web;

namespace WardrobeInventory.Blazor.Extensions;

/// <summary>
/// Provides extension methods for GUIDs.
/// </summary>
public static class GuidExtensions
{
    public static string UrlEncoded(this Guid value)
    {
        return HttpUtility.UrlEncode(value.ToString());
    }
}
