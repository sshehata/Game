using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float turnSmoothing = 90.0f;

	private Animator anim;
	private HashIDs hash;
	
	void Awake ()
	{
		anim = GetComponent<Animator> ();
		hash = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<HashIDs> ();
	}
	
	void FixedUpdate ()
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		bool r = Input.GetKey (KeyCode.LeftShift);

		MovementManagement (v, h, r);
	}
	
	void MovementManagement (float vertical, float horizontal, bool run)
	{
		if (horizontal != 0f || vertical != 0f) {
			Rotating (horizontal);
			anim.SetFloat (hash.speedFloat, vertical);
			anim.SetFloat (hash.directionFloat, horizontal);
			anim.SetBool (hash.runBool, run);
		} else {
			anim.SetFloat (hash.speedFloat, 0f);
		}
	}
	
	void Rotating (float horizontal)
	{
		transform.Rotate (new Vector3 (0, horizontal * Time.deltaTime * turnSmoothing, 0));
	}
	
}