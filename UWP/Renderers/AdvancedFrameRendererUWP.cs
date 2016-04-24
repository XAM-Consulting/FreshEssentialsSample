using FreshEssentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms.Platform.UWP;
using Xamarin.Forms;
using Windows.UI.Xaml.Media;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(AdvancedFrame), typeof(FreshEssentials.UWP.AdvancedFrameRendererUWP))]
namespace FreshEssentials.UWP
{
    public class AdvancedFrameRendererUWP : FrameRenderer
    {
        AdvancedFrame myFrame;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                myFrame = (e.NewElement as AdvancedFrame);
                
                int topLeft = myFrame.Corners == RoundedCorners.left || myFrame.Corners == RoundedCorners.all ? myFrame.CornerRadius : 0;
                int topRight = myFrame.Corners == RoundedCorners.right || myFrame.Corners == RoundedCorners.all ? myFrame.CornerRadius : 0;
                int bottomRight = myFrame.Corners == RoundedCorners.right || myFrame.Corners == RoundedCorners.all ? myFrame.CornerRadius : 0;
                int bottomLeft = myFrame.Corners == RoundedCorners.left || myFrame.Corners == RoundedCorners.all ? myFrame.CornerRadius : 0;

                this.Control.CornerRadius = new CornerRadius(topLeft, topRight, bottomRight, bottomLeft);

                if (myFrame.InnerBackground != null)
                    this.Control.Background = new SolidColorBrush(
                        Windows.UI.Color.FromArgb(
                            (byte)Math.Round(myFrame.InnerBackground.A * 255),
                            (byte)Math.Round(myFrame.InnerBackground.R * 255),
                            (byte)Math.Round(myFrame.InnerBackground.G * 255),
                            (byte)Math.Round(myFrame.InnerBackground.B * 255)
                            ));
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == "InnerBackground" || e.PropertyName == "OutlineColor")
            {
                this.UpdateNativeControl();
            }
        }
        
    }
}