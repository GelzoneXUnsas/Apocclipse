using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Projectile collectable;

    public Projectile obstacle;

    public int spawnNum = 0;

    private void SetupProjectile(Projectile obj)
    {
        Projectile clone =
            (Projectile)
            Instantiate(obj, transform.position, Quaternion.identity);
        clone.GetComponent<SpriteRenderer>().enabled = true;
        clone.GetComponent<CircleCollider2D>().enabled = true;
        Destroy(clone.gameObject, 15f);
        spawnNum++;
    }

    public void Spawn(int spawn_type)
    {
        if (spawn_type == 1)
            SetupProjectile(collectable);
        else if (spawn_type == 2) SetupProjectile(obstacle);
    }
}
