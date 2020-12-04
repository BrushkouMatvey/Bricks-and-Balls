using Entitas;
using Entitas.Unity;
using UnityEngine;

public class EndTurnMoveListener: MonoBehaviour, IEventListener, IEndTurnMoveListener
{
    private GameEntity _entity;
    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddEndTurnMoveListener(this);
    }

    public void OnEndTurnMove(GameEntity entity, Vector2 current, Vector2 target, float maxDistanceDelta)
    {
        entity.viewController.instance.Position = Vector2.MoveTowards(current, target, maxDistanceDelta);
    }
}