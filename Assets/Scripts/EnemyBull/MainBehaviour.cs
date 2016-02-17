using UnityEngine;
using System.Collections;


public enum StateID
{
	NullState = 0,
	IdleBull = 1,
	AttackBull = 2,
	RecoverBull = 3
}


public class MainBehaviour : MonoBehaviour {

	private StateMachine _stateMachine;

	[SerializeField] private float _maxSpeed = 5;
	[SerializeField] private float _mass = 20;
	[SerializeField] private float _turnSpeed;

	private Vector3 _currentVelocity;
	private Vector3 _currentPosition;
	private Vector3 _currentTarget;

	public Vector3 currentTarget
	{
		get { return _currentTarget;	}
		set { currentTarget = _currentTarget; }
	}
	private Quaternion _rotation;

	void Start () {

		_stateMachine = GetComponent<StateMachine> ();

		MakeStates ();


			_stateMachine.SetState (StateID.IdleBull);
	}

	void MakeStates()
	{
		_stateMachine.AddState (StateID.IdleBull, GetComponent<IdleBehaviour> () );
		_stateMachine.AddState (StateID.AttackBull, GetComponent<AttackBehaviour> () );
		_stateMachine.AddState (StateID.RecoverBull, GetComponent<RecoverState> ());


	}

	public void setTarget(Vector3 target)
	{
		_currentTarget = target;
	}

	public void Seek()
	{
		if (_currentTarget != null) {
			
			Vector3 desiredStep = _currentTarget - _currentPosition;

			desiredStep.Normalize ();
			Vector3 desiredVelocity = desiredStep * _maxSpeed;

			Vector3 steeringForce = desiredVelocity - _currentVelocity;
			_currentVelocity += steeringForce / _mass;

			_currentPosition += _currentVelocity * Time.deltaTime;
			_currentPosition.y = 0.1f;

			transform.position = _currentPosition;
			Rotating ();
		}
	}

	public void Rotating()
	{
			if (currentTarget != null) 
			{
			
			Vector3 targetDir = currentTarget - transform.position;
			float step = (_maxSpeed * Time.deltaTime)/2;
			Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, step, 0.0f);
			transform.rotation = Quaternion.LookRotation (newDir);

			}
	}
	

}
