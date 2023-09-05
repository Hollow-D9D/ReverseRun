using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour, IPointerDownHandler
{
    private Action action;

    public Action Action
    {
        set => action = value;
    }

    public void OnPointerDown(PointerEventData eventData) => action.Invoke();
}
