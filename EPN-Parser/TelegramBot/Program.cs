using System;
using System.Configuration;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot
{
	public class Program
	{
		static ITelegramBotClient _botClient;
		private static readonly ChatId ChatId = "-1001418836364";

		static void Main(string[] args)
		{
			_botClient = new TelegramBotClient(ConfigurationManager.AppSettings.Get("token"));

			var me = _botClient.GetMeAsync().Result;
			Console.WriteLine(
				$"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
			);

			var myMsg = new Message
			{
				Text = "Trying *all the parameters* of `sendMessage` method",
			};
			BotPostPhoto(myMsg);

			_botClient.OnMessage += BotOnMessage;
			_botClient.StartReceiving();
			Thread.Sleep(int.MaxValue);
		}

		static async void BotOnMessage(object sender, MessageEventArgs e)
		{
			if (e.Message.Text != null)
			{
				await _botClient.SendTextMessageAsync(
					chatId: ChatId,
					text: e.Message.Text,
					parseMode: ParseMode.Markdown
				);
			}
		}

		public static async void BotPostMessage(Message message)
		{
			await _botClient.SendTextMessageAsync(
				chatId: ChatId,
				text: message.Text,
				parseMode: ParseMode.Markdown
			);
		}

		public static async void BotPostPhoto(Message message)
		{
			 await _botClient.SendPhotoAsync(
				chatId: ChatId,
				photo: "https://github.com/TelegramBots/book/raw/master/src/docs/photo-ara.jpg",
				caption: message.Text,
				parseMode: ParseMode.Html
			);
		}
	}
}