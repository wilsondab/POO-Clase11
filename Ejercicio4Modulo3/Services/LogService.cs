
using Ejercicio4Modulo3.Models;

public class LogService : ILogService
{

    private Ejercicio4Modulo3Context context;
    public LogService(Ejercicio4Modulo3Context context)
    {
        this.context = context;
    }

    public async Task saveLog(Logs log)
    {
        await context.AddAsync(log);
        await context.SaveChangesAsync();
    }
}
