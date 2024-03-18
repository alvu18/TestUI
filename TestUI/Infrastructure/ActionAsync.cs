using System.Threading.Tasks;

namespace TestUI.Infrastructure
{
    internal delegate Task ActionAsync();

    internal delegate Task ActionAsync<in T>(T parameter);
}
