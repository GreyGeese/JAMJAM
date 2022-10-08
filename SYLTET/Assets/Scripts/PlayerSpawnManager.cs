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
    [SerializeField] private Transform playerTwoSpawnPoint;
    [SerializeField] private PlayerInputManager playerInputManager;
    [SerializeField] private GameObject player1Prefab;
    [SerializeField] private GameObject player2Prefab;
    [SerializeField] private GameObject startCamera;
    [SerializeField] private GameObject startUIPicture;


    [SerializeField] private float player1Rotation;
    [SerializeField] private float player2Rotation;

    private float timer;
    public bool playerHasJoined = false;
    public bool player2hasjoined;
    private bool isEventSystemReset;

    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    [SerializeField] private Animator startUIAnimator;

    

    //Metoden anv�nds av inputsystemet f�r att spawna in en spelare n�r den tar emot input fr�n spelarens handkontroller/tangentbord
    public void OnPlayerJoined(PlayerInput playerInput)
    {

        int randy = Random.Range(-50, -1);
       // playerInput.gameObject.transform.position = new Vector3(randy, -1, -1);

        playerInput.gameObject.transform.position = playerOneSpawnPoint.transform.position;
    }

   
}
