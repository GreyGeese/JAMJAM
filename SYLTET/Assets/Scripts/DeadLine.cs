using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DeadLine : MonoBehaviour
{
    private float timer = 0;
    [SerializeField] private int deadline;
    [SerializeField] private GameObject panel; 
    private bool finished = false;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject showPlayer;
    [SerializeField] ScoreManager scoreManager;


    void Update()
    {
        RunGame();
    }
    private void RunGame()
    {
        if (!finished) { 
        timer += Time.deltaTime;
            if (timer > deadline)
            {
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                camera.clearFlags = CameraClearFlags.Depth;
                camera.cullingMask = LayerMask.GetMask("UI") + LayerMask.GetMask("Player");
                camera.orthographic = true;
                canvas.worldCamera = camera;
                canvas.planeDistance = 10;
                showPlayer.GetComponent<ChoosePlayer>().SetPlayer(TheChoosenPlayer());
                panel.SetActive(true);
                timer = 0;
                finished = true;
            }
        }
    }
    int temp = 0;
    GameObject t;
    public GameObject TheChoosenPlayer()
    {
        for (int i = 0; i < scoreManager.players.Length; i++)
        {
            if(scoreManager.players[i] != null)
            {
                if (scoreManager.players[i].GetComponent<Player>().GetScore() >= temp) 
                    temp = scoreManager.players[i].GetComponent<Player>().GetScore();
                    t = scoreManager.players[i];
            }
        }
        if (t != null) return t;
        return null;
    }
}
