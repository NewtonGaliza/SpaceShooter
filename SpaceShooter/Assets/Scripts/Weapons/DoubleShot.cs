using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShot : BasicWeapon
{
    protected override void Shoot()
    {
        CreateLaser(this.shootPosition[0].position);
        CreateLaser(this.shootPosition[1].position);
    }
}
