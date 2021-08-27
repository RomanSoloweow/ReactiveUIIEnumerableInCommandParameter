using System.Linq;
using System.Reactive.Disposables;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using ReactiveUIIEnumerableInCommandParameter.ViewModels;

namespace ReactiveUIIEnumerableInCommandParameter.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.OneWayBind(ViewModel, 
                    x => x.ElementsForView, 
                    x => x.ElementsListBox.Items, 
                    x=>x.ToList()).DisposeWith(disposable);
                
                this.BindCommand(ViewModel, 
                    x=>x.DeleteElementsCommand, 
                    x=>x.InvokeCommandButton).DisposeWith(disposable);
                
                // this.BindCommand(ViewModel, 
                //     x=>x.ShowTextCommand, 
                //     x=>x.InvokeCommandButton).DisposeWith(disposable);

            });
        }

    }
}