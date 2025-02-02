using UnityEngine;

public class SceneSelectManager : MonoBehaviour
{
    public MainTitleGameManager[] scenes;

    public SceneCategory defaultScene = 0;

    public SceneCategory currentScene { get; private set; }

    private void Start()
    {
        foreach (var scene in scenes)
        {
            scene.Init(this);

            scene.gameObject.SetActive(false);
        }

        currentScene = defaultScene;
        scenes[(int)currentScene].Open();
    }

    public void Open(int scenesId)
    {
        Open((SceneCategory)scenesId);
    }

    public void Open(SceneCategory scene)
    {
        scenes[(int)currentScene].Close();
        currentScene = scene;
        scenes[(int)currentScene].Open();
    }
}
