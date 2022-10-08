using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePlayer : MonoBehaviour
{
    private GameObject player;
    public void SetPlayer(GameObject p)
    {
        player = p;
    }

    // Start is called before the first frame update

    private void OnEnable()
    {
        gameObject.transform.SetParent(player.transform);
        player.transform.position = transform.position;
        player.transform.localScale = new Vector3(40, 40, 40);
    }

    // Update is called once per frame
    void Update()
    {
        //player.transform.rotation = player.transform.rotation * new Quaternion(0,0,0,0);
    }
}
