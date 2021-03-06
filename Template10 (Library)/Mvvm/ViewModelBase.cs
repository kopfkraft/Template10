﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Template10.Common;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;

namespace Template10.Mvvm
{
    // DOCS: https://github.com/Windows-XAML/Template10/wiki/Docs-%7C-MVVM
    public abstract class ViewModelBase : BindableBase, INavigable
    {
        public virtual void OnNavigatedTo(object parameter, NavigationMode mode, IDictionary<string, object> state) { /* nothing by default */ }
        public virtual Task OnNavigatedFromAsync(IDictionary<string, object> state, bool suspending) { return Task.FromResult<object>(null); }
        public virtual void OnNavigatingFrom(Services.NavigationService.NavigatingEventArgs args) { /* nothing by default */ }

        [JsonIgnore]
        public NavigationService NavigationService { get; set; }
        [JsonIgnore]
        public DispatcherWrapper Dispatcher { get { return Common.WindowWrapper.Current(NavigationService)?.Dispatcher; } }
        [JsonIgnore]
        public Common.StateItems SessionState { get { return BootStrapper.Current.SessionState; } }
    }
}