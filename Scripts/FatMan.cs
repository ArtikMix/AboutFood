using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FatMan : MonoBehaviour, IPointerDownHandler
{
    public bool eat = false;

    void Update()
    {
        if (Input.touchCount == 0)
        {
            eat = false;
        }
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData data)
    {
        eat = true;
    }
}