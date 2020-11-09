using UnityEngine;

public class PlayerFollow
{
	private CameraFollow CameraFollow => CameraFollow.Instance;
	
	public void FollowPlayer()
	{
		if (!GameStateHolder.IsPlaying) return;
		
		var position = CameraFollow.transform.position;
		var playerPos = CameraFollow.Player.transform.position;
		position = Vector2.Lerp(position, playerPos, Time.deltaTime * CameraFollow.CameraSpeed);
		CameraFollow.transform.position = new Vector3(position.x, position.y, CameraFollow.transform.position.z);
	}
}