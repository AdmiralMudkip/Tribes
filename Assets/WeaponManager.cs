using UnityEngine;
using System.Collections;
using System;

public class WeaponManager : MonoBehaviour {
    
    public Weapon[] weapons;
    public Rigidbody[] projectilePrefabs;
    public GameObject weaponPlacement;
    public Transform[] barrelEnds;


    public int activeWeapon = 0;
    
    public string[] weaponDirectories = { "SpinfusorPrefab", "RiflePrefab" };

    void Start()
    {
        weapons = new Weapon[5];
        
        weapons[0] = new Spinfusor(projectilePrefabs[0], barrelEnds[0], 2);
        weapons[1] = new Rifle(projectilePrefabs[1], barrelEnds[1], .01f);
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
    

    class Spinfusor : Weapon
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
            Weapon.ready = false;
            
            Rigidbody discInstance;
            discInstance = Instantiate(projectilePrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
            discInstance.velocity = barrelEnd.forward * velocity;
        }
    }

    class Rifle : Weapon
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
            Rigidbody bulletInstance;
            bulletInstance = Instantiate(projectilePrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
            bulletInstance.velocity = barrelEnd.forward * velocity;
        }
    }
}
