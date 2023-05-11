using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShotEffect : PowerUpEffect
{
    public override void Apply(Player player)
    {
        player.EquipSingleShot();
    }
}
