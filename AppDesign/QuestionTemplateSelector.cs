using System.Windows;
using System.Windows.Controls;
using Examination_System.Question;

namespace ExaminationSystem
{
    public class QuestionTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ChooseOneTemplate { get; set; }
        public DataTemplate ChooseAllTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is QuestionWrapper wrapper)
            {
                if (wrapper.Question is ChooseOneQuestion)
                    return ChooseOneTemplate;
                if (wrapper.Question is ChooseAllQuestion)
                    return ChooseAllTemplate;
            }
            return null;
        }
    }
} 