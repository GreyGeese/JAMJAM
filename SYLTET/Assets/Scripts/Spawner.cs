using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform trans;
    [SerializeField] private float respawnTime;
    [SerializeField] PlayerSpawnManager playerSpawnManager;
    private Transform[] points;
    private int index = 0;
    float timer = 0;
    private bool startRespawn = false;

    private void Start()
    {
        points = playerSpawnManager.getPlayerSpawnPoints();
    }

    public void respawn(GameObject p)
    {
        print(index);
        if (index >= points.Length)  
            index = 0;
        
        //timer += Time.deltaTime;

        p.transform.position = points[index].position;
            p.SetActive(true);
            //timer = 0;
            startRespawn = false;
        index++;
    }


}
