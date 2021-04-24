using Microsoft.AspNetCore.Components;
using SampleModel;
using SampleServerBlazorApp.Components;
using SampleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleServerBlazorApp.Pages
{
    public class EmployeeOverviewBase: ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public List<Employee> Employees { get; set; }
        protected AddEmployeeDialog AddEmployeeDialog { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeService.GetAllEmployees()).ToList();
        }
        public async void AddEmployeeDialog_OnDialogClose()
        {
            Employees = (await EmployeeService.GetAllEmployees()).ToList();
            StateHasChanged();
        }
        protected void QuickAddEmployee()
        {
            AddEmployeeDialog.Show();
        }
    }
}
