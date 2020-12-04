using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Event(EventTarget.Self)]
public class EndTurnMoveComponent : IComponent
{
    public Vector2 current;
    public Vector2 target;
    public float maxDistanceDelta;
}