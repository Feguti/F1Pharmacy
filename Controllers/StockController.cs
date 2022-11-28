
using Microsoft.AspNetCore.Mvc;
using F1Pharmacy.Models;

namespace F1Pharmacy.Controllers;

public class StockController : Controller
{
    private readonly F1PharmacyContext _context;

    public StockController (F1PharmacyContext context)
    {
        _context = context;
    }

    public IActionResult Index () => View(_context.Stocks);

    public IActionResult Show(int id)
    {
        Stock stock = _context.Stocks.Find(id);

        if(stock == null)
        {
            return RedirectToAction("Index");
        }

        return View(stock);
    }

    public IActionResult Delete(int id){
        _context.Stocks.Remove(_context.Stocks.Find(id));
        _context.SaveChanges();
        return View();
    }

    [HttpGet]
    public IActionResult Create(){
                
        return View();
    }

    [HttpPost]
    public IActionResult Create(Stock stock){
        
        if(_context.Stocks.Find(stock.Id) != null)
        {
            return Content("Item já cadastrado");
        }
        
        _context.Stocks.Add(stock);
        _context.SaveChanges();
        return RedirectToAction("Create");
    }

    [HttpGet]
    public IActionResult Update([FromRoute] int id){
        Stock stock = _context.Stocks.Find(id);

        if(stock == null)
        {
            return NotFound();
        }

        return View(stock);
    }

    [HttpPost]
    public IActionResult Update(Stock customerUpdated){
        try
        {
            _context.Stocks.Update(customerUpdated);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        catch
        {
            return NotFound();
        }
    }
}