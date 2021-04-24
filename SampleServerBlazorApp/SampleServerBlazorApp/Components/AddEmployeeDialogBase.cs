using Microsoft.AspNetCore.Components;
using SampleModel;
using SampleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleServerBlazorApp.Components
{
    public class AddEmployeeDialogBase: ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }
        public bool ShowDialog { get; set; }
        public Employee Employee { get; set; } = new Employee {};
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
            await EmployeeService.AddEmployee(Employee);
            ShowDialog = false;

            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }

    }
}
