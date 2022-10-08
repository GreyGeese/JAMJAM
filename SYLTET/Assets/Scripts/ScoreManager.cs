using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] textMesh = new TextMeshProUGUI[4];
    [SerializeField] GameObject[] players = new GameObject[4];
     
    public void AddPlayer(GameObject player, int playerCount)
    {
        players[playerCount] = player;
        
    }
    private void Update()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if(players[i] != null)
            {
                textMesh[i].text = players[i].GetComponent<Player>().GetScore() + "";
            }
            
        }
    }
}
