using Entitas;

public class GameSystems : Feature  {
    public GameSystems(Contexts contexts): base("Game Systems") 
    {

        // Add(new MoveEventSystem(contexts));
        Add(new LevelInirializeSystem(contexts));
        Add(new TimerSystem(contexts));
        Add(new TimerMoveHandlingSystem(contexts));
        Add(new ReactCollisionSystem(contexts));
        Add(new HealthCheckSystem(contexts));
        // Add(new DestroySystem(contexts));

    }	
}