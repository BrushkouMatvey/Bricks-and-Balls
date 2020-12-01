using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Input, CreateAssetMenu, Unique]
public class Globals : ScriptableObject
{
    public GameObject ball;
    public GameObject rectangleSimpleBlock;
    public GameObject circleSimpleBlock;
    public GameObject rhombusSimpleBlock;
    public GameObject triangleSimpleBlock;
    public GameObject laserBlock;
    public GameObject bombBlock;
}
