using Entitas;

public class CommonSystems : Feature  {
    public CommonSystems(Contexts contexts)
    {
        Add(new MoveSystem(contexts));
        Add(new PositionSystem(contexts));
    }	
}