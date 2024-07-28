using Ejercicio4Modulo3.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class ProveedorService : IProveedorService 
{

    private Ejercicio4Modulo3Context context;
    public ProveedorService(Ejercicio4Modulo3Context context)
    {
        this.context = context;
    }

    public async Task<List<Proveedor>> getProveedores()
    {
        return await context.Proveedor.ToListAsync();
    }

    public async Task saveProveedor(Proveedor proveedor)
    {
        await context.AddAsync(proveedor);
        await context.SaveChangesAsync();
    }
}
