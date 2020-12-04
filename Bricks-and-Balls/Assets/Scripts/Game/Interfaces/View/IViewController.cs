using Entitas;
using UnityEngine;

public interface IViewController {
    Vector2 Position {get; set;}
    Vector2 Scale {get; set;}
    BoxCollider2D boxCollider2D { get; set;}
    Rigidbody2D rigidbody2D{ get; set;}
    Quaternion Rotation{ get; set;}
    
    // bool Active {get; set;}
    void InitializeView(Contexts contexts, IEntity Entity);
    void DestroyView();
}