using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardSelect : Selectable
{
    public GameObject skill;

    private readonly float hoverHeight = 22.5f;

    private readonly float selectedHeight = 45;

    public GameObject visuals;
    public GameObject actionButtons;

    private void Start()
    {
        visuals.GetComponent<Image>().sprite = skill.GetComponent<Skills>().Art;
    }


    public override void PointEnter()
    {
        if (!AlreadySelected())
        {
            visuals.transform.localPosition = new Vector2(0, hoverHeight);
            transform.root.GetComponent<PlayerManager>().ZoneManager.GetComponent<ZoneManager>().ShowZones(true, transform.root.GetComponent<PlayerManager>().Character.GetComponent<Character>().currentZone - 2, transform.root.GetComponent<PlayerManager>().Character.GetComponent<Character>().currentZone + 2, Color.blue);
        }

    }

    public override void PointExit()
    {
        if (!AlreadySelected())
        {
            visuals.transform.localPosition = new Vector2(0, 0);
            transform.root.GetComponent<PlayerManager>().ZoneManager.GetComponent<ZoneManager>().ShowZones(false, 0, 0, Color.white);
        }
    }

    public override void Select(bool select)
    {
        if (select)
        {
            visuals.transform.localPosition = new Vector2(0, selectedHeight);

            if (GameObject.Find("Player").GetComponent<PlayerManager>().cardSet == false)
            {
                actionButtons.SetActive(true);
            }
        }
        else
        {
            visuals.transform.localPosition = new Vector2(0, 0);
            actionButtons.SetActive(false);

        }
    }

    public void PlayCard()
    {

        transform.SetParent(GameObject.Find("Set Zone").transform, true);
        Select(false);

        GameObject.Find("Player").GetComponent<PlayerManager>().cardSet = true;
        GameObject.Find("Player").GetComponent<PlayerManager>().selectedObject = null;

        GetComponent<CardReturn>().enabled = true;
        enabled = false;
    }
}
