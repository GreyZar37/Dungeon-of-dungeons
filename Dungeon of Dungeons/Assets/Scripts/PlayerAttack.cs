using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{


    public static int attackCombo;
    public static bool isAttacking;

    public Animator animator;

    


    // Start is called before the first frame update
    void Start()
    {
        
        animator = GameObject.Find("Hand").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetInteger("AttackValue", attackCombo);
        animator.SetBool("isAttacking", isAttacking);




        if (Input.GetMouseButtonDown(0))
        {

            switch (attackCombo)
            {
                case 0:
                    attackCombo = 1;
                    isAttacking = true;
                    break;

                case 1:
                    attackCombo = 2;
                    isAttacking = true;
                    break;

                default:
                    break;
            }

        }  
   
    
        

        print(attackCombo);
    }
    
}
