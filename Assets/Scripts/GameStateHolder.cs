using System;

public static class GameStateHolder
{
	private static bool _IsPlaying;
	
	public static event Action OnStartPlaying;
	public static event Action OnEndPlaying;
	
	public static bool IsPlaying
	{
		get => _IsPlaying;
		set
		{
			if (value == _IsPlaying) return;
			if (value)
				OnStartPlaying?.Invoke();
			else
				OnEndPlaying?.Invoke();
			_IsPlaying = value;
		}
	}
	
	
}