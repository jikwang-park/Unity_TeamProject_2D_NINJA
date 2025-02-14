using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform following;
    private InfinityModeGameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<InfinityModeGameManager>();
        following = gameManager.player.transform;
        
    }
    void Update()
    {
        var pos = transform.position;
        pos.y = following.position.y;
        transform.position = pos;
    }   
}