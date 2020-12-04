using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class CheckFirstBallPosition : ReactiveSystem<GameEntity> {
    private Contexts _contexts;

	public CheckFirstBallPosition (Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
		return context.CreateCollector(GameMatcher.AllOf(GameMatcher.FirstBallPosition, GameMatcher.Ball));
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasFirstBallPosition && entity.isBall;
	}

	protected override void Execute(List<GameEntity> entities) {
		foreach (var e in entities)
		{
			e.viewController.instance.rigidbody2D.velocity = Vector3.zero;
		}
	}
}