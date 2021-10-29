using EmployeeBlazor.Components;
using EmployeeBlazor.Entity;
using EmployeeBlazor.Service;
using Microsoft.AspNetCore.Components;

namespace EmployeeBlazor.Pages
{
    public partial class EmployeeOverview
    {
        protected AddEmployeeDialog AddEmployeeDialog { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        public IEmployeeService EmployeeDataService { get; set; } = new EmployeeService();

        protected async override Task OnInitializedAsync()
        {
            Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
        }

        public string SetBackgroundColor(Employee employee)
        {
            return employee.IsSelected ? "blue" : "white";
        }

        public async void CheckBoxChanged(ChangeEventArgs e, Employee employee)
        {
            employee.IsSelected = !employee.IsSelected;
            await EmployeeDataService.UpdateEmployee(employee);
            StateHasChanged();
        }
        protected void QuickAddEmployee()
        {
            AddEmployeeDialog.Show();
        }

        public async void UpdateEmployeeStatus(int id)
        {
            this.Status = Status.Update;
            UpdateEmployee = await EmployeeDataService.GetEmployeeDetails(id);
            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {
            if (Status == Status.Add) //new
            {
                await EmployeeDataService.AddEmployee(UpdateEmployee);
            }
            else
            {
                await EmployeeDataService.UpdateEmployee(UpdateEmployee);
            }
            Status = Status.Overview;
            Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
            StateHasChanged();
        }

        protected void GoToEmployeeDetail(Employee employee)
        {
            UpdateEmployee = employee;
            Status = Status.Detail;
        }

        protected async void Delete(int employeeId)
        {
            await EmployeeDataService.DeleteEmployee(employeeId);
            Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
            StateHasChanged();
        }

        protected void GoToLastPage()
        {
            Status = Status.Overview;
            StateHasChanged();
        }

        protected void HandleInvalidSubmit()
        {
        }

        public async void AddEmployeeDialog_OnDialogClose()
        {
            Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
            StateHasChanged();
        }

        public Status Status { get; set; } = Status.Overview;
        public Employee UpdateEmployee { get; set; } = new Employee();


    }
}
