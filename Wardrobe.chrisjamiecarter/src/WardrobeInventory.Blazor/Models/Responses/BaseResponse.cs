namespace WardrobeInventory.Blazor.Models.Responses;

/// <summary>
/// Serves as a base response model, indicating the success of an operation and providing an optional message. Includes functionality to handle exceptions by updating the response state.
/// </summary>
public class BaseResponse
{
    public bool IsSuccess { get; set; }

    public string Message { get; set; } = string.Empty;

    public void HandleException(Exception exception)
    {
        IsSuccess = false;

        if (string.IsNullOrWhiteSpace(Message))
        {
            Message = exception.Message;
        }
    }
}
