using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShot : BasicWeapon
{
    [SerializeField, Range(1, 30)] private int shotAmount;
    [SerializeField] private float angleBetweenShots;

    protected override void Shoot()
    { 
        Vector2 shotPosition = this.shootPosition[0].position;

        for(int i = 0; i < this.shotAmount; i++)
        {
            Laser laser = CreateLaser(shotPosition);
            laser.Direction = CalculateShootPosition(i);
        }        
    }

    private Vector2 CalculateShootPosition(int shootIndex)
    {
        int shotArchIndex;

        if(this.shotAmount % 2 == 0)
        {
            shotArchIndex = shootIndex + 1;
        }
        else
        {
            shotArchIndex = shootIndex;
        }

        shotArchIndex = Mathf.CeilToInt(shotArchIndex / 2f);

        float angle = (this.angleBetweenShots * shotArchIndex);

        if((shootIndex & 2) != 0)
        {
            angle *= -1;
        }

        
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Debug.Log(angle);

        Vector2 direction = rotation * Vector3.right;
        return direction;
    }


}
