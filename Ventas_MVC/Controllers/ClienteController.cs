using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Ventas_MVC.Models;

namespace Ventas_MVC.Controllers
{
    public class ClienteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            //se declara la lista afuera para tener scope global, el signo de pregunta quiere decir que puede 
            //recibir valores nulos.-
            List<Cliente>? clientes = null;

            using (VentasContext context = new())
            {
                //usamos la variable y listamos
                clientes = context.Clientes.ToList();
            }

            return View(clientes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            using(VentasContext context=new())
            {
                //guarda de forma lógica el cliente, no lo guarda en la base de datos
                context.Clientes.Add(cliente);
                //esta última línea es la que guarda en la base de datos
                context.SaveChanges();
            }
            

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            using (VentasContext context = new())
            {
                //var buscamosCliente = (from c in context.Clientes where c.Id == Id select c);
                //Cliente? cliente = buscamosCliente.FirstOrDefault();

                Cliente? cliente = context.Clientes.Find(Id);                
                
                    if (cliente != null)
                {
                    return View(cliente);
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
                
            }
                        
        }


        [HttpPost]
        public IActionResult Update(int id, Cliente cliente)
        {
            //Actualizar el cliente

            using (VentasContext context = new())
            {
                if (id != cliente.Id)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    context.Clientes.Update(cliente);
                    context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (VentasContext context = new())
            {
                //Cliente? cliente = context.Clientes.Find(id);

                if(id != -1)
                {
                    Cliente? cliente = context.Clientes.Find(id);
                    
                    if(cliente != null)
                    {
                        context.Clientes.Remove(cliente);
                        context.SaveChanges(true);
                    }   
                }
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
