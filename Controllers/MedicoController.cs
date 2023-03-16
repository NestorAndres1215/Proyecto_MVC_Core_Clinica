using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

// Modelo
using AppMVC_Core_BDCLINICA.Models;
// EntityFrameworkCore
using Microsoft.EntityFrameworkCore; // Include
using Microsoft.AspNetCore.Mvc.Rendering; // SelectList

namespace AppMVC_Core_BDCLINICA.Controllers
{
    public class MedicoController : Controller
    {
        // variable del contexto del entity framework core
        BDCLINICA2022Context bd = new BDCLINICA2022Context();

        // GET: MedicoController
        public ActionResult ListarMedicos()  //Index
        {
            var listado = bd.Medicos.Include(d=>d.CoddisNavigation)
                                    .Include(esp=>esp.CodespNavigation)
                                    .ToList();

            return View(listado);
        }

        // GET: MedicoController/Create
        public ActionResult GrabarMedico()  // Create
        {
            Medico nuevo_med = new Medico();
            //
            ViewBag.ESPECIALIDADES = new SelectList(
                bd.Especialidads.ToList(),
                "Codesp",
                "Nomesp"
                );
            //
            ViewBag.DISTRITOS = new SelectList(
                bd.Distritos.ToList(),
                "Coddis",
                "Nomdis"
                );
            //
            return View(nuevo_med);
        }

        // POST: MedicoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GrabarMedico(Medico objMed)  // Create
        {
            try
            {
                bd.Medicos.Add(objMed);
                bd.SaveChanges();
                //
                ViewBag.MENSAJE = "Medico: " + objMed.Nommed + 
                                  " agregado correctamente";
            }
            catch (Exception ex)
            {
                ViewBag.MENSAJE = ex.Message;
            }
            //
            ViewBag.ESPECIALIDADES = new SelectList(
                bd.Especialidads.ToList(),
                "Codesp",
                "Nomesp"
                );
            //
            ViewBag.DISTRITOS = new SelectList(
                bd.Distritos.ToList(),
                "Coddis",
                "Nomdis"
                );
            //
            return View(objMed);
        }


        public ActionResult MedicosPorEspecialidad(string xcodesp="")
        {
            var listado = bd.Medicos.Include(d=>d.CoddisNavigation)
                            .Where(m => m.Codesp.Equals(xcodesp)).ToList();
            //
            ViewBag.ESPECIALIDADES = new SelectList(
                bd.Especialidads.ToList(),
                "Codesp",
                "Nomesp"
                );
            //
            return View(listado);
        }



        // GET: MedicoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MedicoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MedicoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MedicoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MedicoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
