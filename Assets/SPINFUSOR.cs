using UnityEngine;
using System.Collections;

public class SPINFUSOR : MonoBehaviour {

    public Rigidbody discPrefab;
    public Transform barrelEnd;

    // Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Fire1"))
        {
            Rigidbody discInstance;
            discInstance = Instantiate(discPrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
            discInstance.AddForce(barrelEnd.up * -1 * 2000);
            discInstance.AddTorque(new Vector3(0, 500, 0));
            //discInstance.AddTorque(new Vector3(0, 0, 50));
        }
	}
}
