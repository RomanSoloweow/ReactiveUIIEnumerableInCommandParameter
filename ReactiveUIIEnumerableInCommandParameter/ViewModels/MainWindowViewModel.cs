using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Text;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ReactiveUIIEnumerableInCommandParameter.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public SourceList<Element> Elements { get; } = new();
        public ObservableCollectionExtended<Element> ElementsForView = new();
        public readonly ReadOnlyObservableCollection<Element> _selectedElements;
        public ReadOnlyObservableCollection<Element>  SelectedElements => _selectedElements;
        public ReactiveCommand<IEnumerable<Element>, Unit> DeleteElementsCommand { get; set; }

        public MainWindowViewModel()
        {
            
            Elements.Connect()
                .Bind(ElementsForView)
                .Subscribe();
            
            Elements.Connect()
                .AutoRefresh(x => x.IsSelected)
                .Filter(x => x.IsSelected)
                .Bind(out _selectedElements).Subscribe();
            
            SelectedElements.ToObservableChangeSet()
                .Subscribe(x=>
                    this.RaisePropertyChanged(nameof(SelectedElements)));

            DeleteElementsCommand = ReactiveCommand.Create<IEnumerable<Element>>(DeleteElements);

            Elements.Add(new Element() { Text = "Element 1" });
            Elements.Add(new Element() { Text = "Element 2" });
            Elements.Add(new Element() { Text = "Element 3" });
            Elements.Add(new Element() { Text = "Element 4" });
            Elements.Add(new Element() { Text = "Element 5" });
        }

        private void DeleteElements(IEnumerable<Element> elements)
        {
            Elements.RemoveMany(elements);
            
            //here elements is empty
        }
    }
}