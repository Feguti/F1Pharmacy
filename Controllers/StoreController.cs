using Microsoft.AspNetCore.Mvc;
using F1Pharmacy.Models;

namespace F1Pharmacy.Controllers;

public class StoreController : Controller
{
    private readonly F1PharmacyContext _context;

    public StoreController(F1PharmacyContext context)
    {
        _context = context;
    }

    public IActionResult Index () => View(_context.Stores);

    public IActionResult Show(int id)
    {
        Store store = _context.Stores.Find(id);

        if(store == null)
        {
            return NotFound(); // RedirectToAction("Index");
        }

        return View(store);
    }

    public IActionResult Create([FromForm] int id, [FromForm] string city, [FromForm] string address, [FromForm] string manager)
    {
        if(_context.Stores.Find(id) == null)
        {
            Store store = new Store(id,city,address,manager);
            _context.Stores.Add(store);
            _context.SaveChanges();
            return View("Cadastro");
        }
        else
        {
           return Content("Uma loja com esse ID já foi cadastrado, por favor insira outro ID.");
        }
    }

    public IActionResult Cadastro()
    {
        return View();
    }

     public IActionResult Delete(int id){

        Store unity = _context.Stores.Find(id);
        _context.Stores.Remove(unity);
        _context.SaveChanges();

        return View();
    }

    public IActionResult Update(int id, [FromForm] string city, [FromForm] string address, [FromForm] string manager )
    {
        Store unity = _context.Stores.Find(id);

        if(unity == null)
        {
            return Content("A loja não existe");
        }
        else
        {
            unity.Id = id;
            unity.City = city;
            unity.Address = address;
            unity.Manager = manager;
            _context.Stores.Update(unity);
            _context.SaveChanges();
            return Content("Especificações da loja atualizadas com sucesso!");
        }

    }

}