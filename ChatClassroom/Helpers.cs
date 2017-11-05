using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Management;
using Tulpep.NotificationWindow;
using System.Drawing;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ChatClassroom
{
	public class Helpers
	{
		public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
		{
			// Unix timestamp is seconds past epoch
			System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
			dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
			return dtDateTime;
		}
		public static string TimeSpanToReadString(TimeSpan time)
		{
			int minutes = time.Minutes;
			int seconds = time.Seconds;
			int hours = time.Hours;

			string strbuild = null;
			if (hours != 0)
			{
				if (hours == 1)
					strbuild += hours + " hour ";
				else
					strbuild += hours + " hours ";

			}
			if (minutes != 0)
			{
				if (minutes == 1)
					strbuild += minutes + " minute and ";
				else
					strbuild += minutes + " minutes and ";
			}
			if (seconds != 0)
			{
				if (seconds == 1)
					strbuild += seconds + " second";
				else
					strbuild += seconds + " seconds";
			}
			return strbuild;
		}

		public static string identifier()
		//Return a hardware identifier
		{
			ManagementObjectCollection mbsList = null;
			ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
			mbsList = mbs.Get();
			string id = "";
			foreach (ManagementObject mo in mbsList)
			{
				id = mo["ProcessorID"].ToString();
			}

			ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
			ManagementObjectCollection moc = mos.Get();
			string motherBoard = "";
			foreach (ManagementObject mo in moc)
			{
				motherBoard = (string)mo["SerialNumber"];
			}

			return (id + motherBoard).Replace(" ", "").Replace(".", "").Trim().ToUpper();
		}

		public static string TimeTokenToDateTime(long token)
		{
			var epoch_time = (long)(token / 10000000);
			return UnixTimeStampToDateTime(epoch_time).ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
		}

		public static bool checkUsername(string str)
		{
			//check if user is null
			if (String.IsNullOrEmpty(str))
			{
				Helpers.Notification(Configuration.NOTIFICATION_TITLE, "Please enter a username.", Properties.Resources.error);
				return false;
			}

			if (str.Length > 19)
			{
				Helpers.Notification(Configuration.NOTIFICATION_TITLE, "Enter a Username with a maximum of 20 characters", Properties.Resources.error);
				return false;
			}

			if (str.Length < 6)
			{

				Helpers.Notification(Configuration.NOTIFICATION_TITLE, "Enter a username with a minimum of 5 characters", Properties.Resources.error);
				return false;
			}

			Regex r = new Regex("^[a-zA-Z0-9_]*$");
			if (!r.IsMatch(str))
			{
				Helpers.Notification(Configuration.NOTIFICATION_TITLE, "Invalid username, enter only alphanumeric characters and underscore", Properties.Resources.error);
				return false;
			}

			//TODO: check if username with same username is on channel...
			return true;

		}

		public static String Truncate(String input, int maxLength)
		{
			if (input.Length > maxLength)
				return input.Substring(0, maxLength);
			return input;
		}

		/// <summary>
		/// Decrypts the specified encryption key.
		/// </summary>
		/// <param name="encryptionKey">The encryption key.</param>
		/// <param name="cipherString">The cipher string.</param>
		/// <param name="useHashing">if set to <c>true</c> [use hashing].</param>
		/// <returns>
		///  The decrypted string based on the key
		/// </returns>
		public static string Decrypt(string encryptionKey, string cipherString, bool useHashing)
		{
			byte[] keyArray;
			//get the byte code of the string

			byte[] toEncryptArray = Convert.FromBase64String(cipherString);

			AppSettingsReader settingsReader = new AppSettingsReader();

			if (useHashing)
			{
				//if hashing was used get the hash code with regards to your key
				MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
				keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(encryptionKey));
				//release any resource held by the MD5CryptoServiceProvider

				hashmd5.Clear();
			}
			else
			{
				//if hashing was not implemented get the byte code of the key
				keyArray = UTF8Encoding.UTF8.GetBytes(encryptionKey);
			}

			TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
			//set the secret key for the tripleDES algorithm
			tdes.Key = keyArray;
			//mode of operation. there are other 4 modes.
			//We choose ECB(Electronic code Book)

			tdes.Mode = CipherMode.ECB;
			//padding mode(if any extra byte added)
			tdes.Padding = PaddingMode.PKCS7;

			ICryptoTransform cTransform = tdes.CreateDecryptor();
			byte[] resultArray = cTransform.TransformFinalBlock(
								 toEncryptArray, 0, toEncryptArray.Length);
			//Release resources held by TripleDes Encryptor
			tdes.Clear();
			//return the Clear decrypted TEXT
			return UTF8Encoding.UTF8.GetString(resultArray);
		}

		/// <summary>
		/// Encrypts the specified to encrypt.
		/// </summary>
		/// <param name="toEncrypt">To encrypt.</param>
		/// <param name="useHashing">if set to <c>true</c> [use hashing].</param>
		/// <returns>
		/// The encrypted string to be stored in the Database
		/// </returns>
		public static string Encrypt(string encryptionKey, string toEncrypt, bool useHashing)
		{
			byte[] keyArray;
			byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

			AppSettingsReader settingsReader = new AppSettingsReader();

			//If hashing use get hashcode regards to your key
			if (useHashing)
			{
				MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
				keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(encryptionKey));
				//Always release the resources and flush data
				// of the Cryptographic service provide. Best Practice

				hashmd5.Clear();
			}
			else
				keyArray = UTF8Encoding.UTF8.GetBytes(encryptionKey);

			TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
			//set the secret key for the tripleDES algorithm
			tdes.Key = keyArray;
			//mode of operation. there are other 4 modes.
			//We choose ECB(Electronic code Book)
			tdes.Mode = CipherMode.ECB;
			//padding mode(if any extra byte added)


			tdes.Padding = PaddingMode.PKCS7;

			ICryptoTransform cTransform = tdes.CreateEncryptor();
			//transform the specified region of bytes array to resultArray
			byte[] resultArray =
			  cTransform.TransformFinalBlock(toEncryptArray, 0,
			  toEncryptArray.Length);
			//Release resources held by TripleDes Encryptor
			tdes.Clear();
			//Return the encrypted data into unreadable string format
			return Convert.ToBase64String(resultArray, 0, resultArray.Length);
		}


		public static void Notification(string title, string content, Image image = null, int delay = 3000)
		{
			PopupNotifier popup = new PopupNotifier();
			popup.Delay = delay;
			popup.TitlePadding = new Padding(5,10,5,5);
			popup.ContentPadding = new Padding(5);
			popup.TitleFont = new Font("Arial", 10, FontStyle.Bold);
			popup.ContentFont = new Font("Arial", 10, FontStyle.Regular);
			popup.ContentHoverColor = Color.Black;
			popup.HeaderHeight = 13;
			popup.AnimationDuration = 400;
			popup.ImagePadding = new Padding(10, 15, 5, 5);
			popup.ImageSize = new Size(50, 50);
			popup.TitleText = title;
			popup.ContentText = content;
			popup.Image = image;
			popup.Popup();
			//popup.Dispose();
		}

		/// <summary>
		/// Resize the image to the specified width and height.
		/// </summary>
		/// <param name="image">The image to resize.</param>
		/// <param name="width">The width to resize to.</param>
		/// <param name="height">The height to resize to.</param>
		/// <returns>The resized image.</returns>
		public static Bitmap ResizeImage(Image image, int width, int height)
		{
			var destRect = new Rectangle(0, 0, width, height);
			var destImage = new Bitmap(width, height);

			destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

			using (var graphics = Graphics.FromImage(destImage))
			{
				graphics.CompositingMode = CompositingMode.SourceCopy;
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

				using (var wrapMode = new ImageAttributes())
				{
					wrapMode.SetWrapMode(WrapMode.TileFlipXY);
					graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
				}
			}

			return destImage;
		}

	}
}
