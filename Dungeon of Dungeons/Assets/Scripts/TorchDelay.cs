using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchDelay : MonoBehaviour
{
    public float delay;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if(delay <= 0)
        {
            animator.enabled = true;
            Destroy(gameObject.GetComponent<TorchDelay>());
        }
    }
}
