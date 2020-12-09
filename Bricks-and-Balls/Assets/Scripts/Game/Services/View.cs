using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class View : MonoBehaviour, IViewController
{
    protected Contexts _contexts;
    protected GameEntity _entity;

    public Vector2 Position
    {
        get {return transform.position;} 
        set {transform.position = value;}
    }

    public Vector2 Scale
    {
        get {return transform.localScale;} 
        set {transform.localScale = value;}
    }
    
    public Quaternion Rotation
    {
        get {return transform.rotation;} 
        set {transform.rotation = value;}
    }

    public BoxCollider2D boxCollider2D
    {
        get {return GetComponent<BoxCollider2D>();}
        set
        {
            var bc  = GetComponent<BoxCollider2D>() ;
            bc = value;
        }
    }
    
    public Rigidbody2D rigidbody2D
    {
        get {return GetComponent<Rigidbody2D>();}
        set
        {
            var bc  = GetComponent<Rigidbody2D>() ;
            bc = value;
        }
    }
    public void InitializeView(Contexts contexts, IEntity entity) {
        _contexts = contexts;
        _entity = (GameEntity)entity;
        gameObject.Link(_entity);
    }

    public void DestroyView() {
        gameObject.Unlink();
        Destroy(gameObject);
    }

}
