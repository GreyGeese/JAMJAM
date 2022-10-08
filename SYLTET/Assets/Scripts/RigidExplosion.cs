using UnityEngine;

public class RigidExplosion : MonoBehaviour
{

    [SerializeField] GameObject wall;
    [SerializeField] GameObject wallBroken;


    public void breakWall()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        wall.SetActive(false);
        wallBroken.SetActive(true);
        //wallBroken.GetComponent<HandelBrokenWall>().explode();
        //wallBroken.GetComponent<HandelBrokenWall>().Invoke("Destroy", 5f);

    }

}