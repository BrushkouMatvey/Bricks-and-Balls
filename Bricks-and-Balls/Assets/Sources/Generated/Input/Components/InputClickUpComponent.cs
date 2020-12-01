//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly ClickUpComponent clickUpComponent = new ClickUpComponent();

    public bool isClickUp {
        get { return HasComponent(InputComponentsLookup.ClickUp); }
        set {
            if (value != isClickUp) {
                var index = InputComponentsLookup.ClickUp;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : clickUpComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherClickUp;

    public static Entitas.IMatcher<InputEntity> ClickUp {
        get {
            if (_matcherClickUp == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.ClickUp);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherClickUp = matcher;
            }

            return _matcherClickUp;
        }
    }
}
