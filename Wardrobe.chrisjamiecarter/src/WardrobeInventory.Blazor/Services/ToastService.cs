using System.Timers;
using WardrobeInventory.Blazor.Enums;

namespace WardrobeInventory.Blazor.Services;

/// <summary>
/// Provides a service for managing toast notifications in the Blazor application.
/// </summary>
public class ToastService : IDisposable
{
    private System.Timers.Timer? _countdown;

    private static readonly int ToastDisplayTime = 5 * 1000;

    public void ShowToast(string message, ToastLevel level)
    {
        OnShow?.Invoke(message, level);
        StartCountdown();
    }

    private void HideToast(object? source, ElapsedEventArgs e)
    {
        OnHide?.Invoke();
    }

    private void StartCountdown()
    {
        if (_countdown is null)
        {
            _countdown = new System.Timers.Timer(ToastDisplayTime);
            _countdown.Elapsed += HideToast;
            _countdown.AutoReset = false;
        }

        if (_countdown.Enabled)
        {
            _countdown.Stop();
            _countdown.Start();
        }
        else
        {
            _countdown.Start();
        }
    }

    public void Dispose()
    {
        _countdown?.Dispose();
        GC.SuppressFinalize(this);
    }

    public event Action<string, ToastLevel>? OnShow;

    public event Action? OnHide;
}
