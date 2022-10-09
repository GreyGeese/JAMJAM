using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform trans;
    [SerializeField] private float respawnTime;
    GameObject player;
    float timer = 0;
    private bool startRespawn = false;
   
    public void respawn(GameObject p)
    {
        player = p;
        timer += Time.deltaTime;
        //if (timer >= respawnTime)
        //{
            p.transform.position = transform.position;
            p.SetActive(true);
            timer = 0;
            startRespawn = false;
        //}
    }
    
}
