using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//Martin Wallmark

/*
 * Anv�nds av LocalCo-opManager f�r att kunna hantera in-spawningen av spelare samt identifiera spelarna med varsit id och tag.
 */
public class PlayerSpawnManager : MonoBehaviour
{

    [SerializeField] private Transform playerOneSpawnPoint;
    

    

    //Metoden anv�nds av inputsystemet f�r att spawna in en spelare n�r den tar emot input fr�n spelarens handkontroller/tangentbord
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("hej");
        int randy = Random.Range(-50, -1);
        // playerInput.gameObject.transform.position = new Vector3(randy, -1, -1);
        /*if (p1)
        {
            Material = p1 material
        }

        if (p2)
            {
                Material = p2 material
        }
        if (p3)
            {
                Material = p3 material
        }
        if (p4)
            {
                Material = p4 material
        }*/
            playerInput.gameObject.transform.position = playerOneSpawnPoint.transform.position;
    }

   
}
