using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skills : MonoBehaviour
{
    public GameObject Owner;

    public Sprite Art;

    public float totalExecutionSpeed;

    public bool finished;

    public abstract void CallExecute();

    public abstract void Interupt();


}
