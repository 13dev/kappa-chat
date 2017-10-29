using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PubnubApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using AsanDB;
using System.Globalization;
using RTF;
using System.Runtime.InteropServices;
using ChatClassroom.Properties;

namespace ChatClassroom
{
	public partial class Main : Form
	{

		public static Pubnub pubnub;
		private DB db;
		private RTFBuilderbase sb;

		[DllImport("user32.dll")]
		public static extern int FlashWindow(IntPtr Hwnd, bool Revert);

		//username
		private static string _username;

		public Main()
		{
			InitializeComponent();
			db = new DB();

			this.FormClosing += Main_FormClosing;

			PNConfiguration config = new PNConfiguration();

			// Add execptions
			AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

			config.SubscribeKey = Configuration.subscribeKey;
			config.PublishKey = Configuration.publishKey;
			config.SecretKey = Configuration.secretKey;

			//instanciate pubnub with configs
			pubnub = new Pubnub(config);
			sb = new RTFBuilder();

		}

		private void Form1_Load(object sender, EventArgs e)
		{

			pubnub.AddListener(new SubscribeCallbackExt(
			(pubnubObj, message) =>
			{
				Console.WriteLine("message" + message);
				// Handle new message stored in message.Message
				if (message != null)
				{
					if (message.Channel != null)
					{

						Invoke(new Action(() =>
						{
							//List<Message> iMessage = pubnub.JsonPluggableLibrary.DeserializeToListOfObject(message.ToString()).Cast<Message>().ToList();
							//var lMessage = JsonConvert.DeserializeObject<Message>(pubnub.JsonPluggableLibrary.SerializeToJsonString(message));

							// Message has been received on channel group stored in
							// message.Channel()
							var jMessage = JObject.Parse(pubnub.JsonPluggableLibrary.SerializeToJsonString(message.Message));


							sb.FontStyle(FontStyle.Bold)
							  .ForeColor(KnownColor.DarkGreen)
							  .Append($"<{Helpers.TimeTokenToDateTime(message.Timetoken)}> ")
							  .FontStyle(FontStyle.Regular);
							//rtbChat.Rtf += sb.ToString();

							if (jMessage["username"].ToString() == _username)
								sb.ForeColor(KnownColor.DarkRed).Append($"<{jMessage["username"]}>: ");
							else
							{
								sb.ForeColor(KnownColor.DarkBlue).FontStyle(FontStyle.Bold).Append($"<{jMessage["username"]}>: ").FontStyle(FontStyle.Regular);
								if (WindowState == FormWindowState.Minimized)
								{
									Helpers.Notification($"Kappa - New Message of {jMessage["username"]}", $"<{jMessage["username"]}>: {jMessage["msg"]}", Properties.Resources.new_message);
									FlashWindowHelper.Flash(this);
								}
							}

							sb.ForeColor(KnownColor.Black).FontStyle(FontStyle.Bold)
							.AppendLine($"{jMessage["msg"].ToString()}");

							rtbChat.Rtf = Emoticon.Parse(sb.ToString(), ref rtbChat);
							scrollToBottom();
						}));
					}
					/*
					else
					{
						Invoke(new Action(() =>
						{
							// Message has been received on channel stored in
							// message.Subscription()
							tbOutput.AppendText("message.Subscription " + pubnub.JsonPluggableLibrary.SerializeToJsonString(message));
						}));
					} */

					/*
						log the following items with your favorite logger
							- message.Message()
							- message.Subscription()
							- message.Timetoken()
					*/
				}
			},
			(pubnubObj, presence) =>
			{
				Invoke(new Action(() =>
				{

					var timestamp = Helpers.UnixTimeStampToDateTime(presence.Timestamp).ToString("dd/MM/yyyy HH:mm");

					if (presence == null) return;

					if (presence.State["username"] == null) return;

					if (presence.State["username"].ToString() == _username) return;

					sb.FontStyle(FontStyle.Bold)
					.ForeColor(KnownColor.DarkGreen)
					.Append($"<{timestamp}> ")
					.FontStyle(FontStyle.Bold)
					.ForeColor(KnownColor.LimeGreen);

					switch (presence.Event)
					{
						case "join":
							sb.AppendLine($"{presence.State["username"]} joined the chat! tell him hi!!");
							break;
						case "leave":
							sb.AppendLine($"{presence.State["username"]} Left the chat, we hope you come back!");
							break;

						case "timeout":
							sb.AppendLine($"{presence.State["username"]} Fell, we hope you come back!");
							break;
						case "state-change":
							sb.AppendLine($"{presence.State["username"]} Joined the chat! tell him hi!");
							break;

					}

					rtbChat.Rtf = Emoticon.Parse(sb.ToString(), ref rtbChat);
					scrollToBottom();

				}));

			},
				(pubnubObj, status) =>
				{
					if (status.Category == PNStatusCategory.PNUnexpectedDisconnectCategory)
					{
						// This event happens when radio / connectivity is lost
						Invoke(new Action(() =>
						{
							tbOutput.AppendText("Connection Lost ");
							Helpers.Notification(Configuration.NOTIFICATION_TITLE, "Connection Lost!", Properties.Resources.error);
							lbStatus.Text = "Connection Lost!";
							button1.Enabled = false;
							tbMessage.Enabled = false;
							tHereNow.Stop();
						}));

					}
					else if (status.Category == PNStatusCategory.PNConnectedCategory)
					{
						Invoke(new Action(() =>
						{
							// Connect event. You can do stuff like publish, and know you'll get it.
							// Or just use the connected event to confirm you are subscribed for
							// UI / internal notifications, etc

							tbOutput.AppendText("Connected! ");
							Helpers.Notification(Configuration.NOTIFICATION_TITLE, "Connected! \nEnjoy Made with ❤ 13dev.", Properties.Resources.info);
							lbStatus.Text = "Connected!";
							this.Width = 755;
							button1.Enabled = true;
							tbMessage.Enabled = true;
							rtbChat.ResetText();

							Dictionary<string, object> data = new Dictionary<string, object>();
							data.Add("username", _username);

							pubnub.SetPresenceState()
							   .Channels(Configuration.CHANNELS)
							   .State(data)
							   .Async(new PNSetStateResultExt(
								   (r, s) =>
								   {
									   Invoke(new Action(() =>
									   {
										   tbOutput.AppendText(pubnub.JsonPluggableLibrary.SerializeToJsonString(r));
									   }));
								   }));

							//Actualize the info
							tHereNow.Start();
							tHereNow_Tick(null, EventArgs.Empty); //call tick
							history();
						}));

					}
					else if (status.Category == PNStatusCategory.PNReconnectedCategory)
					{
						Invoke(new Action(() =>
						{
							// Happens as part of our regular operation. This event happens when
							// radio / connectivity is lost, then regained.
							tbOutput.AppendText("Reconneted");
							lbStatus.Text = "Reconneted!";
							Helpers.Notification(Configuration.NOTIFICATION_TITLE, "Reconnected!", Properties.Resources.info);
							button1.Enabled = true;
							tbMessage.Enabled = true;

							tHereNow.Start();
						}));
					}
					else if (status.Category == PNStatusCategory.PNDecryptionErrorCategory)
					{
						Invoke(new Action(() =>
						{
							// Handle messsage decryption error. Probably client configured to
							// encrypt messages and on live data feed it received plain text.
							tbOutput.AppendText("messsage decryption error");
							lbStatus.Text = "messsage decryption error!";
							Helpers.Notification(Configuration.NOTIFICATION_TITLE, "Messsage decryption error!", Properties.Resources.error);

						}));
					}
				}
			));

			if (String.IsNullOrEmpty(_username))
			{
				Environment.Exit(0);
			}

			subscribe();
		}

		// Exception
		static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
		{
			//Console.WriteLine(e.ExceptionObject.ToString());
			MessageBox.Show("Unhandled exception occured inside Pubnub C# API. Exiting the application. Please try again.");
			Environment.Exit(1);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if(!String.IsNullOrEmpty(tbMessage.Text))
				publish();
		}

		private static void subscribe()
		{
			pubnub.Subscribe<object>()
				.WithPresence()
				.Channels(Configuration.CHANNELS)
				.Execute();

		}
		private void herenow()
		{
			pubnub.HereNow()
			// tailor the next two lines to example
			.Channels(Configuration.CHANNELS)
			.IncludeState(true)
			.IncludeUUIDs(true)
			.Async(new PNHereNowResultEx(
				(result, status) =>
				{
					Invoke(new Action(() =>
					{
						//TODO: mudar para multi channel aqui ta so para um channel!
						int occupancy = result.Channels[Configuration.CHANNELS[0]].Occupancy;

						label1.Text = "Online Users:";
						listBox1.Visible = true;
						listBox1.Items.Clear();

						foreach (var user in result.Channels[Configuration.CHANNELS[0]].Occupants.Distinct())
						{

							if (user.State == null || user.State.ToString() == null)
							{
								occupancy--;
								continue;
							}

							if (occupancy == 0) continue; //ignore if no have users on channel

							var userState = JObject.Parse(pubnub.JsonPluggableLibrary.SerializeToJsonString(user.State));

							//its me ?
							if (userState["username"].ToString() == _username)
								listBox1.Items.Add(userState["username"] + " (You)");
							else
								listBox1.Items.Add(userState["username"]);

						}

						lbAboutChannel.Text = "- Channel: " + result.Channels[Configuration.CHANNELS[0]].ChannelName + Environment.NewLine
											+ "- Online Users: " + (occupancy - 1) + Environment.NewLine;

						if (occupancy == 0 || occupancy == 1)
						{
							label1.Text = "No users online.";
							listBox1.Visible = false;
						}

					}));
				}
		));
		}

		private void publish()
		{

			//Dictionary of usermeta data
			Dictionary<string, object> data = new Dictionary<string, object>();
			data.Add("username", _username);


			//Dictionary of message
			Dictionary<string, object> message = new Dictionary<string, object>();
			message.Add("msg", tbMessage.Text.Trim().ToString());
			message.Add("username", _username);


			pubnub.Publish()
			.Channel(Configuration.CHANNELS[0])
			.Message(message)
			.Meta(data)
			.ShouldStore(true)
			.UsePOST(true)
			.Async(new PNPublishResultExt((publishResult, publishStatus) =>
			{
				Invoke(new Action(() =>
				{
					// Check whether request successfully completed or not.
					if (!publishStatus.Error)
					{

						// Message successfully published to specified channel.
						tbOutput.AppendText(Environment.NewLine);
						tbOutput.AppendText("Message sent successfully!");
						tbMessage.Clear();

						scrollToBottom();
					}
					else
					{
						// Request processing failed.
						// Handle message publish error. Check 'Category' property to find out possible issue
						// because of which request did fail.
						tbOutput.AppendText("Error send Message please try again!");
						Helpers.Notification(Configuration.NOTIFICATION_TITLE, "Error send Message please try again!", Properties.Resources.error);
					}
				}));
			}));
		}
		private void history()
		{
			pubnub.History()
			.Channel(Configuration.CHANNELS[0])
			.Reverse(false)
			.Count(50)
			.IncludeTimetoken(true)
			.Async(new PNHistoryResultExt(
			  (r, s) =>
			  {

				  Invoke(new Action(() =>
				  {
					  if (String.IsNullOrEmpty(r.Messages.ToString().Trim()))
					  {
						  sb.Font(RTFFont.LucidaConsole).FontSize(22)
								.FontStyle(FontStyle.Bold)
								.ForeColor(KnownColor.Red)
								.AppendLine($"No messages.");
					  }

					  //for each on messages
					  foreach (var message in r.Messages)
					  {
						  if (message.Entry == null || message.Entry.ToString() == "") continue;

						  //try parse json
						  try
						  {

							  var jMessage = JObject.Parse(pubnub.JsonPluggableLibrary.SerializeToJsonString(message.Entry));

							  if (jMessage["username"] == null || jMessage["msg"] == null)
							  {
								  continue;
							  }

							  if (String.IsNullOrEmpty(jMessage["username"].ToString()) || String.IsNullOrEmpty(jMessage["msg"].ToString()))
							  {
								  continue;
							  }
							  
							  //rtbChat.AppendText(Environment.NewLine);
							  // if is first element
							  if (r.Messages.First() == message)
							  {
								  sb.Font(RTFFont.LucidaConsole).FontSize(22)
								  .FontStyle(FontStyle.Bold)
								  .ForeColor(KnownColor.Green)
								  .AppendLine($"Started in: { Helpers.TimeTokenToDateTime(message.Timetoken)}");
							  }

							  sb.Font(RTFFont.LucidaConsole).FontSize(22)
							  .FontStyle(FontStyle.Regular)
							  .ForeColor(KnownColor.DarkGray)
							  .Append($"<{Helpers.TimeTokenToDateTime(message.Timetoken)}> ");
							  //rtbChat.Rtf += sb.ToString();

							  if (jMessage["username"].ToString() == _username)
								  sb.Font(RTFFont.LucidaConsole).FontSize(22).ForeColor(KnownColor.DarkSlateGray).Append($"<{jMessage["username"]}>: ");
							  else
								  sb.Font(RTFFont.LucidaConsole).FontSize(22).ForeColor(KnownColor.Black).Append($"<{jMessage["username"]}>: ");

							  sb.Font(RTFFont.LucidaConsole).FontSize(22).ForeColor(KnownColor.Gray)
							  .AppendLine($"{jMessage["msg"]}");

						  }
						  catch (JsonReaderException e)
						  {
							  tbOutput.AppendText(Environment.NewLine);
							  tbOutput.AppendText("JsonReaderException: " + e.Message);
							  //next one
							  continue;
						  }

					  }

					  // Parse emojis
					  rtbChat.Rtf = Emoticon.Parse(sb.ToString(), ref rtbChat);

					  //scrool to bottom
					  scrollToBottom();
				  }));

			  }));
		}

		public static void AppendText(RichTextBox box, string text, Color color, bool AddNewLine = false)
		{
			if (AddNewLine)
			{
				text += Environment.NewLine;
			}

			box.SelectionStart = box.TextLength;
			box.SelectionLength = 0;

			box.SelectionColor = color;
			box.AppendText(text);
			box.SelectionColor = box.ForeColor;
		}

		private void tHereNow_Tick(object sender, EventArgs e)
		{

			herenow();

			//check status of user!
			db.bind("username", _username);
			string result = db.single("SELECT status FROM users WHERE username = @username");

			if (result == null || int.Parse(result) == 0)
			{
				//Close connection
				db.CloseConn();
				pubnub.UnsubscribeAll<object>();
				pubnub.Disconnect<object>();
				pubnub.Destroy();

				MessageBox.Show("A tua Conta encontra-se desativada, por favor, contacte o administrador!", "Conta desativada", MessageBoxButtons.OK, MessageBoxIcon.Warning);

				Login login = new Login();
				setUsername(null);
				this.Close();
				login.Show();
			}

		}

		private void tHours_Tick(object sender, EventArgs e)
		{
			toolStripStatusLabel1.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
		}

		public string getUsername()
		{
			return _username;
		}

		public void setUsername(string user)
		{
			_username = user;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			//Close connection
			pubnub.UnsubscribeAll<object>();
			pubnub.Disconnect<object>();
			pubnub.Destroy();
		}

		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			// your code here
			db.CloseConn();
			pubnub.UnsubscribeAll<object>();
			pubnub.Disconnect<object>();
			pubnub.Destroy();
			Environment.Exit(0);
			base.OnFormClosing(e);
		}

		private void tbMessage_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter && button1.Enabled)
			{
				e.Handled = true;
				button1.PerformClick();
			}
		}

		private void scrollToBottom()
		{
			// scroll it automatically
			rtbChat.SelectionStart = rtbChat.Text.Length;
			rtbChat.ScrollToCaret();
		}

		private void rtbChat_MouseUp(object sender, MouseEventArgs e)
		{
			if (rtbChat.SelectionType == RichTextBoxSelectionTypes.Object)
			{
				rtbChat.SelectionLength = 0;
			}
		}

		private void rtbChat_MouseDown(object sender, MouseEventArgs e)
		{
			if (rtbChat.SelectionType == RichTextBoxSelectionTypes.Object)
			{
				rtbChat.SelectionLength = 0;
			}
		}
	}
}
