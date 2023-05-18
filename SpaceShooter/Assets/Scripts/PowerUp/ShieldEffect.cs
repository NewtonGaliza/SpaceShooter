using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEffect : PowerUpEffect
{
    public ShieldEffect(float effectDuration) : base(effectDuration)
    {

    }

    public override void Apply(Player player)
    {
        player.EquipShield();
    }

    public override void Remove(Player player)
    {
        player.DeactivateShield();
    }
}
