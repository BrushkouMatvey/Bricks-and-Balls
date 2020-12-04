//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public BombBlockComponent bombBlock { get { return (BombBlockComponent)GetComponent(GameComponentsLookup.BombBlock); } }
    public bool hasBombBlock { get { return HasComponent(GameComponentsLookup.BombBlock); } }

    public void AddBombBlock(int newDamage, int newDamageAreaSize) {
        var index = GameComponentsLookup.BombBlock;
        var component = (BombBlockComponent)CreateComponent(index, typeof(BombBlockComponent));
        component.damage = newDamage;
        component.damageAreaSize = newDamageAreaSize;
        AddComponent(index, component);
    }

    public void ReplaceBombBlock(int newDamage, int newDamageAreaSize) {
        var index = GameComponentsLookup.BombBlock;
        var component = (BombBlockComponent)CreateComponent(index, typeof(BombBlockComponent));
        component.damage = newDamage;
        component.damageAreaSize = newDamageAreaSize;
        ReplaceComponent(index, component);
    }

    public void RemoveBombBlock() {
        RemoveComponent(GameComponentsLookup.BombBlock);
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

    static Entitas.IMatcher<GameEntity> _matcherBombBlock;

    public static Entitas.IMatcher<GameEntity> BombBlock {
        get {
            if (_matcherBombBlock == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BombBlock);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBombBlock = matcher;
            }

            return _matcherBombBlock;
        }
    }
}
