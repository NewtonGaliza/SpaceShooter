using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateShot : BasicWeapon
{
    private Transform nextShootPosition;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        this.nextShootPosition = this.shootPosition[0];
    }

    protected override void Shoot()
    {
        CreateLaser(this.nextShootPosition.position);

        if(this.nextShootPosition ==this.shootPosition[0])
        {
            this.nextShootPosition = this.shootPosition[1];
        }
        else
        {
            this.nextShootPosition = this.shootPosition[0];
        }
    }
}
