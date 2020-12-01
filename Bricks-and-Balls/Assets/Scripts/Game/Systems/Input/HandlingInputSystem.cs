using Entitas;
using UnityEngine;

public class HandlingInputSystem : IInitializeSystem, IExecuteSystem  {
	private InputContext _contexts;
	private InputEntity _clickEntity;
    public HandlingInputSystem(Contexts contexts) {
    	_contexts = contexts.input;
    }
    
    public void Initialize()
    {
	    _clickEntity = _contexts.CreateEntity();
    }
    
	public void Execute() {
		
		if (InputService.isScreenDownClick())
		{
			Debug.Log("11111");
			_clickEntity.ReplaceMousePosition(InputService.clickPosition);
			_clickEntity.isClickDown = true;
		}
		if (InputService.isScreenHoldingClick())
		{
			Debug.Log("22222");
			_clickEntity.ReplaceMousePosition(InputService.clickPosition);
			_clickEntity.isHoldingClick = true;
		}
		if (InputService.isScreenUpClick())
		{
			_clickEntity.ReplaceMousePosition(InputService.clickPosition);
			_clickEntity.isClickUp = true;
		}
	}

	
}