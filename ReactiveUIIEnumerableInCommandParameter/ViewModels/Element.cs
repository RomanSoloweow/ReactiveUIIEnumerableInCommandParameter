using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ReactiveUIIEnumerableInCommandParameter.ViewModels
{
    public class Element:ReactiveObject
    {
        [Reactive] public string Text { get; set; }
        [Reactive] public bool IsSelected { get; set; }
    }
}