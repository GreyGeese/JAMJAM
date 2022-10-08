using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePlayer : MonoBehaviour
{

    [SerializeField] private GameObject player;
    public void SetPlayer(GameObject p)
    {
        player = p;
    }

    // Start is called before the first frame update

    private void OnEnable()
    {
        player.transform.parent = gameObject.transform;
        player.transform.position = transform.position;
        player.transform.localScale = new Vector3(40, 40, 40);
    }

    // Update is called once per frame
    void Update()
    {
        //player.transform.Rotate(0, 50 * Time.deltaTime, 0);
    }
}
