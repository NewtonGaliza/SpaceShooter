using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShotEffect : PowerUpEffect
{
    public SingleShotEffect(float effectDuration) : base(effectDuration)
    {

    }

    public override void Apply(Player player)
    {
        player.EquipSingleShot();
    }

    public override void Remove(Player player)
    {
        Apply(player);
    }
}
