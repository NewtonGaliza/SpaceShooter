using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShotEffect : PowerUpEffect
{
    public override void Apply(Player player)
    {
        //access player script
        //change weapon used in weaponcontroller
        player.EquipDoubleShot();
    }
}
