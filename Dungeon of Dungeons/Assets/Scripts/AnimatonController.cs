using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatonController : MonoBehaviour
{
    public void resetCombo()
    {
       PlayerAttack.attackCombo = 0;
       PlayerAttack.isAttacking = false;
    }
}
