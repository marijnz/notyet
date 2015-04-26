using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class ChairController : MonoBehaviour {

    public float maxHeight = 3;
    public float resizeSpeed = 0.05f;

    public Transform Ladder;
    public Transform LadderBottom;

    float ladderHeight = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float h = CrossPlatformInputManager.GetAxis("Vertical");

        ladderHeight += (h * resizeSpeed);

        ladderHeight = Mathf.Clamp(ladderHeight, 1, 3);

        Ladder.localScale = new Vector3(1, ladderHeight, 1);
        Ladder.position = LadderBottom.transform.position + new Vector3(0, ladderHeight, 0);

	}
}
