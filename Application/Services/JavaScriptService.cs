using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.JSInterop;

namespace Application.Services
{
    public class JavaScriptService
    {
        private readonly IJSRuntime _jsRuntime;

        public JavaScriptService(IJSRuntime jsRuntime)
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
