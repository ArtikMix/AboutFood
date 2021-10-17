using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FatMan : MonoBehaviour, IPointerDownHandler
{
    public bool eat = false;
    [SerializeField] private Animator animator;

    void Update()
    {
        if (Input.touchCount == 0)
        {
            //Debug.Log("wasnt pressed");
            if (transform.name == "Fat_1_col")
            {
                animator.SetBool("g_head", false);
            }
            if (transform.name == "Fat_2_col")
            {
                animator.SetBool("b_head", false);
            }
            eat = false;
        }
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData data)
    {
        eat = true;
        if (transform.name == "Fat_1_col")
        {
            animator.SetBool("g_head", true);
        }
        if (transform.name == "Fat_2_col")
        {
            animator.SetBool("b_head", true);
        }
        //Debug.Log("was pressed");
    }
}
