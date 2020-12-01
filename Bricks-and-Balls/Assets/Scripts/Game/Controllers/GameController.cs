using System.Collections;
using System.Collections.Generic;
using Entitas;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Globals gameSetup;
    private Systems _systems;
    // Start is called before the first frame update
    private void Start()
    {
        var _contexts = Contexts.sharedInstance;
        // InputService inputService = new InputService();
        // _contexts.allContexts.
        _contexts.game.SetGlobals(gameSetup);
        _contexts.input.SetGlobals(gameSetup);
        _systems = CreateSystems(_contexts);
        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Systems")
            .Add(new GameSystems(contexts))
            .Add(new InputSystems(contexts))
            .Add(new ViewSystems(contexts))
            .Add(new CommonSystems(contexts))
            .Add(new ScreenSystems(contexts));
    }
}
