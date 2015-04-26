using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class ChairController : MonoBehaviour {

    public static ChairController Instance;

    public float maxHeight = 3;
    public float resizeSpeed = 0.05f;

    public Transform Ladder;
    public Transform LadderBottom;
    public Transform LadderRotationThing;

    float ladderHeight = 1;

    public bool isHitting = false;


    public Transform BatHand;

    private bool m_FacingRight = true;  // For determining which way the player is currently facing.


	// Use this for initialization
	void Awake () {
        Instance = this;
	}

    public void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
	
	// Update is called once per frame
	void Update () {
        float h = CrossPlatformInputManager.GetAxis("Vertical");

        ladderHeight += (h * resizeSpeed);

        ladderHeight = Mathf.Clamp(ladderHeight, 1, 3);

        Ladder.localScale = new Vector3(1, ladderHeight, 1);
      //  Ladder.position = LadderBottom.transform.position + new Vector3(0, ladderHeight, 0);



        if (Input.GetKeyDown("enter") && !isHitting)
        {
            BatHand.GetComponent<Rigidbody2D>().angularVelocity = 0;
          // BatHand.GetComponent<Rigidbody2D>().AddTorque(500);
           StopAllCoroutines();
           StartCoroutine(HitWithBat());
        }



        float move = Input.GetAxis("Horizontal2");
        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }

        Vector3 eulerOfLadder = LadderRotationThing.transform.rotation.eulerAngles;
        Debug.Log(move);
        float z = eulerOfLadder.z;
        z -= move * Time.deltaTime * 200;
        if (move > 0 && z < (360 - 60) && z > 60)
        {
            return;
        }

        if (move < 0 && z > (0 + 60) && z < (360 - 60))
        {
            return;
        }

        Vector3 newEuler = new Vector3(0,0, z);

        LadderRotationThing.transform.rotation = Quaternion.Euler(newEuler);

	}



    IEnumerator HitWithBat()
    {
        isHitting = true;


        while (BatHand.rotation.eulerAngles.z <= 130)
        {
            Vector3 euler =  BatHand.rotation.eulerAngles;
            euler.z += Time.deltaTime * 800;
            BatHand.rotation = Quaternion.Euler(euler);
            yield return new WaitForEndOfFrame();
        }


        while (BatHand.rotation.eulerAngles.z < 350)
        {
            Vector3 euler = BatHand.rotation.eulerAngles;
            euler.z -= Time.deltaTime * 500;
            BatHand.rotation = Quaternion.Euler(euler);
            yield return new WaitForEndOfFrame();
        }

        Vector3 eulerAgain = BatHand.rotation.eulerAngles;
        eulerAgain.z = 0 ;
        BatHand.rotation = Quaternion.Euler(eulerAgain);


        isHitting = false;
    }

    IEnumerator ReturnBat()
    {
        var batHandRigidBody = BatHand.GetComponent<Rigidbody2D>();
        batHandRigidBody.angularVelocity = 0;

        ;
        while (batHandRigidBody.rotation > 0)
        {
            batHandRigidBody.rotation -= Time.deltaTime * 300;
            yield return new WaitForEndOfFrame();
        }
        batHandRigidBody.angularVelocity = 0;
        //Vector2.Lerp(
        isHitting = false;
        yield return null;

    }


    IEnumerator HitBat()
    {
        var batHandRigidBody = BatHand.GetComponent<Rigidbody2D>();
        batHandRigidBody.angularVelocity = 0;
        while (true)
        {
            batHandRigidBody.rotation += Time.deltaTime * 300;
            yield return new WaitForEndOfFrame();
        }
        batHandRigidBody.angularVelocity = 0;
        //Vector2.Lerp(
        isHitting = false;
        yield return null;

    }


}
