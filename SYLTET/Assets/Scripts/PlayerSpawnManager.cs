using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerSpawnManager : MonoBehaviour
{

    [SerializeField] private Transform[] playerOneSpawnPoint;
   
    

    

    //Metoden anv�nds av inputsystemet f�r att spawna in en spelare n�r den tar emot input fr�n spelarens handkontroller/tangentbord
    public void OnPlayerJoined(PlayerInput playerInput)
    {
       
        int randy = Random.Range(0, playerOneSpawnPoint.Length);

        
        
        playerInput.gameObject.transform.position = playerOneSpawnPoint[randy].transform.position;
        
    }
}
