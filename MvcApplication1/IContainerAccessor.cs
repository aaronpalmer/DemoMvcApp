using Microsoft.Practices.Unity;

namespace MvcApplication1
{
    public interface IContainerAccessor
    {
        IUnityContainer Container { get; }
    }
}