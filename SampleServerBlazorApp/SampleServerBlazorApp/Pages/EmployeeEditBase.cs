using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using SampleModel;
using SampleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleServerBlazorApp.Pages
{
    public class EmployeeEditBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IToastService toastService { get; set; }


        [Parameter]
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();
        protected override async Task OnInitializedAsync()
        {
            int.TryParse(EmployeeId, out var employeeId);

            if (employeeId == 0) //new employee is being created
            {
                //add some defaults
                Employee = new Employee {};
            }
            else
            {
                Employee = await EmployeeService.GetEmployeeDetails(int.Parse(EmployeeId));
            }
        }
        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/employeeoverview");
        }
        protected async Task HandleValidSubmit()
        {
            if (Employee.EmployeeId == 0) //new
            {
                var addedEmployee = await EmployeeService.AddEmployee(Employee);
                if (addedEmployee != null)
                {
                    toastService.ShowSuccess("New employee added successfully.");
                }
                else
                {
                    toastService.ShowError("Error Occured!");
                }
            }
            else
            {
                await EmployeeService.UpdateEmployee(Employee);
                toastService.ShowSuccess("Employee updated successfully.");
            }
        }

        protected void HandleInvalidSubmit()
        {
            toastService.ShowError("There are some validation errors. Please try again.");
        }

        protected async Task DeleteEmployee()
        {
            await EmployeeService.DeleteEmployee(Employee.EmployeeId);
            toastService.ShowSuccess("Deleted successfully.");
            NavigateToOverview();
        }
    }
}
