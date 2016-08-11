using Foundation;
using System;
using UIKit;
using CoreGraphics;

namespace XamarinTest.iOS
{
    public partial class PhotoCell : UICollectionViewCell
    {
        public static readonly NSString CellId = new NSString("PhotoCell");
		UIImageView imageView;

		public PhotoCell (IntPtr handle) : base (handle)
        {
			SetupCell();
        }

		[Export("initWithCoder:")]
		public PhotoCell()
		{
			SetupCell();
		}

		[Export("initWithFrame:")]
		public PhotoCell(CGRect frame) : base(frame)
		{
			SetupCell();
		}

		public void SetupCell()
		{
			BackgroundColor = UIColor.LightGray;
			ContentView.Layer.BorderColor = UIColor.FromRGB(201, 201, 201).CGColor;
			ContentView.Layer.BorderWidth = 1.0f;

			ContentView.BackgroundColor = UIColor.FromRGB(246, 246, 246);

			imageView = new UIImageView(CellImage());
			imageView.Center = ContentView.Center;
			imageView.ContentMode = UIViewContentMode.ScaleAspectFill;
			imageView.TranslatesAutoresizingMaskIntoConstraints = false;
			imageView.ClipsToBounds = true;

			ContentView.AddSubview(imageView);

			var views = NSDictionary.FromObjectsAndKeys(new Object[] { imageView }, new NSObject[] { new NSString("image") });
			ContentView.AddConstraints(
				NSLayoutConstraint.FromVisualFormat("H:|-10-[image]-10-|", 0, new NSDictionary(), views)
			);
			ContentView.AddConstraints(
				NSLayoutConstraint.FromVisualFormat("V:|-10-[image]-10-|", 0, new NSDictionary(), views)
			);
		}

		static UIImage CellImage()
		{
			using (var url = new NSUrl(PhotoClass.ImageURL()))
			using (var data = NSData.FromUrl(url))
				return UIImage.LoadFromData(data);
		}
    }
}