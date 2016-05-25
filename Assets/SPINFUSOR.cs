using UnityEngine;
using System.Collections;

public class SPINFUSOR : MonoBehaviour {

    public GameObject disc;
    Rigidbody discBody;
    private int speed = 70;

    void Start()
    {
        discBody = disc.GetComponent<Rigidbody>();
    }

	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            //GameObject firedDisc = (GameObject)Instantiate(disc, transform.parent.rotation.eulerAngles, new Quaternion());
            //firedDisc.transform.position = 
        }

	}
}
