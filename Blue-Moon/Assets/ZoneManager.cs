using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    public Transform[] allZones = new Transform[17];

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<transform.childCount; i++)
        {
            allZones[i] = transform.GetChild(i);

            allZones[i].GetComponent<Zone>().zoneNumber = i;
        }
    }

    public void MovementOptions()
    {
        int currentZone = GameObject.Find("Player").GetComponent<PlayerManager>().Character.GetComponent<Character>().currentZone;

        ShowZones(true, currentZone - 3, currentZone + 3, Color.yellow);
    }

    public void ShowZones(bool show, int b1, int b2, Color color)
    {
        if (b1 < 0)
            b1 = 0;

        if (b2 > allZones.Length)
            b2 = allZones.Length;

        if (show)
        {
            for (int i = b1; i <= b2; i++)
            {
                allZones[i].GetComponent<Zone>().ShowVisuals(true);
                allZones[i].GetComponent<Zone>().ChangeColor(color);
            }
        }
        else
        {
            foreach(Transform zone in allZones)
            {
                zone.GetComponent<Zone>().ShowVisuals(false);
            }
        }
    }

    
}
