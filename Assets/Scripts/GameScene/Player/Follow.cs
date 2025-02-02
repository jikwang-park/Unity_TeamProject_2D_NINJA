using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform following;

    void Update()
    {
        var pos = transform.position;
        pos.y = following.position.y;
        transform.position = pos;
    }
}