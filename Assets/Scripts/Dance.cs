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
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetTrigger("idle");
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            animator.SetTrigger("bootyHipHopDance");
        }
        else if (Input.GetKey(KeyCode.UpArrow)) 
        {
            animator.SetTrigger("ymcaDance");
        }
        else if (Input.GetKey(KeyCode.RightArrow)) 
        {
            animator.SetTrigger("shoppingCartDance");
        }
    }
}
