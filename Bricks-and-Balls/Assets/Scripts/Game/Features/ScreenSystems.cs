using Entitas;

public class ScreenSystems : Feature  {
    public ScreenSystems(Contexts contexts)
    {
        Add(new ScreenColliderInitializeSystem(contexts));
        Add(new CreateBorderSystem(contexts));
    }	
}