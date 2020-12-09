using Entitas;
using Entitas.Unity;
using UnityEngine;

public class MoveListener: MonoBehaviour, IEventListener, IMoveListener
{
    private GameEntity _entity;
    [SerializeField] private Rigidbody2D _rigidbody;
    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddMoveListener(this);
    }

    public void OnMove(GameEntity entity, Vector2 direction, float force)
    {
        _rigidbody.AddForce(direction * force);
    }
}