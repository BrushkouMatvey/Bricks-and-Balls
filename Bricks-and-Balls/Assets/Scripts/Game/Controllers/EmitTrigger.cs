using System.Collections;
using System.Collections.Generic;
using Entitas.Unity;
using UnityEngine;
using Entitas;

public class EmitTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Debug.Log("OnCollisionEnter2D");
        // Debug.Log(gameObject.transform.position);
        // Debug.Log(other.gameObject.transform.position);
        var firstLink = gameObject.GetEntityLink().entity;
        var secondLink = other.gameObject.GetEntityLink().entity;
        var entity = Contexts.sharedInstance.game.CreateEntity();
        entity.AddCollision((GameEntity)firstLink,(GameEntity)secondLink);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("OnTriggerEnter2D");
        var firstLink = gameObject.GetEntityLink().entity;
        var secondLink = other.gameObject.GetEntityLink().entity;
        var entity = Contexts.sharedInstance.game.CreateEntity();
        entity.AddCollision((GameEntity)firstLink,(GameEntity)secondLink);
    }
}
