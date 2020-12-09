using Entitas;

public class EventSystems : Feature  {
    public EventSystems(Contexts contexts) {
        //Listeners
        Add(new PositionEventSystem(contexts));
        Add(new DestroyEventSystem(contexts));
        Add(new MoveEventSystem(contexts));
        Add(new HealthEventSystem(contexts));
        Add(new EndTurnMoveEventSystem(contexts));
        Add(new SmoothlyMoveEventSystem(contexts));
    }	
}