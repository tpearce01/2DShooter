using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private float speed;
	
	// Update is called once per frame
	void Update ()
	{
	    Move();
	}

    void Move()
    {
        gameObject.transform.position += transform.right * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //deal damage
            other.gameObject.GetComponent<Unit>().ModifyHealth(-10);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        Spawner.i.SpawnObject(Prefab.Sparks, gameObject.transform.position);
    }
}
