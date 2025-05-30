using Examination_System.Answer;
using System.ComponentModel;

public class MyAnswerWrapper : INotifyPropertyChanged
{
	private readonly MyAnswer _originalAnswer;
	private bool _isSelected;

	public MyAnswerWrapper(MyAnswer originalAnswer)
	{
		_originalAnswer = originalAnswer;
	}

	public bool IsSelected
	{
		get => _isSelected;
		set
		{
			_isSelected = value;
			OnPropertyChanged(nameof(IsSelected));
		}
	}

	public string AnswerBody => _originalAnswer.AnswerBody;
	public string AnswerId => _originalAnswer.AnswerId;
	public string FullAnswerText => $"{AnswerId}-{AnswerBody}";

	public MyAnswer OriginalAnswer => _originalAnswer;
	public event PropertyChangedEventHandler PropertyChanged;
	protected void OnPropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}