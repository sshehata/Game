using UnityEngine;
using System.Collections;

public class Locomotion
{
	private Animator m_Animator = null;
	private HashIDs hash = null;
	public float m_SpeedDampTime = 0.1f;
	public float m_AnguarSpeedDampTime = 0.25f;
	public float m_DirectionResponseTime = 0.2f;

	public Locomotion (Animator animator)
	{
		m_Animator = animator;
		hash = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<HashIDs> ();
	}

	public void Do (float speed, float direction)
	{
		AnimatorStateInfo state = m_Animator.GetCurrentAnimatorStateInfo (0);

		bool inTransition = m_Animator.IsInTransition (0);
		bool inIdle = state.IsName ("Locomotion.Idle");
		bool inTurn = state.IsName ("Locomotion.TurnOnSpot") || state.IsName ("Locomotion.PlantNTurnLeft") || state.IsName ("Locomotion.PlantNTurnRight");
		bool inWalkRun = state.IsName ("Locomotion.WalkRun");

		float speedDampTime = inIdle ? 0 : m_SpeedDampTime;
		float angularSpeedDampTime = inWalkRun || inTransition ? m_AnguarSpeedDampTime : 0;
		float directionDampTime = inTurn || inTransition ? 1000000 : 0;

		float angularSpeed = direction / m_DirectionResponseTime;
        
		m_Animator.SetFloat (hash.speedFloat, speed, speedDampTime, Time.deltaTime);
		m_Animator.SetFloat (hash.angularSpeedFloat, angularSpeed, angularSpeedDampTime, Time.deltaTime);
		m_Animator.SetFloat (hash.directionFloat, direction, directionDampTime, Time.deltaTime);
	}	
}
