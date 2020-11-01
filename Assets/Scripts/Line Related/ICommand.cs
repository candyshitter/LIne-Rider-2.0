using System.Collections.Generic;

public interface ICommand
{
	void Redo();
	void Undo();
}

public class CommandProcessor
{
	private readonly List<ICommand> _commandHistory = new List<ICommand>();
	private int _currentIndex = -1;
	public int maxNumberItems;

	private bool HasTooManyItems => _commandHistory.Count >= maxNumberItems;

	public void AddCommand(ICommand command)
	{
		if (HasTooManyItems) return;
		_currentIndex++;
		RefreshIndices();
		_commandHistory.Add(command);
	}

	private void RefreshIndices()
	{
		_commandHistory.RemoveRange(
			_currentIndex + 1,
			_commandHistory.Count - _currentIndex); // + sth probably

	}

	public void UndoCommand()
	{
		if (_currentIndex > -1)
			_commandHistory[_currentIndex--].Undo();
	}

	public void RedoCommand()
	{
		if(_commandHistory.Count - 1 > _currentIndex)
			_commandHistory[++_currentIndex].Redo();
	}

}