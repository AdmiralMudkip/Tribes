using UnityEngine;
using System.Collections;
using System;

public class WeaponManager : MonoBehaviour {
    
    public Weapon[] weapons;
    public Transform barrelEnd;
    public Rigidbody[] projectilePrefabs;
    public GameObject weaponPlacement;
    public int activeWeapon = 0;

    public string[] weaponDirectories = { "Weapons/Spinfusor", "Weapons/Rifle" };

    void Start()
    {
        //weaponPlacement.
        weapons = new Weapon[5];
        weapons[0] = new Spinfusor(projectilePrefabs[0], barrelEnd);
        loadWeapon(0);
    }




    // Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Fire1"))
        {
            weapons[activeWeapon].fire();
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            activeWeapon = 1;
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeWeapon = 2;
        }
	}

    void loadWeapon(int num)
    {
        Mesh m = Resources.Load(weaponDirectories[num], typeof(Mesh)) as Mesh;
        weaponPlacement.GetComponent<MeshFilter>().mesh = m;
    }
    
    public abstract class Weapon
    {
        public Rigidbody projectilePrefab;
        public Transform barrelEnd;
        public int velocity;
        // generic shooting, inherited classes will overwrite
        // reload? 
        
        public abstract void fire();
    }

    public abstract class SingleShotWeapon : Weapon
    {
        public bool hasFired;
        int cycleSpeed;

    }

    public abstract class MultiFireWeapon : Weapon
    {
        int RPM;
    }


    class Spinfusor : SingleShotWeapon
    {
        int torque = 500;
        
        public Spinfusor(Rigidbody prefab, Transform barrel)
        {
            barrelEnd = barrel;
            projectilePrefab = prefab;
            velocity = 2000;
        }
        
        public override void fire()
        {
            Rigidbody discInstance;
            discInstance = Instantiate(projectilePrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
            discInstance.AddForce(barrelEnd.up * -1 * velocity);
            discInstance.AddTorque(new Vector3(0, torque, 0));
        }
    }

    class Rifle : Weapon
    {
        public Rifle()
        {
            velocity = 6000;
        }

        public override void fire()
        {
            Rigidbody bulletInstance;
            bulletInstance = Instantiate(projectilePrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
            bulletInstance.AddForce(barrelEnd.forward * velocity);
        }
    }
}
