using UnityEngine;

public class ShotgunPickup : Pickup {
    protected override void OnPickup(GameObject player)
    {
        GunController gun = player.GetComponent<PlayerUnit>().gun;
        gun.type = FireTypes.Shotgun;
        gun.ammo = 15;
        base.OnPickup(player);
    }
}
