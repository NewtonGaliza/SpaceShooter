using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [Tooltip("Max amount of damage received by the shield, before destruction")]
    [SerializeField] private int totalProtection;

    private int currentProtection;

    public void Activate()
    {
        this.currentProtection = this.totalProtection;
        this.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

    public bool ShieldActivated
    {
        get { return this.gameObject.activeSelf; }
    }

    public void TakeDamage()
    {
        this.currentProtection--;
        if(this.currentProtection <= 0)
        {
            Deactivate();
        }
    }

}
