using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dance : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F1))
        {
            animator.SetTrigger("idle");
        }
        else if (Input.GetKey(KeyCode.F2)) 
        {
            animator.SetTrigger("bootyHipHopDance");
        }
        else if (Input.GetKey(KeyCode.F3)) 
        {
            animator.SetTrigger("ymcaDance");
        }
        else if (Input.GetKey(KeyCode.F4)) 
        {
            animator.SetTrigger("shoppingCartDance");
        }
    }
}
