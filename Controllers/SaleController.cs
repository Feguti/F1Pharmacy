
using Microsoft.AspNetCore.Mvc;
using F1Pharmacy.Models;

namespace F1Pharmacy.Controllers;

public class SaleController : Controller
{
    private readonly F1PharmacyContext _context;

    public SaleController (F1PharmacyContext context)
    {
        _context = context;
    }

    public IActionResult Index () => View(_context.Sales);

    public IActionResult Show(int id)
    {
        Sale sale = _context.Sales.Find(id);

        if(sale == null)
        {
            return RedirectToAction("Index");
        }

        return View(sale);
    }

    public IActionResult Delete(int id){
        _context.Sales.Remove(_context.Sales.Find(id));
        _context.SaveChanges();
        return View();
    }

    [HttpGet]
    public IActionResult Create(){
                
        return View();
    }

    [HttpPost]
    public IActionResult Create(Sale sale){
        
        if(_context.Sales.Find(sale.Id) != null)
        {
            return Content("Item já cadastrado");
        }
        
        _context.Sales.Add(sale);
        _context.SaveChanges();
        return RedirectToAction("Create");
    }

    [HttpGet]
    public IActionResult Update([FromRoute] int id){
        Sale sale = _context.Sales.Find(id);

        if(sale == null)
        {
            return NotFound();
        }

        return View(sale);
    }

    [HttpPost]
    public IActionResult Update(Sale customerUpdated){
        try
        {
            _context.Sales.Update(customerUpdated);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        catch
        {
            return NotFound();
        }
    }
}