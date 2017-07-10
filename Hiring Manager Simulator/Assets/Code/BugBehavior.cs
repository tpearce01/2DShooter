using UnityEngine;

public class BugBehavior : MonoBehaviour
{

    public GameObject player;
    [SerializeField] private Rigidbody2D rgbd;
    [SerializeField] private GameObject sprite;
    public float speed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Move the unit toward the player
    /// </summary>
    void Move()
    {
        sprite.transform.right = player.transform.position - gameObject.transform.position;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
