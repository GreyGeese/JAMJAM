using UnityEngine;

public class RigidExplosion : MonoBehaviour
{

    
    [SerializeField] GameObject brokenJamCharacter;


    public void shatterJar()
    {
        brokenJamCharacter.SetActive(true);
        brokenJamCharacter.GetComponent<HandleRigidExplosion>().explode();
        brokenJamCharacter.GetComponent<HandleRigidExplosion>().Invoke("Destroy", 5f);
    }

}