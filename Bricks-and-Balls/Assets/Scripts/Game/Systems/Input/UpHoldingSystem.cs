//
// using Entitas;
// using UnityEngine;
//
// public class UpHoldingSystem : IExecuteSystem  {
// 	private Contexts _contexts;
// 	private IGroup<InputEntity> clickUpInputsEnities;
// 	private IGroup<GameEntity> gameStateEnities;
// 	public UpHoldingSystem(Contexts contexts) {
//     	_contexts = contexts;
// 	}
//
// 	public void Execute() {
// 		clickUpInputsEnities = _contexts.input.GetGroup(InputMatcher.ClickUp);
// 		gameStateEnities = _contexts.game.GetGroup(GameMatcher.MoveGameState);
// 		foreach (var UPPeER in gameStateEnities)
// 		{
// 			
// 		}
// 		// Debug.Log("1:" + gameStateEnities.count);
// 		// Debug.Log( clickUpInputsEnities == null);
// 		Debug.Log(gameStateEnities == null);
// 		if (gameStateEnities == null && clickUpInputsEnities != null)
// 		{
// 			Debug.Log("qweqweqweqwe1");
// 			var timerEntity = _contexts.game.CreateEntity();
// 			timerEntity.isTimerEnd = true;
// 			var gameInputStateEntity = _contexts.game.CreateEntity();
// 			gameInputStateEntity.isMoveGameState = true;
// 		}
//
// 	}
// }

using Entitas;
using System.Collections.Generic;
using UnityEngine;

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
		foreach (var e in entities) {
			Debug.Log("СТАВИМ ТАЙМЕР");
			var timerEntity = _contexts.game.CreateEntity();
			timerEntity.AddTimer(0);
			timerEntity.isTimerEnd = true;
		}
	}
}