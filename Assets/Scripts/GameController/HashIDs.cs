using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour
{
	// Controller States
	public int walkState;
	public int runState;
	public int turnRightState;
	public int turnLeftState;

	// Controller Parameters
	public int speedFloat;
	public int directionFloat;
	public int runBool;

	void Awake ()
	{
		walkState = Animator.StringToHash ("Base Layer.Walk");
		runState = Animator.StringToHash ("Base Layer.Run");
		turnRightState = Animator.StringToHash ("Base Layer.Turn_Right");
		turnLeftState = Animator.StringToHash ("Base Layer.Turn_Left");

		speedFloat = Animator.StringToHash ("Speed");
		directionFloat = Animator.StringToHash ("Direction");
		runBool = Animator.StringToHash ("Run");
	}
	
}
