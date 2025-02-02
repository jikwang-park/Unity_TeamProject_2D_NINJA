using UnityEditor;
using UnityEngine.UI;

public enum ScenesIds
{
    none = -1,
    StartScene,
    MainTitleScene,
    StoryModeScene,
    InfinityModeScene,
    CharacterSelectScene,
    WeaponSelectScene,
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

public static class DataTableIds
{
    public static readonly string[] String =
    {
        "StringTableKr",
        "StringTableEn",
    };

    public static readonly string Credit = "CreditTable";


}

public static class Variables
{
    public static Languages currentLang = Languages.Korean;
}
