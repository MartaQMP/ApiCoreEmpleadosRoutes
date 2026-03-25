using ApiCoreEmpleadosRoutes.Data;
using NuggetApiModels.Models;
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

        public async Task<List<string>> GetOficiosAsync()
        {
            return await this.context.Empleados.Select(e => e.Oficio).Distinct().ToListAsync();
        }

        public async Task<List<Empleado>> GetEmpleadosByOficioAsync(string oficio)
        {
            return await this.context.Empleados.Where(e => e.Oficio == oficio).ToListAsync();
        }

        public async Task<List<Empleado>> GetEmpleadosBySalarioAndDepartamento (int salario, int dept_no)
        {
            return await this.context.Empleados.Where(e => e.Salario >= salario && e.IdDepartamento == dept_no).ToListAsync();
        }
    }
}
