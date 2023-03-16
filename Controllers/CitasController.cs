using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AppMVC_Core_BDCLINICA.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppMVC_Core_BDCLINICA.Controllers
{
    public class CitasController : Controller
    {
        BDCLINICA2022Context bd = new BDCLINICA2022Context();

        public IActionResult CitasPorPaciente(string codigopac="", int año=0)
        {
            // llamando al procedimiento almacenado
            var listado = bd.PA_CITAS_PACIENTE
                            .FromSqlRaw<PA_CITAS_PACIENTE>("PA_CITAS_PACIENTE {0}", codigopac)
                            .ToList();
            //
            ViewBag.PACIENTES = new SelectList(
                bd.Pacientes.ToList(),
                "Codpac",
                "Nompac"
                );
            //
            // OBTENIENDO LOS AÑOS DE LAS CITAS
            var lista_años = bd.Citas
                               .Select(x=>x.Fecha.Value.Year)
                               .Distinct()
                               .ToList();
            //
            ViewBag.AÑOS = new SelectList(lista_años);
            //
            var lista_nom_pac = bd.Pacientes
                                  .Select(p => p.Nompac)
                                  .ToList();
           
            //
            return View(listado);
        }
    }
}
