using System.Collections.Generic;

[System.Serializable]
public struct BlockStruct
{
    
    public BlockType Type;
    public SimpleBlockType SimpleBlockType;
    public int Height;
    public int Width;
    public int X;
    public int Y;
    public int Health;
    public int LaserLength;
    public List<int> Angles;
    public int Damage;
    public int DamageAreaSize;
}