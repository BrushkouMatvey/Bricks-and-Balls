using Entitas;
using UnityEngine;
using UnityEngine.iOS;

public class HandlingInputSystem : IInitializeSystem, IExecuteSystem  {
	private InputContext _inputContexts;
	private GameContext _gameContexts;
	private InputEntity _clickEntity;
	private GameEntity _gameInputStateEntity;
    public HandlingInputSystem(Contexts contexts) {
	    _gameContexts = contexts.game;
	    _inputContexts = contexts.input;
    }
    
    public void Initialize()
    {
	    _clickEntity = _inputContexts.CreateEntity();
	    _gameInputStateEntity = _gameContexts.CreateEntity();
    }
    
	public void Execute() {
		
		if (InputService.isScreenDownClick())
		{
			_clickEntity.ReplaceMousePosition(InputService.clickPosition);
			_clickEntity.isClickDown = true;
		}
		if (InputService.isScreenHoldingClick())
		{
			_clickEntity.ReplaceMousePosition(InputService.clickPosition);
			_clickEntity.isHoldingClick = true;
		}
		if (InputService.isScreenUpClick())
		{
			_clickEntity.ReplaceMousePosition(InputService.clickPosition);
			_clickEntity.isHoldingClick = false;
			_clickEntity.isClickUp = true;
			Debug.Log("_clickEntity.isClickUp = true;");

		}
	}

	
}