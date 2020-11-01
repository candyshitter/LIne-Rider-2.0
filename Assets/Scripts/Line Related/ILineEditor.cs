public interface ILineEditor
{
	Line CurrentLine { get; set; }
	void CheckForLine();
	bool StopEditing();
	void UpdateLine();
}