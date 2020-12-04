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
		return context.CreateCollector(GameMatcher.Border);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isBorder;
	}

	protected override void Execute(List<GameEntity> entities) {
		// Debug.Log("sadadsadsad");
		foreach (var e in entities)
		{
			
			e.viewController.instance.boxCollider2D.size = e.borderSize.value;
			e.viewController.instance.boxCollider2D.offset = e.borderOffset.value;
			e.viewController.instance.Position = e.position.value;
			// Debug.Log("e.borderScale.value;");
			// Debug.Log(e.borderScale.value);
			e.viewController.instance.Scale = e.borderScale.value;
			e.viewController.instance.Rotation *= Quaternion.Euler(e.borderRotation.value.x, e.borderRotation.value.y,
				e.borderRotation.value.z);
		}
	}
}
