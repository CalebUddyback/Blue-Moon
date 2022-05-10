using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Selectable : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerClick(PointerEventData eventData) => SwapStoredObject();

    public void OnPointerEnter(PointerEventData eventData) => PointEnter();

    public void OnPointerExit(PointerEventData eventData) => PointExit();

    public void SwapStoredObject()
    {
       if (GameObject.Find("Player").GetComponent<PlayerManager>().selectedObject)
           GameObject.Find("Player").GetComponent<PlayerManager>().selectedObject.GetComponent<Selectable>().Select(false);
      
       GameObject.Find("Player").GetComponent<PlayerManager>().selectedObject = gameObject;

        Select(true);
    }

    public abstract void Select(bool select);

    public abstract void PointEnter();
    public abstract void PointExit();

    public bool AlreadySelected()
    {
        if (GameObject.Find("Player").GetComponent<PlayerManager>().selectedObject == gameObject)
            return true;
        else
            return false;
    }
}
