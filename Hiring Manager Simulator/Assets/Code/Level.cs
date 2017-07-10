using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] private int bugsToSpawn;
    [SerializeField] private float spawnChance;
    [SerializeField] private Vector2 SpawnArea;
    private float masterSpawnTime;
    private float spawnTimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    float temp = Random.Range(0f, 1f);
	    if (temp < spawnChance)
	    {
	        Spawner.i.SpawnObject(Prefab.Bug, new Vector3(SpawnArea.x + Random.Range(0,2) * -2 * SpawnArea.x, Random.Range(-SpawnArea.y, SpawnArea.y), 0));
	    }
	}
}
