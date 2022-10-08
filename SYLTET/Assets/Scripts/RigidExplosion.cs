using UnityEngine;

public class RigidExplosion : MonoBehaviour
{

    [SerializeField] GameObject jamCharacter;
    [SerializeField] GameObject brokenJamCharacter;


    public void shatterJar()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        jamCharacter.SetActive(false);
        brokenJamCharacter.SetActive(true);
        brokenJamCharacter.GetComponent<HandleRigidExplosion>().explode();
        brokenJamCharacter.GetComponent<HandleRigidExplosion>().Invoke("Destroy", 5f);

    }

}