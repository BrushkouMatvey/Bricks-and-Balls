using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Globals gameSetup;
    private Systems _systems;
    // Start is called before the first frame update
    private void Start()
    {
        var _contexts = Contexts.sharedInstance;
        _contexts.game.SetGlobals(gameSetup);
        var levelEntity = _contexts.game.CreateEntity();

        _systems = CreateSystems(_contexts);
        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
            .Add(new LevelInirializeSystem(contexts))
            .Add(new InstantiateViewSystem(contexts));
    }
}
