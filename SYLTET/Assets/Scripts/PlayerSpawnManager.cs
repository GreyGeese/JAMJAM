using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerSpawnManager : MonoBehaviour
{
    private int amountOfPlayers;
    [SerializeField] private Transform[] playerOneSpawnPoint;
   
    

    

    //Metoden anv�nds av inputsystemet f�r att spawna in en spelare n�r den tar emot input fr�n spelarens handkontroller/tangentbord
    public void OnPlayerJoined(PlayerInput playerInput)
    {
       
        int randy = Random.Range(0, playerOneSpawnPoint.Length);
        int i = 0;

        
        if(amountOfPlayers < 4)
        {
            Debug.Log("hur många spelare" + i++);
            playerInput.gameObject.transform.position = playerOneSpawnPoint[randy].transform.position;
            amountOfPlayers++;
        }
        
        
    }

    public Transform[] getPlayerSpawnPoints()
    {
        return playerOneSpawnPoint;
    }
}
