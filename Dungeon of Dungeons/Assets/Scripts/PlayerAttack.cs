using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;




    // Start is called before the first frame update
    void Start()
    {
        
        animator = GameObject.Find("Hand").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
