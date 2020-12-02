using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        var entity = Contexts.sharedInstance.game.CreateEntity();
        entity.AddCollision(this.gameObject, other.gameObject);
    }
}
