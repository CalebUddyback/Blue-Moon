using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] Deck = new GameObject[10];
    public List<GameObject> CurrentDeck = new List<GameObject>();

    public GameObject CardsInHand;
    public GameObject SetZone;

    public GameObject Character;
    public GameObject Enemy;

    public GameObject ZoneManager;

    public GameObject selectedObject;



    public bool cardSet = false;

    void Start()
    {
        for (int i = 0; i < Deck.Length; i++)
            CurrentDeck.Add(Deck[i]);

        Enemy = GameObject.Find("Enemy");

        Draw(5);
    }

    public void Draw(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            GameObject card = Instantiate(CurrentDeck[0], Vector2.zero, Quaternion.identity, CardsInHand.transform);

            card.GetComponent<CardSelect>().skill.GetComponent<Skills>().Owner = gameObject;

            card.name = "Card " + (i+1);

            CurrentDeck.Remove(CurrentDeck[0]);
        }
    }

    public void CallMoveCharacter()
    {
        StartCoroutine(MoveCharacter(selectedObject.transform));
        selectedObject.GetComponent<Selectable>().Select(false);
        selectedObject = null;

        ZoneManager.GetComponent<ZoneManager>().ShowZones(false, 0, 0, Color.white);

    }

    IEnumerator MoveCharacter(Transform target)
    {

        while (Character.transform.position.x != target.position.x)
        {
            Character.transform.position = Vector2.MoveTowards(Character.transform.position, new Vector2(target.position.x, Character.transform.position.y), 10 * Time.deltaTime);
            yield return null;
        }
        
    }

}
