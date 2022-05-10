using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zone : Selectable
{
    public int zoneNumber = 0;

    public Image visual;

    public GameObject confirmButton;

    private void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public override void PointEnter()
    {
        //Highlight

    }

    public override void PointExit()
    {
        //UnHighlight
    }

    public override void Select(bool select)
    {
        if (select)
        {
            confirmButton.SetActive(true);
        }
        else
        {
            confirmButton.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Character>().currentZone = zoneNumber;
        }
    }

    public void ShowVisuals(bool toggle)
    {
        if (toggle)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

    }

    public void ChangeColor(Color newcolor)
    {
        visual.color = newcolor;
    }

}
