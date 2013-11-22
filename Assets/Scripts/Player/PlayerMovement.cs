using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 4.0f;
	public float turnSmoothing = 90.0f;

	private Animator anim;
	private HashIDs hash;
	
	void Awake()
	{
		anim = GetComponent<Animator> ();
		hash = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<HashIDs> ();
	}
	
	void FixedUpdate()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		bool running = Input.GetKey(KeyCode.LeftShift);

		MovementManagement(vertical, horizontal, running);
	}
	
	void OnAnimatorMove()
	{
		bool running = anim.GetBool(hash.runBool);
		float horizontal = anim.GetFloat(hash.directionFloat);
		float vertical = anim.GetFloat(hash.speedFloat);
		Vector3 position = transform.localPosition;
		
		if (running) {
			speed = 6.0f;
			if (vertical != 0)
				Rotate(horizontal);
		} else {
			speed = 4.0f;
			position.x += speed * horizontal * Time.deltaTime;
		}
		
		transform.position += transform.forward * speed * vertical * Time.deltaTime;
	}
	
	void MovementManagement(float vertical, float horizontal, bool running)
	{
			anim.SetFloat(hash.speedFloat, vertical);
			anim.SetFloat(hash.directionFloat, horizontal);
			anim.SetBool(hash.runBool, running);
	}
	
	void Rotate (float horizontal)
	{
		transform.Rotate (new Vector3 (0, horizontal * Time.deltaTime * turnSmoothing, 0));
	}
	
}