using UnityEngine;
using System.Collections;

public class BatHitpoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag.Contains("Enemy") && !col.gameObject.GetComponent<Enemy>().IsHit)
        {
            if (ChairController.Instance.isHitting)
            {
                Vector2 diff = col.gameObject.transform.position - this.transform.position;

                col.gameObject.GetComponent<Rigidbody2D>().AddForce(diff.normalized * 3000);

                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);


                col.gameObject.GetComponent<Enemy>().IsHit = true;
            }
        }
    }
}
