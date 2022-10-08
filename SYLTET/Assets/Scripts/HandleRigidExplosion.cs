using UnityEngine;

public class HandleRigidExplosion : MonoBehaviour
{
    [SerializeField] float speed = 40f;
    private Vector3 movementDirection;

    public void explode()
    {
        movementDirection = new Vector3(70f, 70f, 70f);
        GetComponentInChildren<Rigidbody>().AddForce(movementDirection * speed, ForceMode.Impulse);  // Impulse använder massan
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

   
}
