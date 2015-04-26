using UnityEngine;
using System.Collections;

public class FreezeLocalPosition : MonoBehaviour {

    Vector3 originalLocalPosition;
	// Use this for initialization
	void Start () {
	    originalLocalPosition = this.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.localPosition = originalLocalPosition;
	}
}
