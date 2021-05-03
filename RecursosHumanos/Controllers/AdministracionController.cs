using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecursosHumanos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecursosHumanos.Controllers
{
    [Authorize]
    public class AdministracionController : Controller
    {
        private readonly RoleManager<IdentityRole> gestionRoles;
        private readonly UserManager<Usuario> gestionUsuarios;
        public AdministracionController(RoleManager<IdentityRole> gestionRoles,
            UserManager<Usuario> gestionUsuarios)
        {
            this.gestionRoles = gestionRoles;

            this.gestionUsuarios = gestionUsuarios;
        }

        [HttpGet]
        [Route("Administracion/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Administracion/Create")]
        public async Task<IActionResult> Create(Rol model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole IdentityRole = new IdentityRole
                {
                    Name = model.NombreRol
                };
                IdentityResult result = await gestionRoles.CreateAsync(IdentityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        [Route("Administracion/ListaRoles")]
        public IActionResult ListaRoles()
        {
            var roles = gestionRoles.Roles;
            return View(roles);
        }

        [HttpGet]
        [Route("Administracion/Edit")]
        public async Task<IActionResult> Edit(string Id)
        {
            var rol = await gestionRoles.FindByIdAsync(Id);
            if (rol == null)
            {
                ViewBag.ErrorMessage = $"Rol con el Id ={Id} no fue encontrado";
                return View("Error");
            }
            var model = new EditarRol
            {
                Id = rol.Id,
                NombreRol = rol.Name
            };
            foreach(var usuario in gestionUsuarios.Users)
            {
                if(await gestionUsuarios.IsInRoleAsync(usuario, rol.Name))
                {
                    model.Usuario.Add(usuario.UserName);
                }
            }
            return View(model);
        }
        [HttpPost]
        [Route("Administracion/Edit")]
        public async Task<IActionResult> Edit(EditarRol model)
        {
            var rol = await gestionRoles.FindByIdAsync(model.Id);
            if (rol == null)
            {
                ViewBag.ErrorMessage = $"Rol con el Id = {model.Id} no fu encontrado";
                return View("Error");
            }
            else
            {
                rol.Name = model.NombreRol;

                var resultado = await gestionRoles.UpdateAsync(rol);

                if (resultado.Succeeded)
                {
                    return RedirectToAction("ListaRoles");
                }
                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }
        [HttpGet]
        [Route("Administracion/EditUserRol")]
        public async Task<IActionResult> EditUsuarioRol(string rolId)
        {
            ViewBag.rolId = rolId;

            var role = await gestionRoles.FindByIdAsync(rolId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Rol con el Id = {rolId} no fue encontrado";
                return View("Error");
            }
            var model = new List<UsuarioRol>();

            foreach (var user in gestionUsuarios.Users)
            {

                var usuarioRol = new UsuarioRol
                {
                    UsuarioId = user.Id,
                    UsuarioNombre = user.UserName
                };

                if (await gestionUsuarios.IsInRoleAsync(user, role.Name))
                {
                    usuarioRol.EstaSeleccionado = true;
                }
                else
                {
                    usuarioRol.EstaSeleccionado = false;
                }
                model.Add(usuarioRol);
            }
            return View(model);
        }
        [HttpPost]
        [Route("Administracion/EditUserRol")]
        public async Task<IActionResult> EditUsuarioRol(List<UsuarioRol> model,
            string rolId)
        {
            var rol = await gestionRoles.FindByIdAsync(rolId);

            if (rol == null)
            {
                ViewBag.ErrorMessage = $"Rol con el Id = {rolId} no fue encontrado";
                return View("Error");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await gestionUsuarios.FindByIdAsync(model[i].UsuarioId);

                IdentityResult result = null;

                if (model[i].EstaSeleccionado && !(await gestionUsuarios.IsInRoleAsync(user, rol.Name)))
                {
                    result = await gestionUsuarios.AddToRoleAsync(user, rol.Name);
                }
                else if (!model[i].EstaSeleccionado && await gestionUsuarios.IsInRoleAsync(user, rol.Name))
                {
                    result = await gestionUsuarios.RemoveFromRoleAsync(user, rol.Name);
                }
                else
                {
                    continue;
                }
                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditarRol", new { Id = rolId });
                }
            }
            return RedirectToAction("EditarRol", new { Id = rolId });
        }
    }   

}
