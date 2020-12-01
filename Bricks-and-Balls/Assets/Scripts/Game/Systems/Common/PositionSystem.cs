using Entitas;
using System.Collections.Generic;

public class PositionSystem : ReactiveSystem<GameEntity> {
    private Contexts _contexts;

	public PositionSystem (Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
		return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.View));
	}

	protected override bool Filter(GameEntity entity) {
		return entity.hasView && entity.hasPosition;
	}

	protected override void Execute(List<GameEntity> entities) {
		foreach (var e in entities)
		{
			e.view.gameObject.transform.position = e.position.value;
		}
	}
}

