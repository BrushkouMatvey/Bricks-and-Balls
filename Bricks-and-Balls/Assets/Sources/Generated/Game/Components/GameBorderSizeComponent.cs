//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public BorderSizeComponent borderSize { get { return (BorderSizeComponent)GetComponent(GameComponentsLookup.BorderSize); } }
    public bool hasBorderSize { get { return HasComponent(GameComponentsLookup.BorderSize); } }

    public void AddBorderSize(UnityEngine.Vector2 newValue) {
        var index = GameComponentsLookup.BorderSize;
        var component = (BorderSizeComponent)CreateComponent(index, typeof(BorderSizeComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceBorderSize(UnityEngine.Vector2 newValue) {
        var index = GameComponentsLookup.BorderSize;
        var component = (BorderSizeComponent)CreateComponent(index, typeof(BorderSizeComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveBorderSize() {
        RemoveComponent(GameComponentsLookup.BorderSize);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherBorderSize;

    public static Entitas.IMatcher<GameEntity> BorderSize {
        get {
            if (_matcherBorderSize == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BorderSize);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBorderSize = matcher;
            }

            return _matcherBorderSize;
        }
    }
}
