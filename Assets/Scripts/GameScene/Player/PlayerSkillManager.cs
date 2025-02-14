using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillManager : MonoBehaviour
{
    private enum Skills
    {
        SwordShiled,
        SwordPoll,
        GroundImpact,
    }
    public PlayerUseSkill[] skills;
   
    

    public void SkillSwordShiled()
    {
        skills[(int)Skills.SwordShiled].ActiveSkill();
    }
    public void SkillSwordPoll()
    {
        skills[(int)Skills.SwordPoll].ActiveSkill();
    }
    public void SkillGroundImpact()
    {
        skills[(int)Skills.GroundImpact].ActiveSkill();
    }
}
