using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : CollectablePowerUp
{
    public override PowerUpEffect PowerUpEffect
    {
        get { return new ShieldEffect(); }
    }
}
