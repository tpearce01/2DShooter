using UnityEngine;

public class Pickup : MonoBehaviour
{
    protected virtual void OnPickup(GameObject player)
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPickup(other.gameObject);
        }
    }
}
