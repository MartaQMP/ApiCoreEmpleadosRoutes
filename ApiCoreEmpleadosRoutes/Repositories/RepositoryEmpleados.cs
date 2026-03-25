using ApiCoreEmpleadosRoutes.Data;
using ApiCoreEmpleadosRoutes.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreEmpleadosRoutes.Repositories
{
    public class RepositoryEmpleados
    {
        private EmpleadosContext context;

        public RepositoryEmpleados(EmpleadosContext context)
        {
            this.context = context;
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            return await this.context.Empleados.ToListAsync();
        }

        public async Task<Empleado> GetEmpleadoByIdAsync(int id)
        {
            return await this.context.Empleados.FirstOrDefaultAsync(e => e.IdEmpleado == id);
        }
    }
}
