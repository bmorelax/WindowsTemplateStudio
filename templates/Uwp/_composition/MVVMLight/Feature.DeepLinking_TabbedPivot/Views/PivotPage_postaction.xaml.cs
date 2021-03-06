﻿//{[{
using System.Linq;
using Param_ItemNamespace.Activation;
using Param_ItemNamespace.Helpers;
//}]}
namespace Param_ItemNamespace.Views
{
    public sealed partial class PivotPage : Page
    {
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
//{[{
            if (e.Parameter is SchemeActivationData data)
            {
                await InitializeFromSchemeActivationAsync(data);
            }

//}]}
        }

//{[{    
        public async Task InitializeFromSchemeActivationAsync(SchemeActivationData schemeActivationData)
        {
            var selected = pivot.Items.Cast<PivotItem>()
                    .FirstOrDefault(i => i.IsOfViewModelName(schemeActivationData.ViewModelName));

            var page = selected?.GetPage<IPivotActivationPage>();

            pivot.SelectedItem = selected;
            await page?.OnPivotActivatedAsync(schemeActivationData.Parameters);
        }
//}]}
    }
}
