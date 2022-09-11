using Microsoft.JSInterop;

namespace BlazorFullStackCrud.Client.Services
{
    public static class Class
    {
        public static ValueTask<object> SaveAs(this IJSRuntime js, string filename, byte[] data)
        => js.InvokeAsync<object>(
            "saveAsFile",
            filename,
            Convert.ToBase64String(data));
    }
}
