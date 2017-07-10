using UnityEngine;

/*********************************************************************************
 * public class Spawner
 * 
 * Function: Easily spawn objects common among multiple scripts
 *********************************************************************************/
public class Spawner : MonoBehaviour
{
    public static Spawner i; //Static reference

    public GameObject[] prefabs; //List of all prefabs that may be instantiated

    void Awake()
    {
        i = this;
    }

    public GameObject SpawnObject(Prefab obj)
    {
        return SpawnObject((int) obj);
    }

    public GameObject SpawnObject(int index)
    {
        return SpawnObject(index, Vector3.zero);
    }

    //Instantiate an object at the specified location and add it to the list of active objects
    public GameObject SpawnObject(int index, Vector3 location)
    {
        return Instantiate(prefabs[index], location, Quaternion.identity);
    }

    //Convert enum to index and call SPawnObject
    public GameObject SpawnObject(Prefab obj, Vector3 location)
    {
        return SpawnObject((int) obj, location);
    }

    public GameObject SpawnObjectWithRotation(Prefab obj, Vector3 location, Vector3 rotation)
    {
        return SpawnObjectWithRotation((int)obj, location, rotation);
    }

    public GameObject SpawnObjectWithRotation(int index, Vector3 location, Vector3 rotation)
    {
        GameObject spawned = Instantiate(prefabs[index], location, Quaternion.identity) as GameObject;
        spawned.transform.Rotate(rotation);
        return spawned;
    }

    public GameObject ShootAt(Vector3 start, Vector3 end)
    {
        GameObject bullet = SpawnObject(Prefab.PlayerBullet);
        bullet.transform.position = start;
        bullet.transform.right = end - start;
        return bullet;
    }

    public GameObject ShootAtExplosive(Vector3 start, Vector3 end)
    {
        GameObject bullet = SpawnObject(Prefab.PlayerBulletExplosive);
        bullet.transform.position = start;
        bullet.transform.right = end - start;
        return bullet;
    }

    public void SpreadShot(Vector3 start, Vector3 end)
    {
        for (int i = 0; i < 5; i++)
        {
            ShootAt(start, end).transform.Rotate(new Vector3(0,0,Random.Range(-20,20)));
        }
    }
}

//Enum to easily convert prefab names to the appropriate index
public enum Prefab
{
    PauseMenu = 0,
    GameOverMenu = 1,
    PlayerBullet = 2,
    PlayerBulletExplosive = 3,
    Sparks = 4,
    Bug = 5
};