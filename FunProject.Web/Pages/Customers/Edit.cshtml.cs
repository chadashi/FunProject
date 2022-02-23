﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FunProject.Application.CustomersModule.Services.Interfaces;
using FunProject.Application.CustomersModule.Dtos;

namespace FunProject.Web.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly ICustomersService _customersService;

        public EditModel(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        [BindProperty]
        public CustomerDto Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _customersService.GetCustomer(id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
        // Uncommint this Method to start the Task
        // public async Task<IActionResult> OnPostAsync()
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return Page();
        //     }

        //     // Task #1

        //     return RedirectToPage("./Index");
        // }
    }
}
