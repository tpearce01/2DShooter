using System.Collections.Generic;
using UnityEngine;
/*
 * BugUnit
 * 
 * Unit child class which assigns functions unique to the bug type unit.
 * BugUnit will have a unique Kill function which randomizes Loot drops 
 * using the unique Loot() function.
 */
public class BugUnit : Unit {

    [SerializeField] List<LootTableItem> loot = new List<LootTableItem>();

    /// <summary>
    /// Spawn loot and destroy this unit
    /// </summary>
    protected override void Kill()
    {
        Loot();
        Destroy(gameObject);
    }

    /// <summary>
    /// Randomly instantiate a piece of loot. The loot generated prioritizes lowest droprate
    /// first.
    /// </summary>
    void Loot()
    {
        float roll = Random.Range(0f,1f);
        for (int i = 0; i < loot.Count; i++)
        {
            if (roll < loot[i].dropChance)
            {
                if (gameObject != null)
                {
                    Instantiate(loot[i].item);
                }
            }
        }
    }
}
