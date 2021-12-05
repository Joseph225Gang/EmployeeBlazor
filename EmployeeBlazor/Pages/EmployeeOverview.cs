using EmployeeBlazor.Components;
using EmployeeBlazor.Entity;
using Microsoft.AspNetCore.Components;

namespace EmployeeBlazor.Pages
{
    public partial class EmployeeOverview : ComponentBase
    {

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        protected AddEmployeeDialog AddEmployeeDialog { get; set; }
        public List<Employee> Employees { get; set; }


        protected async override Task OnInitializedAsync()
        {
            Employees = (await EmployeeService.GetAllEmployees()).ToList();
        }

        public string SetBackgroundColor(Employee employee)
        {
            return employee.IsSelected ? "blue" : "white";
        }

        public async void CheckBoxChanged(ChangeEventArgs e, Employee employee)
        {
            employee.IsSelected = !employee.IsSelected;
            await EmployeeService.UpdateEmployee(employee);
            StateHasChanged();
        }
        protected void QuickAddEmployee()
        {
            AddEmployeeDialog.Show();
        }

        public async void UpdateEmployeeStatus(int id)
        {
            this.Status = Status.Update;
            UpdateEmployee = await EmployeeService.GetEmployeeDetails(id);
            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {
            if (Status == Status.Add) //new
            {
                await EmployeeService.AddEmployee(UpdateEmployee);
            }
            else
            {
                await EmployeeService.UpdateEmployee(UpdateEmployee);
            }
            Status = Status.Overview;
            Employees = (await EmployeeService.GetAllEmployees()).ToList();
            StateHasChanged();
        }

        protected void GoToEmployeeDetail(Employee employee)
        {
            UpdateEmployee = employee;
            Status = Status.Detail;
        }

        protected async void Delete(int employeeId)
        {
            await EmployeeService.DeleteEmployee(employeeId);
            Employees = (await EmployeeService.GetAllEmployees()).ToList();
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
            Employees = (await EmployeeService.GetAllEmployees()).ToList();
            StateHasChanged();
        }

        public Status Status { get; set; } = Status.Overview;
        public Employee UpdateEmployee { get; set; } = new Employee();


    }
}
