using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform trans;
    [SerializeField] private float respawnTime;
    GameObject player;
    float timer;
    public void setPlayer(GameObject p)
    {
        player = p;
        respawn(p);
    }
    private void respawn(GameObject p)
    {
        timer += Time.deltaTime;
        if (timer >= respawnTime)
        {
            Instantiate(p, trans);
            timer = 0;
        }
    }
}
