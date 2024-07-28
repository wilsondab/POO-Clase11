using Ejercicio4Modulo3.Models;
using System.Threading.Tasks;

public interface IProveedorService
{
    public Task<List<Proveedor>> getProveedores();
    public Task saveProveedor(Proveedor proveedor);

}