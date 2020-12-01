using Entitas;
using System.Collections.Generic;

public class UpHoldingSystem : ReactiveSystem<InputEntity> {
    private Contexts _contexts;

	public UpHoldingSystem (Contexts contexts) : base(contexts.input) {
        _contexts = contexts;
	}

	protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
		return context.CreateCollector(InputMatcher.ClickUp);
	}

	protected override bool Filter(InputEntity entity)
	{
		return entity.isClickUp;
	}

	protected override void Execute(List<InputEntity> entities) {
		
		foreach (var e in entities)
		{
			var mousePosition = e.mousePosition.value;
			var ballEntities = _contexts.game.GetGroup(GameMatcher.Ball);
			foreach (var ball in ballEntities)
			{
				var direction = mousePosition - ball.position.value;
				ball.ReplaceMove(direction, 150);
			}

			e.isClickUp = false;
		}
	}
}