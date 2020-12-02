using Entitas;
using System.Collections.Generic;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateViewSystem : ReactiveSystem<GameEntity> {
    private Contexts _contexts;

	public InstantiateViewSystem (Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) 
	{
		return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.Resource, GameMatcher.Health));
	}

	protected override bool Filter(GameEntity entity) 
	{
		return entity.hasResource || entity.hasHealth;
	}

	protected override void Execute(List<GameEntity> entities) {
		foreach (var e in entities)
		{
			var gameObject = GameObject.Instantiate(e.resource.prefab);
			e.AddView(gameObject);
			gameObject.Link(e);
			if (e.hasPosition && e.hasHealth)
			{
				gameObject.transform.position = e.position.value;
				var text = gameObject.GetComponentInChildren<Text>();
				text.text = e.health.value.ToString();
			}
			else if (e.hasPosition)
			{
				gameObject.transform.position = e.position.value;
			}
		}
	}
}