using Entitas;
using UnityEngine;

[Game]
public class MoveComponent : IComponent
{
    public Vector2 direction;
    public float force;
}