using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : Skills
{
    public float moveSpeed = 10;

    public float range = 2;

    public int damage = 5;

    private GameObject Character;

    private GameObject EnemyCharacter;

    public override void CallExecute() => StartCoroutine(Execute());

    IEnumerator Execute()
    {
        Character = Owner.GetComponent<PlayerManager>().Character;
        EnemyCharacter = Owner.GetComponent<PlayerManager>().Enemy.transform.GetChild(0).gameObject;

        yield return new WaitForSeconds(1); // animation time

        //apply skill effect / damage

        finished = true;

        yield return new WaitUntil(() => finished);

        if(Mathf.Abs(EnemyCharacter.GetComponent<Character>().currentZone - Character.GetComponent<Character>().currentZone) <= 2)
            Owner.GetComponent<PlayerManager>().Enemy.GetComponent<Stats>().Damage(damage);

        Destroy(transform.parent.gameObject);

        yield return null;
    }

    public override void Interupt()
    {
        StopAllCoroutines();
        finished = true;
        Debug.Log("Interupted");

        Destroy(transform.parent.gameObject);
    }
}
