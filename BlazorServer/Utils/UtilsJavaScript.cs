using Microsoft.JSInterop;

namespace BlazorServer.Utils
{
    public class UtilsJavaScript
    {
        private readonly IJSRuntime _jsRuntime;

        public UtilsJavaScript(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task NotifyError(string id, string color, string message)
        {
            await _jsRuntime.InvokeVoidAsync("notifyError", id, color, message);
        }

        public async Task FocusById(string elementId)
        {
            await _jsRuntime.InvokeVoidAsync("focusById", elementId);
        }

        public async Task ClearBorderAndNotification()
        {
            await _jsRuntime.InvokeVoidAsync("clearBorderAndNotification");
        }
    }
}
