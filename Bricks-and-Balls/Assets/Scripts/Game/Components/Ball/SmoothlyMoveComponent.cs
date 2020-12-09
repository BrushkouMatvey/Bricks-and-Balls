using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Event(EventTarget.Self)]
public class SmoothlyMoveComponent : IComponent
{
    public Vector2 startPosition;
    public Vector2 endPosition;
}