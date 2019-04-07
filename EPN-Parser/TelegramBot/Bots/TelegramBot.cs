using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotNotifier.Interfaces;

namespace TelegramBotNotifier.Bots
{
	public class TelegramBot : ITelegramBot
	{
		static ITelegramBotClient _botClient;
		private static readonly ChatId ChatId = "-1001418836364";

		public TelegramBot()
		{
			_botClient = new TelegramBotClient(ConfigurationManager.AppSettings.Get("token"));

			_botClient.OnMessage += BotOnMessage;
		}

		public void Run()
		{
			_botClient.StartReceiving();
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
	}
}
