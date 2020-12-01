using Entitas;
using System.Collections.Generic;

public class HandlingDownHoldingSystem : ReactiveSystem<InputEntity> {
    private Contexts _contexts;

	public HandlingDownHoldingSystem (Contexts contexts) : base(contexts.input) {
        _contexts = contexts;
	}

	protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
		return context.CreateCollector(InputMatcher.AllOf(InputMatcher.ClickDown, InputMatcher.HoldingClick));
	}

	protected override bool Filter(InputEntity entity)
	{
		return entity.isClickDown || entity.isHoldingClick;
	}

	protected override void Execute(List<InputEntity> entities) {
		foreach (var e in entities) {
			
		}
	}
}