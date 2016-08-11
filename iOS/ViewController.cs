using System;
using System.Drawing;
using Foundation;
using UIKit;

namespace XamarinTest.iOS
{
	public partial class ViewController : UIViewController
	{
		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			photosCollectionView.Source = new PhotoCollectionViewSource();
			photosCollectionView.Delegate = new PhotoCollectionViewLayoutDelegate();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}

		class PhotoCollectionViewSource : UICollectionViewSource
		{
			string[] data = { "image1", "image2", "image3", "image4", "image5", "image6", "image7", "image8" };

			public override nint GetItemsCount(UICollectionView collectionView, nint section)
			{
				return data.Length;
			}

			public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
			{
				var textCell = (PhotoCell)collectionView.DequeueReusableCell(PhotoCell.CellId, indexPath);

				return textCell;
			}

			public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
			{
				Console.WriteLine("Row {0} selected", indexPath.Row);
			}

			public override bool ShouldSelectItem(UICollectionView collectionView, NSIndexPath indexPath)
			{
				return true;
			}
		}

		class PhotoCollectionViewDelegate : UICollectionViewDelegate
		{
		}

		class PhotoCollectionViewLayoutDelegate : UICollectionViewDelegateFlowLayout 
		{
			public override CoreGraphics.CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
			{
				double width = Math.Min(collectionView.Frame.Width - 30, 300);
				double height = width / 1.618;
				return new CoreGraphics.CGSize(width, height);
			}
		}
	}
}


