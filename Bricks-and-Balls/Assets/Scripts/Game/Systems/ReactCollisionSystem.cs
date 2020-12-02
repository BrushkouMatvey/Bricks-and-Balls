using Entitas;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactCollisionSystem : ReactiveSystem<GameEntity> {
    private Contexts _contexts;

	public ReactCollisionSystem (Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
		return context.CreateCollector(GameMatcher.Collision);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasCollision;
	}

	protected override void Execute(List<GameEntity> entities) {
		foreach (var e in entities)
		{
			var first = e.collision.first;
			var second = e.collision.second;


			var firstEntity = _contexts.game.GetEntitiesWithView(first).SingleEntity();
			var secondEntity = _contexts.game.GetEntitiesWithView(second).SingleEntity();
			Debug.Log(firstEntity);
			Debug.Log(secondEntity);
			if (secondEntity.isBlock)
			{
				if (secondEntity.health.value > 0)
				{
					secondEntity.health.value -= 1;
					var text = second.GetComponentInChildren<Text>();
					text.text = secondEntity.health.value.ToString();
				}
				else
				{
					secondEntity.isDestroy = true;
				}
			}

		}
	}
}