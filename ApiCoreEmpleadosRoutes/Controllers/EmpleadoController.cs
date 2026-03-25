using ApiCoreEmpleadosRoutes.Models;
using ApiCoreEmpleadosRoutes.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreEmpleadosRoutes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private RepositoryEmpleados repo;

        public EmpleadoController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Empleado>>> Get()
        {
            return await this.repo.GetEmpleadosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> Find(int id)
        {
            return await this.repo.GetEmpleadoByIdAsync(id);
        }
    }

}
