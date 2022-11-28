
using Microsoft.AspNetCore.Mvc;
using F1Pharmacy.Models;

namespace F1Pharmacy.Controllers;

public class CustomerController : Controller
{
    private readonly F1PharmacyContext _context;

    public CustomerController (F1PharmacyContext context)
    {
        _context = context;
    }

    public IActionResult Index () => View(_context.Customers);

    public IActionResult Show(int id)
    {
        Customer customer = _context.Customers.Find(id);

        if(customer == null)
        {
            return RedirectToAction("Index");
        }

        return View(customer);
    }

    public IActionResult Delete(int id){
        _context.Customers.Remove(_context.Customers.Find(id));
        _context.SaveChanges();
        return View();
    }

    [HttpGet]
    public IActionResult Create(){
                
        return View();
    }

    [HttpPost]
    public IActionResult Create(Customer customer){
        
        if(_context.Customers.Find(customer.Id) != null)
        {
            return Content("Computador já cadastrado");
        }
        
        _context.Customers.Add(customer);
        _context.SaveChanges();
        return RedirectToAction("Create");
    }

    [HttpGet]
    public IActionResult Update([FromRoute] int id){
        Customer customer = _context.Customers.Find(id);

        if(customer == null)
        {
            return NotFound();
        }

        return View(customer);
    }

    [HttpPost]
    public IActionResult Update(Customer customerUpdated){

        try
        {
            _context.Customers.Update(customerUpdated);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        catch
        {
            return NotFound();
        }
    }
}



// [FromForm] int id, [FromForm] string name, [FromForm] string city, [FromForm] string address, [FromForm] string email, [FromForm] string phone