using UnityEditor;
using UnityEngine.UI;

public enum ScenesIds
{
    none = -1,
    StartScene,
    MainTitleScene,
    CharacterSelectScene,
    InfinityModeScene,
    WeaponSelectScene,
    StoryModeScene,
    
    
}

public enum Monsters
{
    Bat,
    FireFly,
    Count,
}

public enum SceneCategory
{
    MainScene,
    SubScene,
    GameScene,
}

public enum GameState
{
    Playing,
    Stop,
}

public enum Languages
{
    Korean,
    English,
}

public enum PotionSize
{
    BigPotion,
    MiddlePotion,
    SmallPotion,
    Count,
}

public enum SoundsId
{
    ButtonClick,
    Gameover,
    Jumpsound,
    PlayerHit,
    SkillExplosion,
    SkillShiled,
    SkillSwordPoll,
}



public static class DataTableIds
{
    public static readonly string[] String =
    {
        "StringTableKr",
        "StringTableEn",
    };

    public static readonly string Credit = "CreditTable";
    public static readonly string Monster = "MonsterTable";
    public static readonly string PlayerState = "PlayerStateTable";
    public static readonly string Item = "ItemTable";

}

public static class Variables
{
    public static Languages currentLang = Languages.Korean;
}
