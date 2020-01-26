using BethanysPieShopHRM.Server.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Server.Pages
{
    public class EmployeeEditBase : ComponentBase
    {
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        [Inject]
        public ICountryDataService CountryDataService { get; set; }

        [Parameter]
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();
        public List<Country> Countries { get; set; } = new List<Country>();

        protected string CountryId = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            Countries = (await CountryDataService.GetAllCountries()).ToList();
            CountryId = Employee.CountryId.ToString();
        }
    }
}