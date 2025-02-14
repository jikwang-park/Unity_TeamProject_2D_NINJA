using Helios.GUI;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerUseSkill : MonoBehaviour
{
    public bool isSkillActive = false;
    protected InfinityModeGameManager gameManager;

    protected virtual void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<InfinityModeGameManager>();

    }
    public virtual void ActiveSkill()
    {

    }
}
