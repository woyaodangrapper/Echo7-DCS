namespace ECHO.Infrastructure.Core.Interfaces;

public interface IDependencyRegistrar
{
    public string Name { get; }

    public void AddDcs();
}