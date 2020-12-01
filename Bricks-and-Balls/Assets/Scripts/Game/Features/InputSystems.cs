using Entitas;

public class InputSystems : Feature  {
    public InputSystems(Contexts contexts): base("Input Systems") 
    {
        Add(new HandlingInputSystem(contexts));
        Add(new HandlingDownHoldingSystem(contexts));
        Add(new UpHoldingSystem(contexts));
    }	
}