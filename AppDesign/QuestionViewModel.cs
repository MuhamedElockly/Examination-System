using Examination_System.Question;
using System.ComponentModel;

public class QuestionViewModel : INotifyPropertyChanged
{
	public MyQuestion Question { get; }

	public QuestionViewModel(MyQuestion question)
	{
		Question = question;
	}

	private bool _isFlaged;
	public bool IsFlaged
	{
		get => _isFlaged;
		set
		{
			if (_isFlaged != value)
			{
				_isFlaged = value;
				OnPropertyChanged(nameof(IsFlaged));
			}
		}
	}

	public event PropertyChangedEventHandler? PropertyChanged;
	protected virtual void OnPropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}