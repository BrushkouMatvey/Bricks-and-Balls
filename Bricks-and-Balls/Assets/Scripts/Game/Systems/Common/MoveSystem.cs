using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystem : ReactiveSystem<GameEntity> {
    private Contexts _contexts;

	public MoveSystem (Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
		return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.Move));
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasMove;
	}

	protected override void Execute(List<GameEntity> entities) {
		foreach (var e in entities)
		{
			var rigidbody2D = e.view.gameObject.GetComponent<Rigidbody2D>();
			// rigidbody2D.velocity = new Vector2(2, 2);
			rigidbody2D.AddForce(e.move.direction * e.move.force);
		}
	}
}