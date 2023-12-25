using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.DTOs;
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

        public async Task RedirectRoute(string route)
        {
            await _jsRuntime.InvokeVoidAsync("redirectRoute", route);
        }

        public async Task MountSelectedPermissions(string idPermission, IEnumerable<AspNetRolesDTO> listRoles)
        {
            await _jsRuntime.InvokeVoidAsync("mountSelectedPermissions", idPermission, listRoles);
        }

        public async Task<List<string>> CreateStructDataPermissions(bool clearForm = true)
        {
            return await _jsRuntime.InvokeAsync<List<string>>("createStructDataPermissions", clearForm);
        }

    }
}
