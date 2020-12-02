using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class CreateBorderSystem : ReactiveSystem<GameEntity> {
    private Contexts _contexts;
    public CreateBorderSystem (Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		Collector<GameEntity> collector = new Collector<GameEntity>(new [] {
				context.GetGroup(GameMatcher.LeftBorder),
				context.GetGroup(GameMatcher.RightBorder),
				context.GetGroup(GameMatcher.TopBorder),
				context.GetGroup(GameMatcher.BottomBorder)
			},
			new [] {
				GroupEvent.Added,
				GroupEvent.Added,
				GroupEvent.Added,
				GroupEvent.Added
			});
		Debug.Log(collector.count);
		return collector;
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isTopBorder
		       || entity.isBottomBorder
		       || entity.isLeftBorder
		       || entity.isRightBorder;
	}

	protected override void Execute(List<GameEntity> entities) {
		foreach (var e in entities)
		{
			GameObject gameObject;
			gameObject = new GameObject();
			BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
			collider.size = e.borderSize.value;
			collider.offset = e.borderOffset.value;
			gameObject.transform.position = e.position.value;
		}
	}
}