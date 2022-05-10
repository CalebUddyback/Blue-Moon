using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceLine : MonoBehaviour
{
    private Transform Character;
    private Transform Waypoint;

    private float Distance;
    public Text DistanceText;

    public RectTransform canvasRect;

    private float offsetPosY = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        Character = GameObject.Find("Character").transform;
        Waypoint = GameObject.Find("Waypoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector2.Distance(Character.position, Waypoint.position);

        GetComponent<LineRenderer>().SetPosition(0, Character.position);
        GetComponent<LineRenderer>().SetPosition(1, Waypoint.position);

        Vector2 Midpoint = new Vector2((Character.position.x + Waypoint.position.x) / 2, (Character.position.y + Waypoint.position.y) / 2);

        Vector2 offsetPos = new Vector2(Midpoint.x, Midpoint.y + offsetPosY);

        Vector2 canvasPos;
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(offsetPos);

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPoint, null, out canvasPos);

        DistanceText.transform.localPosition = canvasPos;

        DistanceText.text = Distance.ToString(); //should be change to time to target NOT distance
    }
}
