using Entitas;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.UI;

public class DestroyListener: MonoBehaviour, IEventListener, IDestroyListener
{
    private GameEntity _entity;
    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddDestroyListener(this);
    }
    public void OnDestroy(GameEntity entity)
    {
        entity.viewController.instance.DestroyView();
        entity.Destroy();
    }
}