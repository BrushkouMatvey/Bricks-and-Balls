using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class ViewControllerComponent : IComponent
{
    [EntityIndex]
    public IViewController instance;
}    