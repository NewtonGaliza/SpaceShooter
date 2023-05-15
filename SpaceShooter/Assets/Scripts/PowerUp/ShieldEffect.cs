using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEffect : PowerUpEffect
{
    public override void Apply(Player player)
    {
        player.EquipShield();
    }
}
