using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class UITransitionButton : MonoBehaviour, IPointerClickHandler
{
    private UIWindow current;
    [SerializeField]
    private UIWindow next;

    public void OnPointerClick(PointerEventData eventData)
    {
        next.IsOpened = current.IsOpened;
        current.IsOpened = !current.IsOpened;

        //next.IsOpened = !(current.IsOpened = !current.IsOpened);
    }

    void Awake()
    {
        current = GetComponentInParent<UIWindow>();
    }
}
