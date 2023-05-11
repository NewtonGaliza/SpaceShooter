using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShotPowerUp : CollectablePowerUp
{
    public override PowerUpEffect PowerUpEffect
    {
        get { return new DoubleShotEffect(); }
    }
}
