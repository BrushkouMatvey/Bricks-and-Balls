using Entitas;
using UnityEngine;

public class ScreenColliderInitializeSystem : IInitializeSystem  {
	private Contexts _contexts;

    public ScreenColliderInitializeSystem(Contexts contexts) {
    	_contexts = contexts;
    }

	public void Initialize()
	{
		Vector3 bottomLeftScreenPoint = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));
		Vector3 topRightScreenPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
		
		var size = new Vector2(Mathf.Abs(bottomLeftScreenPoint.x - topRightScreenPoint.x), 0.15f);
		var offset = new Vector2(size.x / 2f, size.y / 2f);
		
		CreateBorderEntity(size, offset, new Vector2(-size.x / 2f, topRightScreenPoint.y), 
											new Vector2(size.x, 1),
											new Vector3(0, 0, 0),
											_contexts.game.globals.value.borderScreenHorizontal);
		var bottomBorder = CreateBorderEntity(size, new Vector2(offset.x, 0), 
												new Vector2(-size.x / 2f, - topRightScreenPoint.y), 
													new Vector2(size.x, 1),
												new Vector3(0, 0, 0),
												_contexts.game.globals.value.borderScreenHorizontal);
		bottomBorder.isBottomBorder = true;
		
		size = new Vector2(0.15f, Mathf.Abs(topRightScreenPoint.y - bottomLeftScreenPoint.y));
		offset = new Vector2(-0.02f, size.y / 2f);
		CreateBorderEntity(size, offset, 
			new Vector2(-topRightScreenPoint.x, bottomLeftScreenPoint.y), 
				new Vector2(1, size.y),
			new Vector3(0, 0, 0),
					_contexts.game.globals.value.borderScreenVertical);
		
		CreateBorderEntity(size,
			new Vector2(0.01f, offset.y),
			new Vector2(topRightScreenPoint.x, bottomLeftScreenPoint.y), 
			new Vector2(1, size.y),
			new Vector3(0, 0, 0),
			_contexts.game.globals.value.borderScreenVertical);
	}

	public GameEntity CreateBorderEntity(Vector2 size, Vector2 offset, Vector2 position, Vector2 scale, Vector3 rotation, GameObject prefab)
	{
		var entityBorder = _contexts.game.CreateEntity();
		entityBorder.isBorder = true;
		entityBorder.AddResource(prefab);
		entityBorder.AddBorderSize(size);
		entityBorder.AddBorderOffset(offset);
		entityBorder.AddPosition(position);
		entityBorder.AddBorderScale(scale);
		entityBorder.AddBorderRotation(rotation);

		return entityBorder;
	}
}