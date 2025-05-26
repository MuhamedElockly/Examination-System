using AppDesign;
using Examination_System.Answer;
using Examination_System.Exam;
using Examination_System.Json;
using Examination_System.Question;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ExaminationSystem
{
	public partial class ExaminationWindow : Window
	{
		private int currentQuestionIndex = 0;
		private TimeSpan remainingTime = TimeSpan.FromMinutes(60);
		private MyExam myExam;
		private Border _lastSelectedBorder;
		private List<int> FlagedIndexs;
		private ContentControl containerCopy = null;
		private ObservableCollection<QuestionWrapper> _wrappedQuestions;


		public ExaminationWindow()
		{
			InitializeComponent();
			InitializeTimer();
			myExam = JsonHandler.CreateExam();

			_wrappedQuestions = new ObservableCollection<QuestionWrapper>(
				myExam.Questions.Select(q => new QuestionWrapper(q))
			);

			ItemControlList.ItemsSource = _wrappedQuestions;
			NavListView.ItemsSource = _wrappedQuestions;
			FlagedIndexs = new List<int>();
		}

		private void InitializeTimer()
		{
			var timer = new System.Windows.Threading.DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += Timer_Tick;
			timer.Start();
		}
		private void RadioButton_Checked(object sender, RoutedEventArgs e)
		{
			if (sender is RadioButton radioButton && radioButton.IsChecked == true)
			{
				// Get the bound answer

				MessageBox.Show($"You selected: ",
							  "Selection Made",
							  MessageBoxButton.OK,
							  MessageBoxImage.Information);

			}
		}
		private void SelectNavQuestion(int index)
		{
			if (index >= 0 && index < NavListView.Items.Count)
			{
				NavListView.SelectedIndex = index;
				NavListView.ScrollIntoView(NavListView.SelectedItem);
			}
		}


		private void ScrollToQuestion(int index)
		{

			if (ItemControlList.Items.Count <= index || index < 0)
				return;


			var container = ItemControlList.ItemContainerGenerator.ContainerFromIndex(index) as FrameworkElement;
			if (container != null)
			{
				// Find the Border in the container's visual tree
				var border = FindVisualChild<Border>(container);

				container.BringIntoView();
				//ChangeQuestionStyle(index);

			}
		}

		// Helper method to find child of type T in visual tree
		private T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
		{
			for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
			{
				var child = VisualTreeHelper.GetChild(parent, i);
				if (child is T result)
					return result;
				var descendant = FindVisualChild<T>(child);
				if (descendant != null)
					return descendant;
			}
			return null;
		}

		private void NavItemClicked(object sender, RoutedEventArgs e)
		{
			//MessageBox.Show("nav clicke");
			if (sender is Border border && border.DataContext is QuestionWrapper questionWrapper)
			{
				_wrappedQuestions[currentQuestionIndex].IsFoucsed = false;
				currentQuestionIndex = questionWrapper.Question.Id - 1;
				_wrappedQuestions[currentQuestionIndex].IsFoucsed = true;
				SelectNavQuestion(questionWrapper.Question.Id - 1);

				ScrollToQuestion(questionWrapper.Question.Id - 1);
			}
		}
		private void ChangeQuestionStyle(int index)
		{


			if (containerCopy != null)
			{

				//	var containerBorder = FindVisualChild<Border>(containerCopy);
				//	MessageBox.Show(containerCopy.ToString());
				_lastSelectedBorder.BorderBrush = containerCopy.BorderBrush;
				_lastSelectedBorder.BorderThickness = containerCopy.BorderThickness;
			}
			var container = ItemControlList.ItemContainerGenerator.ContainerFromIndex(index) as FrameworkElement;

			// For items with bindings, recreate the template instead

			//if (_lastSelectedBorder != null)
			//{
			//	_lastSelectedBorder.BorderBrush = Brushes.Black;
			//	_lastSelectedBorder.BorderThickness = new Thickness(2);
			//	MessageBox.Show($"{((MyQuestion)_lastSelectedBorder.DataContext).Id.ToString()} < {_lastSelectedBorder.BorderBrush}");
			//}
			if (container != null)
			{
				var border = FindVisualChild<Border>(container);

				//containerCopy = new ContentControl
				//{
				//	ContentTemplate = ItemControlList.ItemTemplate,
				//	Content = container?.DataContext,
				//	BorderBrush = border.BorderBrush,
				//	BorderThickness = border.BorderThickness,
				//};
				//var bordertest = FindVisualChild<Border>(containerCopy);
				//MessageBox.Show(containerCopy.BorderBrush.ToString());
				//// Find the Border in the container's visual tree

				if (border != null)
				{
					//	// Apply selection style
					// From System.Windows.Media namespace
					SolidColorBrush brush = (SolidColorBrush)new BrushConverter().ConvertFrom("#2196F3");
					border.BorderBrush = brush;
					border.BorderThickness = new Thickness(3);
					_lastSelectedBorder = border;
				}
			}

		}
		private void QuestionContainer_MouseDown(object sender, MouseButtonEventArgs e)
		{

			if (sender is Border border2 && border2.DataContext is QuestionWrapper questionWrapper)
			{
				_wrappedQuestions[currentQuestionIndex].IsFoucsed = false;
				currentQuestionIndex = questionWrapper.Question.Id-1;
				_wrappedQuestions[currentQuestionIndex].IsFoucsed = true;
				SelectNavQuestion(questionWrapper.Question.Id - 1);

			}
		}
		private void Timer_Tick(object sender, EventArgs e)
		{
			remainingTime = remainingTime.Subtract(TimeSpan.FromSeconds(1));
			if (remainingTime.TotalSeconds <= 0)
			{
				MessageBox.Show("Time's up! Your exam will be submitted automatically.", "Time Expired", MessageBoxButton.OK, MessageBoxImage.Information);
				SubmitExam();
			}
			else
			{
				UpdateTimerDisplay();
			}
		}

		private void UpdateTimerDisplay()
		{
			// Update the timer display in the UI
			var timerTextBlock = this.FindName("TimerTextBlock") as TextBlock;
			if (timerTextBlock != null)
			{
				timerTextBlock.Text = $"Time Remaining: {remainingTime:mm\\:ss}";
			}
		}

		private void SubmitExam()
		{
			// TODO: Implement exam submission logic
			MessageBox.Show("Exam submitted successfully!", "Submission Complete", MessageBoxButton.OK, MessageBoxImage.Information);
			this.Close();
		}

		private void PreviousButton_Click(object sender, RoutedEventArgs e)
		{
			if (currentQuestionIndex > 0)
			{
				currentQuestionIndex--;
				LoadQuestion(currentQuestionIndex);
			}
		}

		private void NextButton_Click(object sender, RoutedEventArgs e)
		{
			// TODO: Implement navigation to next question
			currentQuestionIndex++;
			LoadQuestion(currentQuestionIndex);
		}

		private void LoadQuestion(int questionIndex)
		{
			// TODO: Implement question loading logic
			// This would typically load the question data from a database or other source
		}

		private void Grid_Loaded(object sender, RoutedEventArgs e)
		{
			_wrappedQuestions[currentQuestionIndex].IsFoucsed = true;						
			SelectNavQuestion(0);
			ScrollToQuestion(0);		
		}

		private void FlagImage_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (sender is Image flagImage && flagImage.DataContext is QuestionWrapper wrapper)
			{
				wrapper.IsFlaged = !wrapper.IsFlaged;
			}
		}
	}
}