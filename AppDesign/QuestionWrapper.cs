using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Examination_System.Answer;
using Examination_System.Question;

namespace ExaminationSystem
{
	public class QuestionWrapper : INotifyPropertyChanged
	{
		public MyQuestion Question { get; }

		public ObservableCollection<MyAnswerWrapper> WrappedAnswers { get; }
		public QuestionWrapper(MyQuestion question)
		{
			Question = question;
			WrappedAnswers = new ObservableCollection<MyAnswerWrapper>(
		   Question.MyAnswerList.Select(a => new MyAnswerWrapper(a))
	   );

		}
		public string[] GetSelectedAnswers()
		{
			var selectedAnswers = WrappedAnswers
				.Where(wrapper => wrapper.IsSelected)
				.Select(wrapper => wrapper.OriginalAnswer.AnswerId).ToArray();

			return selectedAnswers;
			//Debug.WriteLine("Selected Answers: " +
			//	string.Join(", ", selectedAnswers.Select(a => a.AnswerId)));
		}

		private bool _isFlaged;
		private bool _isFoucsed;
		private bool _isAnswering;
		public bool IsAnswering
		{
			get => _isAnswering;
			set
			{
				if (_isAnswering != value)
				{
					_isAnswering = value;
					OnPropertyChanged(nameof(IsAnswering));
				}
			}
		}
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
		
		public string CorrectAnswer { get { return string.Join(" , ", Question.CorrectAnswerId); } }
		public event PropertyChangedEventHandler? PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}