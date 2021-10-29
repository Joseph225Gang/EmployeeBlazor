using EmployeeBlazor.Entity;
using EmployeeBlazor.Service;
using Microsoft.AspNetCore.Components;

namespace EmployeeBlazor.Components
{
    public partial class AddEmployeeDialog
    {
        public Employee Employee { get; set; } = new Employee();
        public bool ShowDialog { get; set; }

        public IEmployeeService EmployeeDataService { get; set; } = new EmployeeService();

        public void Show()
        {
            ResetDialog();
            ShowDialog = true;
            StateHasChanged();
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        private void ResetDialog()
        {
            Employee = new Employee {};
        }

        protected async Task HandleValidSubmit()
        {
            await EmployeeDataService.AddEmployee(Employee);
            ShowDialog = false;
            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        protected void HandleInvalidSubmit()
        {
        }
    }
}
