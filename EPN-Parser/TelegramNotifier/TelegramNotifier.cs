using System;
using System.ServiceProcess;
using System.Threading;
using TelegramBotNotifier.Bots;
using TelegramBotNotifier.Interfaces;

namespace TelegramNotifier
{
	public partial class TelegramNotifier : ServiceBase
	{
		private CancellationTokenSource _cancellationTokenSource;
		private ITelegramBot _telegramBot;

		public TelegramNotifier()
		{
			InitializeComponent();
			CanStop = true;
			CanPauseAndContinue = true;
			AutoLog = true;
		}

		protected override void OnStart(string[] args)
		{
			_cancellationTokenSource = new CancellationTokenSource();
			_telegramBot = new TelegramBot();

			_telegramBot.Run();

			while (!_cancellationTokenSource.IsCancellationRequested)
			{
			}
		}

		protected override void OnStop()
		{
			_cancellationTokenSource.Cancel();
		}
	}
}
