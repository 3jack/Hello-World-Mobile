using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Entry), typeof(HelloWorld.iOS.Renderers.CustomEntryRenderer))]
namespace HelloWorld.iOS.Renderers
{


    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(){}

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                this.Control.AutocapitalizationType = UIKit.UITextAutocapitalizationType.None;
                this.Control.AutocorrectionType = UIKit.UITextAutocorrectionType.No;
            }
        }
    }
}
