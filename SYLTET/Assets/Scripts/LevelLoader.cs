using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class LevelLoader : MonoBehaviour
{
    public float transitionTime;
    Animator anim;
    public int levelToLoad = 1;
    public bool doStartTransition = true;
    float timer;
    Player player;
    private void Start()
    {
        
        anim = GetComponent<Animator>();
        if (doStartTransition) anim.SetTrigger("FadeOnStart");
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    public void LoadLevel()
    {
        
       
        StartCoroutine(LoadSceneAfterFade());
        
    }
    public void ReplayLevel()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
           player.SetAmountOfPlayersSpawned(0);
        
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator LoadSceneAfterFade()
    {
        Debug.Log("Loading level: " + levelToLoad);
        anim.SetTrigger("FadeOnEnd");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


}
