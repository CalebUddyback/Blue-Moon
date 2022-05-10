using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardReturn : Selectable
{
    public GameObject returnButton;



    public override void PointEnter()
    {}

    public override void PointExit()
    {}

    public override void Select(bool select)
    {
        if (select)
        {
            returnButton.SetActive(true);
        }
        else
        {
            returnButton.SetActive(false);
        }
    }

    public void ReturnCard()
    {
        transform.SetParent(GameObject.Find("Cards In Hand").transform, true);
        Select(false);

        GameObject.Find("Player").GetComponent<PlayerManager>().cardSet = false;
        GameObject.Find("Player").GetComponent<PlayerManager>().selectedObject = null;

        GetComponent<CardSelect>().enabled = true;
        enabled = false;
    }
}
