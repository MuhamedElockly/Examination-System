using System.ComponentModel;
using Examination_System.Question;

namespace ExaminationSystem
{
	public class QuestionWrapper : INotifyPropertyChanged
	{
		public MyQuestion Question { get; }

		public QuestionWrapper(MyQuestion question)
		{
			Question = question;
		}

		private bool _isFlaged;
		private bool _isFoucsed;

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
		public bool IsFoucsed
		{
			get => _isFoucsed;
			set
			{
				if (_isFoucsed != value)
				{
					_isFoucsed = value;
					OnPropertyChanged(nameof(IsFoucsed));
				}
			}
		}

		public event PropertyChangedEventHandler? PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}