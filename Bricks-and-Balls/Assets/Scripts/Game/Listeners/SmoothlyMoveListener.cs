// using Entitas;
// using Entitas.Unity;
// using UnityEngine;
//
// public class SmoothlyMoveListener: MonoBehaviour, IEventListener, ISmoothlyMoveListener
// {
//     private GameEntity _entity;
//     public void RegisterListeners(IEntity entity)
//     {
//         _entity = (GameEntity) entity;
//         _entity.AddSmoothlyMoveListener(this);
//     }
//     
//     public void OnSmoothlyMove(GameEntity entity, Vector2 startPosition, Vector2 endPosition)
//     {
//         throw new System.NotImplementedException();
//     }
// }