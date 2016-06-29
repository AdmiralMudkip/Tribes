using UnityEngine;
using System.Collections;
using System;

public class WeaponManager : MonoBehaviour {
    
    public Weapon[] weapons;
    public Transform barrelEnd;
    public Rigidbody[] projectilePrefabs;
    public GameObject weaponPlacement;
    public int activeWeapon;

    public string[] weaponDirectories = { "SpinfusorPrefab", "RiflePrefab" };

    void Start()
    {
        //weaponPlacement.
        activeWeapon = 1;
        weapons = new Weapon[5];
        
        weapons[0] = new Spinfusor(projectilePrefabs[0], barrelEnd, 2);
        weapons[1] = new Rifle(projectilePrefabs[1], barrelEnd, .01f);
        loadWeapon(activeWeapon);
    }
    
    // Update is called once per frame
	void Update () {
        // dakka
        if (Input.GetButton("Fire1") && Weapon.ready)
        {
            weapons[activeWeapon].fire();
            Invoke("readyWeapon", weapons[activeWeapon].cycleSpeed);
        }
        weaponSwitch();
	}

    void readyWeapon()
    {
        Weapon.setReady();
    }

    void weaponSwitch()
    {
        if (Input.GetButtonDown("1"))
        {
            activeWeapon = 0;
        }
        else if (Input.GetButtonDown("2"))
        {
            activeWeapon = 1;
        }
        else if (Input.GetButtonDown("3"))
        {
            activeWeapon = 2;
        }
        else if (Input.GetButtonDown("4"))
        {
            activeWeapon = 3;
        }
        else if (Input.GetButtonDown("5"))
        {
            activeWeapon = 4;
        }

        loadWeapon(activeWeapon);
    }

    void loadWeapon(int num)
    {
        Mesh m = Resources.Load(weaponDirectories[num], typeof(Mesh)) as Mesh;
        GameObject gun = Resources.Load(weaponDirectories[num]) as GameObject;
        weaponPlacement.GetComponent<MeshFilter>().sharedMesh = gun.GetComponent<MeshFilter>().sharedMesh;
    }
    
    

    public abstract class Weapon
    {
        public Rigidbody projectilePrefab;
        public Transform barrelEnd;
        public int velocity;
        public static bool ready = true;
        public float cycleSpeed;
        // generic shooting, inherited classes will overwrite
        
        public abstract void fire();
        public static void setReady()
        {
            ready = true;
        }
    }

    public abstract class SingleShotWeapon : Weapon
    {
        public override void fire()
        {
            ready = false;
            
        }
    }

    public abstract class MultiFireWeapon : Weapon
    {

    }

    class Spinfusor : SingleShotWeapon
    {
        int torque = 500;
        
        public Spinfusor(Rigidbody prefab, Transform barrel, float cycleSpeed)
        {
            barrelEnd = barrel;
            projectilePrefab = prefab;
            velocity = 20;
            this.cycleSpeed = cycleSpeed;
        }
        
        public override void fire()
        {
            base.fire();
            
            Rigidbody discInstance;
            discInstance = Instantiate(projectilePrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
            discInstance.velocity = barrelEnd.forward * velocity;
        }
    }

    class Rifle : SingleShotWeapon
    {
        public Rifle(Rigidbody prefab, Transform barrel, float cycleSpeed)
        {
            barrelEnd = barrel;
            projectilePrefab = prefab;
            velocity = 60;
            this.cycleSpeed = cycleSpeed;
        }

        public override void fire()
        {
            base.fire();
            Rigidbody bulletInstance;
            bulletInstance = Instantiate(projectilePrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
            bulletInstance.velocity = barrelEnd.forward * velocity;
        }
    }
}
