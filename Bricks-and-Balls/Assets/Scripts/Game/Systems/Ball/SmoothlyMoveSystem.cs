using Entitas;
using UnityEngine;

public class SmoothlyMoveSystem : IExecuteSystem  {
	private Contexts _contexts;
	private IGroup<GameEntity> ballsToMove;

    public SmoothlyMoveSystem(Contexts contexts) {
    	_contexts = contexts;
        ballsToMove = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.Ball, GameMatcher.SmoothlyMove));
    }

	public void Execute()
	{
		var entities = ballsToMove.GetEntities();
		if (entities.Length != 0)
		{
			foreach (var ball in entities)
			{
				if (ball.smoothlyMove.startPosition != ball.smoothlyMove.endPosition)
				{
					ball.ReplacePosition(Vector2.MoveTowards(ball.smoothlyMove.startPosition, ball.smoothlyMove.endPosition,
						4.0f * Time.deltaTime));
					ball.ReplaceSmoothlyMove(ball.position.value, ball.smoothlyMove.endPosition);
				}
				else 
					ball.RemoveSmoothlyMove();
			}
		}
	}
}