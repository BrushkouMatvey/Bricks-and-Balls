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
		
		var size = new Vector2(Mathf.Abs(bottomLeftScreenPoint.x - topRightScreenPoint.x), 0.1f);
		var offset = new Vector2(size.x / 2f, size.y / 2f);
		
		var entityTopBorder = _contexts.game.CreateEntity();
		entityTopBorder.isTopBorder = true;
		entityTopBorder.AddBorderSize(size);
		entityTopBorder.AddBorderOffset(offset);
		entityTopBorder.AddPosition(new Vector2(-size.x / 2f, topRightScreenPoint.y));
		
		var entityBottomBorder = _contexts.game.CreateEntity();
		entityBottomBorder.isBottomBorder = true;
		entityBottomBorder.AddBorderSize(size);
		entityBottomBorder.AddBorderOffset(offset);
		entityBottomBorder.AddPosition(new Vector2(-size.x / 2f, bottomLeftScreenPoint.y - size.y));
		
		size = new Vector2(0.1f, Mathf.Abs(topRightScreenPoint.y - bottomLeftScreenPoint.y));
		offset = new Vector2(size.x / 2f, size.y / 2f);
		
		var entityLeftBorder = _contexts.game.CreateEntity();
		entityLeftBorder.isLeftBorder = true;
		entityLeftBorder.AddBorderSize(size);
		entityLeftBorder.AddBorderOffset(offset);
		entityLeftBorder.AddPosition(new Vector2(((bottomLeftScreenPoint.x - topRightScreenPoint.x) / 2f) - size.x, bottomLeftScreenPoint.y));
		
		var entityRightBorder = _contexts.game.CreateEntity();
		entityRightBorder.isRightBorder = true;
		entityRightBorder.AddBorderSize(size);
		entityRightBorder.AddBorderOffset(offset);
		entityRightBorder.AddPosition(new Vector2(topRightScreenPoint.x, bottomLeftScreenPoint.y));
	}		
}