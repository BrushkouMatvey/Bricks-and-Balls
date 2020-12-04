using Entitas;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.UI;

public class HealthListener: MonoBehaviour, IEventListener, IHealthListener
{
    private GameEntity _entity;
    public void RegisterListeners(IEntity entity)
    {
        _entity = (GameEntity) entity;
        _entity.AddHealthListener(this);
        if (_entity.hasHealth) OnHealth(_entity, _entity.health.value);
    }

    public void OnHealth(GameEntity entity, int value)
    {
        var t = GetComponentInChildren<Text>();
        t.text = value.ToString();
    }
}