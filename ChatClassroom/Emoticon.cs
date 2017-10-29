using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Drawing;
using RTF;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ChatClassroom
{
	class Emoticon
	{
		private static string _result;
		private static RTFBuilder sb;

		public static Dictionary<string[], Bitmap> emojis = new Dictionary<string[], Bitmap>()
		{
			{ new[] { ":)", ":D" }, Properties.Resources.Emoji_Smiley_01 },
			{ new[] { ":(" }, Properties.Resources.Emoji_Smiley_24 }
		};


		public static string Parse(string text, ref RichTextBox rtb)
		{

			foreach (KeyValuePair<string[], Bitmap> kvp in emojis)
			{
				foreach (var emoji in kvp.Key)
				{
					//Resize emoji
					if (text.Contains(emoji))
					{
						Bitmap img = Helpers.ResizeImage(emojis[kvp.Key], 18, 18); //
						

						//Bitmap img1 = new Bitmap(img.Width, img.Height);

						Bitmap clone = new Bitmap(img.Width, img.Height,System.Drawing.Imaging.PixelFormat.Format48bppRgb);

						using (Graphics gr = Graphics.FromImage(clone))
						{
							gr.SmoothingMode = SmoothingMode.HighQuality;
							gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
							gr.PixelOffsetMode = PixelOffsetMode.HighQuality;

							gr.Clear(Color.White);
							//gr.DrawImageUnscaled(img, 0, 0);

							gr.DrawImage(img, new PointF(0,3));
						} 
						

						text = text.Replace(emoji, new RTFBuilder().InsertImage(clone).ToString());

					}


				}

			}
			return text;
		}


	}
}
