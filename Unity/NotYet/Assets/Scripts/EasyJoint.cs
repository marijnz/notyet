using UnityEngine;
using System.Collections;

public class EasyJoint : MonoBehaviour {

    public Transform ConnectTo;

    Vector3 offset;
	// Use this for initialization
	void Start () {
       // offset = this.transform.position - ConnectTo.position;

        offset = Vector3.zero;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        this.transform.position = (ConnectTo.transform.position + offset);



	}
}
