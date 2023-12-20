using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		// INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		// BindingTestCounter property
		private int _bindingTestCounter = 0;
		
		public int BindingTestCounter
		{
			get { return _bindingTestCounter; }
			set
			{
				_bindingTestCounter = value;
				OnPropertyChanged(nameof(BindingTestCounter));
			}
		}

		// BindingTestCounterIncrement button click
		private void BindingTestCounterIncrement_Click(object sender, RoutedEventArgs e)
		{
			BindingTestCounter++;
		}

		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = this;
		}
	}
}