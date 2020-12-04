using Entitas;
using UnityEngine;

public class HealthCheckSystem : IExecuteSystem  {
	private Contexts _contexts;
	private IGroup<GameEntity> healthEntityGroup;

    public HealthCheckSystem(Contexts contexts) {
    	_contexts = contexts;
    }

	public void Execute()
	{
		healthEntityGroup = _contexts.game.GetGroup(GameMatcher.Health);
		var blockHealthCheckEntities = healthEntityGroup.GetEntities();
		foreach (var e in blockHealthCheckEntities)
		{
			if (e.health.value == 0)
			{
				e.isDestroy = true;
			}
		}
	}
}