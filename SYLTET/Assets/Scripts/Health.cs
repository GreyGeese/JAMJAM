using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    [Header("Health")]
    [SerializeField] private int hearts = 1;
    private GameObject player;

    public Health(int hearts, GameObject player)
    {
        this.hearts = hearts;
        this.player = player;
    }

    public void Death()
    {
        player.SetActive(false);
    }

    public int getHearts()
    {
        return hearts;
    }
}
