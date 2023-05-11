using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShot : BasicWeapon
{
    protected override void Shoot()
    {
        CreateLaser(this.transform.position);
    }
}
