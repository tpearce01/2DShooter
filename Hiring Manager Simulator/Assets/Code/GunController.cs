using System;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public bool canShoot;                           //Determines if they player can shoot
    [SerializeField] private float zdepth;          //Z-position for mouse pointer
    private float shotTimer = 0;                    //Time until next shot
    public FireTypes type;                          //Type of weapon the player is wielding
    public int ammo;                                //Remaining ammo for limited ammo guns
    [SerializeField] private GameObject player;     //Reference to the player
    [SerializeField] private List<float> cooldowns; //Determines the time between shots for each weapon type

	void Start ()
	{
	    canShoot = true;
	}
	
	void Update ()
	{
	    Aim();
	    Shoot();
	}

    /// <summary>
    /// Moves the target reticle to the mouse position
    /// </summary>
    void Aim()
    {
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zdepth));
    }

    /// <summary>
    /// Spawn and fire a bullet based on the type of weapon wielded by the player
    /// </summary>
    void Shoot()
    {
        if (shotTimer <= 0 && canShoot)
        {
            if (Input.GetMouseButton(0))
            {
                switch ((int) type)
                {
                    case 0: //Single Shot
                        Spawner.i.ShootAt(player.transform.position, gameObject.transform.position);
                        break;
                    case 1: //Shotgun
                        Spawner.i.SpreadShot(player.gameObject.transform.position, gameObject.transform.position);
                        break;
                    case 2: //Automatic
                        Spawner.i.ShootAt(player.transform.position, gameObject.transform.position);
                        break;
                    case 3: //Explosive
                        //Spawner.i.ShootAtExplosive(player, gameObject.transform.position);
                        break;
                    default:
                        break;

                }
                shotTimer = cooldowns[(int) type];
            }
        }
        else
        {
            shotTimer -= Time.deltaTime;
        }
    }
}

[Serializable]
public enum Guns
{
    Revolver = 0
}

[Serializable]
public enum FireTypes
{
    SingleShot = 0,
    Shotgun = 1,
    Automatic = 2,
    Explosive = 3
}
