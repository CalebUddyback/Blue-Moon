using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginCardActions : MonoBehaviour
{
    public void Begin() => StartCoroutine(Processing());

    IEnumerator Processing()
    {
        if (transform.childCount > 0)
        {
            if (transform.GetChild(0).GetComponent<CardSelect>())
            {
                Debug.Log("Waiting...");

                GameObject skill = Instantiate(transform.GetChild(0).GetComponent<CardSelect>().skill, transform.GetChild(0));

                skill.GetComponent<Skills>().CallExecute();

                yield return new WaitUntil(() => skill.GetComponent<Skills>().finished);

                transform.root.GetComponent<PlayerManager>().cardSet = false;

                Debug.Log("Done");
            }
        }
        else
        {
            Debug.Log("No set card");
        }
    }
}
