using Entitas;
using System.Collections.Generic;
using System.Linq;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.UI;

public class ReactCollisionSystem : ReactiveSystem<GameEntity> {
    private Contexts _contexts;
    private IGroup<GameEntity> _levels;
    private int _numOfBalls = 5;
    private int ballCount = 0;
    GameEntity firstBallEndTurn = null;

	public ReactCollisionSystem (Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
        // foreach (var l in _contexts.game.GetGroup(GameMatcher.Level).GetEntities())
        // {
	       //  _numOfBalls = l.level.value.NumOfBalls;
        // }
        // Debug.Log("_numOfBalls::");
        // Debug.Log(_numOfBalls);
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
		return context.CreateCollector(GameMatcher.Collision);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasCollision;
	}

	protected override void Execute(List<GameEntity> entities) {
		foreach (var l in _contexts.game.GetGroup(GameMatcher.Level).GetEntities()) 
			_numOfBalls = l.level.value.NumOfBalls; 
		var _inputEntities = _contexts.input.GetEntities(InputMatcher.ClickUp).ToList();
		var _timerEntities = _contexts.game.GetEntities(GameMatcher.Timer).ToList();
		var _ballEntities = _contexts.game.GetEntities(GameMatcher.Ball).ToList();
		var _blockEntities = _contexts.game.GetEntities(GameMatcher.Block).ToList();
		foreach (var e in entities)
		{
			var first= e.collision.first;
			var second= e.collision.second;
			
			if (second.isBlock)
			{
				if (second.health.value > 0)
					second.ReplaceHealth(second.health.value - 1);
				else second.isDestroy = true;
			}

			if (second.hasBombBlock)
			{
				if (second.health.value > 0)
					second.ReplaceHealth(second.health.value - 1);
				else second.isDestroy = true;
			}

			if (second.isBottomBorder)
			{
				Debug.Log(ballCount);
				if (ballCount == 0)
				{
					firstBallEndTurn = first;
					first.ReplacePosition(first.viewController.instance.Position);
					first.AddFirstBallPosition(first.position.value);
					ballCount++;
				}
				else if (ballCount < _numOfBalls)
				{
					first.viewController.instance.rigidbody2D.velocity = Vector3.zero;
					first.ReplacePosition(firstBallEndTurn.position.value);
					if (ballCount == _numOfBalls - 1)
					{
						foreach (var bl in _blockEntities)
							bl.ReplacePosition(new Vector2(bl.position.value.x,bl.position.value.y -1 ));
						foreach (var b in _ballEntities)
							b.RemoveMove();
						foreach (var i in _inputEntities)
							i.isClickUp = false;
						foreach (var t in _timerEntities)
							t.Destroy();
						ballCount = 0;
						firstBallEndTurn.RemoveFirstBallPosition();
					}
					else ballCount++;
					// first.ReplaceEndTurnMove(firstBallEndTurn.position.value,first.position.value, 300.0f);
				}
			}
			
			

			e.Destroy();
		}
	}
}