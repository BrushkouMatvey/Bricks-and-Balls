using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    public string LevelName;
    public List<int> VisibleAreaSize;
    public int NumOfBalls;
    public List<BlockStruct> Blocks = new List<BlockStruct>();
}


