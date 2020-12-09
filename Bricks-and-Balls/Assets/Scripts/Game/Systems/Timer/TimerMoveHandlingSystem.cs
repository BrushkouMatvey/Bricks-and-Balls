using Entitas;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TimerMoveHandlingSystem : ReactiveSystem<GameEntity> {
    private Contexts _contexts;
    private List<InputEntity> _inputEntities;
    
    public TimerMoveHandlingSystem (Contexts contexts) : base(contexts.game) {
        _contexts = contexts;
    }

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {

		return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Timer, GameMatcher.TimerEnd));
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasTimer && entity.isTimerEnd;
	}

	protected override void Execute(List<GameEntity> timerEntities)
	{
		_inputEntities = _contexts.input.GetEntities(InputMatcher.ClickUp).ToList();
		foreach (var e in _inputEntities) {
			var mousePosition = e.mousePosition.value;
			var ballEntities = _contexts.game.GetEntities(GameMatcher.Ball).ToList();
			var ball = ballEntities.FindLast(s => !s.hasMove);
			if (ball == null) return;
			var direction = (mousePosition - ball.position.value);
			direction.Normalize();
			ball.ReplaceMove(direction, 300);

			foreach (var te in timerEntities)
			{
				te.ReplaceTimer(0.1f);
				te.isTimerRun = true;
				te.isTimerEnd = false;
			}
		}
	}
}