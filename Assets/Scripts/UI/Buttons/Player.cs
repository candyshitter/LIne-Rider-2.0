using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
	private const int MAX_SPEED = 75; //Depends on the Fixed update time step (0.008)
	private Rigidbody2D _rigidBody;
	private Vector3 _startingPosition;
	private Vector2 _velocity;

	public event Action OnResetPos;
	public event Func<bool> OnCanStart;

	private void Awake()
	{
		_rigidBody = GetComponent<Rigidbody2D>();
		_startingPosition = transform.position;
		GameStateHolder.OnStartPlaying += Play;
		GameStateHolder.OnEndPlaying += Pause;
	}
	private void FixedUpdate()
	{
		if(_rigidBody.velocity.magnitude < MAX_SPEED) return;
		_rigidBody.velocity = _rigidBody.velocity.normalized * MAX_SPEED;
	}

	private void Play()
	{
		if(OnCanStart != null)
			StartCoroutine(PlayRoutine());
		else
			PlayImmediate();
	}

	private void PlayImmediate()
	{
		_rigidBody.bodyType = RigidbodyType2D.Dynamic;
		_rigidBody.velocity = _velocity;
	}

	private IEnumerator PlayRoutine()
	{
		yield return new WaitUntil(OnCanStart);
		PlayImmediate();
	}

	public void ResetPosition()
	{
		GameStateHolder.IsPlaying = false;
		PlayToggle.Reset();
		transform.position = _startingPosition;
		_velocity = default;
		OnResetPos?.Invoke();
	}

	private void Pause()
	{
		StopCoroutine(PlayRoutine());
		_velocity = _rigidBody.velocity;
		_rigidBody.bodyType = RigidbodyType2D.Static;
	}
}