using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShotEffect : PowerUpEffect
{
    public DoubleShotEffect(float effectDuration) : base(effectDuration)
    {

    }   

    public override void Apply(Player player)
    {
        //access player script
        //change weapon used in weaponcontroller
        player.EquipDoubleShot();
    }

    public override void Remove(Player player)
    {
        player.EquipSingleShot();
    }
}
