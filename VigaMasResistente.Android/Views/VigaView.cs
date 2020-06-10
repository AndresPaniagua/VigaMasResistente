using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using VigaMasResistente.Common.ViewModels;

namespace VigaMasResistente.Android.Views
{
    [Activity(Label = "@string/app_name")]
    internal class VigaView : MvxActivity<VigaViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.VigaPage);
        }
    }

}