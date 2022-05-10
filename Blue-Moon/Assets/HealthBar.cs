using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image mainBar;
    public Image trailBar;

    private float maxHealth = 100;

    private readonly float trailSpeed = 0.25f;

    public Stats stats;

    private void Start()
    {
        //stats = GameObject.Find("Enemy").GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        mainBar.fillAmount = stats.health / maxHealth;

        trailBar.fillAmount = Mathf.MoveTowards(trailBar.fillAmount, mainBar.fillAmount, trailSpeed * Time.deltaTime);
    }
}
