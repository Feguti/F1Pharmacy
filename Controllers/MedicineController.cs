using Microsoft.AspNetCore.Mvc;
using F1Pharmacy.Models;

namespace F1Pharmacy.Controllers;

public class MedicineController : Controller
{
    private readonly F1PharmacyContext _context;

    public MedicineController(F1PharmacyContext context)
    {
        _context = context;
    }

    public IActionResult Index () => View(_context.Medicines);

    public IActionResult Show(int id)
    {
        Medicine medicine = _context.Medicines.Find(id);

        if(medicine == null)
        {
            return NotFound(); // RedirectToAction("Index");
        }

        return View(medicine);
    }

    public IActionResult Create([FromForm] int id, [FromForm] string name, [FromForm] string type, [FromForm] string description)
    {
        if(_context.Stores.Find(id) == null)
        {
            Medicine medicine = new Medicine(id,name,type,description);
            _context.Medicines.Add(medicine);
            _context.SaveChanges();
            return View("Cadastro");
        }
        else
        {
           return Content("Um medicamento com esse ID já foi cadastrado, por favor insira outro ID.");
        }
    }

    public IActionResult Cadastro()
    {
        return View();
    }

     public IActionResult Delete(int id){

        Medicine medicine = _context.Medicines.Find(id);
        _context.Medicines.Remove(medicine);
        _context.SaveChanges();

        return View();
    }

    public IActionResult Update(int id, [FromForm] string name, [FromForm] string type, [FromForm] string description )
    {
        Medicine medicine = _context.Medicines.Find(id);

        if(medicine == null)
        {
            return Content("O medicamento não existe");
        }
        else
        {
            medicine.Id = id;
            medicine.Name = name;
            medicine.Type = type;
            medicine.Description = description;
            _context.Medicines.Update(medicine);
            _context.SaveChanges();
            return Content("Especificações do medicamento atualizadas com sucesso!");
        }

    }

}