using GongSolutions.Wpf.DragDrop;
using System.Collections.ObjectModel;
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
	public partial class MainWindow : Window
	{
		public ExampleViewModel Collection;
		
		public MainWindow()
		{
			Collection = new ExampleViewModel()
			{
				Items = new ObservableCollection<ExampleItemViewModel>()
				{
					new("item 1"),
					new("item 2"),
					new("item 3"),
					new("Benji could totally beat up john"),
					new("This is just some text, I totally can't regret this"),
					new("Your mic is probably on mute because I can't hear you trying to beat me up"),
					new("Also you would fail"),
				}
			};
			InitializeComponent();
			blah.ItemsSource = Collection.Items;
		}
	}


	public class ExampleViewModel : IDropTarget
	{
		public ObservableCollection<ExampleItemViewModel> Items;

		void IDropTarget.DragOver(IDropInfo dropInfo)
		{
			ExampleItemViewModel sourceItem = dropInfo.Data as ExampleItemViewModel;
			ExampleItemViewModel targetItem = dropInfo.TargetItem as ExampleItemViewModel;

			if (sourceItem != null && targetItem != null && targetItem.CanAcceptChildren)
			{
				dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
				dropInfo.Effects = DragDropEffects.Copy;
			}
		}

		void IDropTarget.Drop(IDropInfo dropInfo)
		{
			ExampleItemViewModel sourceItem = dropInfo.Data as ExampleItemViewModel;
			ExampleItemViewModel targetItem = dropInfo.TargetItem as ExampleItemViewModel;
			targetItem.Children.Add(sourceItem);
		}
	}

	public class ExampleItemViewModel
	{
		public ExampleItemViewModel(string t)
		{
			this.Text = t;
		}
		public override string ToString()
		{
			return Text;
		}
		public string Text;
		public bool CanAcceptChildren => false;
		public ObservableCollection<ExampleItemViewModel> Children { get; private set; }
	}
}