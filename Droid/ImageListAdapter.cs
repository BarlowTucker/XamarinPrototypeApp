using System;
using Android.Content;
using Android.Widget;
using Android.Views;
using Android.Graphics;
using System.Net;
using Android.Content.Res;

namespace XamarinTest.Droid
{
	public class ImageListAdapter: BaseAdapter
	{
		Context context;

		public ImageListAdapter(Context c)
		{
			context = c;
		}

		public override int Count
		{
			get { return 8; }
		}

		public override Java.Lang.Object GetItem(int position)
		{
			return null;
		}

		public override long GetItemId(int position)
		{
			return 0;
		}

		// create a new ImageView for each item referenced by the Adapter
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			ImageView imageView;

			if (convertView == null)
			{  // if it's not recycled, initialize some attributes
				imageView = new ImageView(context);
				int width = Math.Min(Resources.System.DisplayMetrics.WidthPixels - 30, ConvertDpToPixels(300));
				int height = Convert.ToInt32(width / 1.618);
				GridView.LayoutParams layoutParams = new GridView.LayoutParams(width, height);
				imageView.LayoutParameters = layoutParams;
				imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
				imageView.SetPadding(8, 8, 8, 8);
					
			}
			else {
				imageView = (ImageView)convertView;
			}

			var imageBitmap = GetImageBitmapFromUrl(PhotoClass.ImageURL());
			imageView.SetImageBitmap(imageBitmap);

			return imageView;
		}

		private Bitmap GetImageBitmapFromUrl(string url)
		{
			Bitmap imageBitmap = null;

			using (var webClient = new WebClient())
			{
				var imageBytes = webClient.DownloadData(url);
				if (imageBytes != null && imageBytes.Length > 0)
				{
					imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
				}
			}

			return imageBitmap;
		}

		private int ConvertPixelsToDp(float pixelValue)
		{
			var dp = (int)((pixelValue) / Resources.System.DisplayMetrics.Density);
			return dp;
		}

		private int ConvertDpToPixels(int dp)
		{
			var pixels = (int)((dp) * Resources.System.DisplayMetrics.Density);
			return pixels;
		}
	}
}

