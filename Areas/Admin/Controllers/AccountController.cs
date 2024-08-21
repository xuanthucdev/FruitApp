using Microsoft.AspNetCore.Mvc;
using ProjectDotNet.Models;
using ProjectDotNet.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjectDotNet.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AccountController : Controller
    {
        private readonly AccountService accountService;

        public AccountController(AccountService _accountService)
        {
            accountService = _accountService;
        }
        
        public async Task<IActionResult> Index()
        {
            var accounts = await accountService.GetAllAccountsAsync();
            return View(accounts);
        }
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await accountService.GetAllAccountsAsync();
            return Json(new { data = accounts });
        }
        public IActionResult AddAccount()
        {
            
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddAccount(Account account)
        {
            if (ModelState.IsValid)
            {

                bool result = await accountService.RegisterAsync(account);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Failed to add account.");
            }
            return View(account);
        }
         [HttpPost]
        [HttpPost]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var result = await accountService.DeleteAccountAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return RedirectToAction("Index"); // Redirect to the index or list view
        }
        

        public async Task<IActionResult> EditAccount(int id)
        {
            var account = await accountService.GetAccountByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }
        [HttpPost]

        public async Task<IActionResult> EditAccountSave(Account account)
        {
            if (ModelState.IsValid)
            {
                 await accountService.UpdateAccountAsync(account);
                return RedirectToAction("Index");
            }
            return View("Index", account);
        }
        

    }
}
