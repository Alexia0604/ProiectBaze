using System.Windows;
using System.Windows.Controls;

namespace BibliotecaElectronica.View
{
    public partial class EditableField : UserControl
    {
        public EditableField()
        {
            InitializeComponent();
        }

        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(EditableField));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(EditableField));

        public bool IsEditing
        {
            get => (bool)GetValue(IsEditingProperty);
            set => SetValue(IsEditingProperty, value);
        }

        public static readonly DependencyProperty IsEditingProperty =
            DependencyProperty.Register("IsEditing", typeof(bool), typeof(EditableField));

        public object StartEditCommand
        {
            get => GetValue(StartEditCommandProperty);
            set => SetValue(StartEditCommandProperty, value);
        }

        public static readonly DependencyProperty StartEditCommandProperty =
            DependencyProperty.Register("StartEditCommand", typeof(object), typeof(EditableField));

        public object SaveEditCommand
        {
            get => GetValue(SaveEditCommandProperty);
            set => SetValue(SaveEditCommandProperty, value);
        }

        public static readonly DependencyProperty SaveEditCommandProperty =
            DependencyProperty.Register("SaveEditCommand", typeof(object), typeof(EditableField));

        public object CancelEditCommand
        {
            get => GetValue(CancelEditCommandProperty);
            set => SetValue(CancelEditCommandProperty, value);
        }

        public static readonly DependencyProperty CancelEditCommandProperty =
            DependencyProperty.Register("CancelEditCommand", typeof(object), typeof(EditableField));

        public string CommandParameter
        {
            get => (string)GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(string), typeof(EditableField));
    }
}