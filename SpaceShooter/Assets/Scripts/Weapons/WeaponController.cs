using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private SingleShot singleShot;
    [SerializeField] private AlternateShot alternateShot;
    [SerializeField] private DoubleShot doubleShot;
    [SerializeField] private SpreadShot spreadShot;

    private BasicWeapon currentWeapon;

    private void Awake()
    {
        this.singleShot.Deactivate();
        this.alternateShot.Deactivate();
        this.doubleShot.Deactivate();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private BasicWeapon EquippedWeapon
    {
        set { 
                if(this.currentWeapon != null)
                {
                    this.currentWeapon.Deactivate();
                }
                this.currentWeapon = value;
                this.currentWeapon.Activate();
            }
    }

    public void EquipSingleShot()
    {
        this.EquippedWeapon = this.singleShot;
    }

    public void EquipAlternateShot()
    {
        this.EquippedWeapon = this.alternateShot;
    }

    public void EquipDoubleShot()
    {
        this.EquippedWeapon = this.doubleShot;
    }

    public void EquipSpreadShot()
    {
        this.EquippedWeapon = this.spreadShot;
    }
}
