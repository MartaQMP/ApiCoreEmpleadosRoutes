using NuggetApiModels.Models;
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

        [HttpGet]
        [Route("TodosLosOficios")]
        public async Task<ActionResult<List<string>>> GetOficios()
        {
            return await this.repo.GetOficiosAsync();
        }

        [HttpGet]
        [Route("[action]/{oficio}")]
        public async Task<ActionResult<List<Empleado>>> GetEmpleadosByOficio(string oficio)
        {
            return await this.repo.GetEmpleadosByOficioAsync(oficio);
        }

        [HttpGet]
        [Route("[action]/{salario}/{iddepartamento}")]
        public async Task<ActionResult<List<Empleado>>> GetEmpleadosBySalarioAndDepartamento(int salario, int iddepartamento)
        {
            return await this.repo.GetEmpleadosBySalarioAndDepartamento(salario, iddepartamento);
        }
    }

}
