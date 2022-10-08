using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] textMesh = new TextMeshProUGUI[4];
    [SerializeField] GameObject[] players = new GameObject[4];
    int i = 0; 
    public void AddPlayer(GameObject player)
    {
        players[i] = player;
        i++;
    }
    private void Update()
    {
        for (int i = 0; i < players.Length; i++)
        {
            textMesh[i].text = players[i].GetComponent<Player>().GetScore()+"";
        }
    }
}
