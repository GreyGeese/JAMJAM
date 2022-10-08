using UnityEngine;

public class HandleRigidExplosion : MonoBehaviour
{
    [SerializeField] float speed = 40f;
    private Vector3 movementDirection;

    public void explode()
    {
        movementDirection = new Vector3(70f, 70f, 0f);
        GetComponentInChildren<Rigidbody2D>().AddForce(movementDirection * speed, ForceMode2D.Impulse);  // Impulse använder massan
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }


}
