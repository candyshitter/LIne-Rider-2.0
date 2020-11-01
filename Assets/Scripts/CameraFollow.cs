using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public static CameraFollow Instance { get; private set; }
	[SerializeField] private float cameraSpeed;

	private PlayerFollow _follower;
	private readonly PlayerFollow _playerFollow = new PlayerFollow();

	public float CameraSpeed => cameraSpeed;

	public Player Player { get; private set; }

	private void Awake()
	{
		if (HandleInstance())
			return;
		Player = FindObjectOfType<Player>();
		var startingPos = transform.position;
		Player.OnResetPos += () => transform.position = startingPos;
	}

	private bool HandleInstance()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return true;
		}
		Instance = this;
		return false;
	}

	private void FixedUpdate() => _follower?.FollowPlayer();

	public void HandleToggleChanged(bool isFollowing)
	{
		if (isFollowing)
		{
			Player.OnCanStart += InFollowPos;
			_follower = _playerFollow;
		}
		else
		{
			Player.OnCanStart -= InFollowPos;
			_follower = null;
		}
	}

	private bool InFollowPos() =>
		Vector2.Distance(transform.position, Player.transform.position) < 0.4f;
	
}