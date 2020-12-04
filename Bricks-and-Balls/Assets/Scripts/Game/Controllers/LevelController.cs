using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private Level level;
    public Level Level
    {
        get => level;
        set => level = value;
    }


    public void LoadLevel(TextAsset textAsset)
    {
        level = JsonConvert.DeserializeObject<Level>(textAsset.text);
    }
}
