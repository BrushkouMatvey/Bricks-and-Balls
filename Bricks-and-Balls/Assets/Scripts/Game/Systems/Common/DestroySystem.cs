using Entitas;
using System.Collections.Generic;
using Entitas.Unity;
using UnityEngine;

public class DestroySystem : ReactiveSystem<GameEntity> {
    private Contexts _contexts;

	public DestroySystem (Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
		return context.CreateCollector(GameMatcher.Destroy);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isDestroy;
	}

	protected override void Execute(List<GameEntity> entities) {
		foreach (var e in entities) {
			if (e.hasView)
			{
				var view = e.view.gameObject;
				view.Unlink();
				GameObject.Destroy(view);
			}
			e.Destroy();
		}
	}
}