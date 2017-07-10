using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canMove;
    public float speed;
    [SerializeField] private GameObject sprite;

	void Start ()
	{
	    canMove = true;
	}
	
	void FixedUpdate ()
	{
	    Move();
	}

    /// <summary>
    /// Receive movement input and move the unit
    /// </summary>
    void Move()
    {
        if (canMove)
        {
            Vector3 targetPos = gameObject.transform.position;

            if (Input.GetKey(KeyCode.W))
            {
                targetPos += Vector3.up;
            }
            if (Input.GetKey(KeyCode.A))
            {
                targetPos -= Vector3.right;
            }
            if (Input.GetKey(KeyCode.S))
            {
                targetPos -= Vector3.up;
            }
            if (Input.GetKey(KeyCode.D))
            {
                targetPos += Vector3.right;
            }

            sprite.transform.right = targetPos - gameObject.transform.position;
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, targetPos,
                speed*Time.deltaTime);
        }
    }
}
