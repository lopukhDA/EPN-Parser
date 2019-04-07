using System.ComponentModel;
using System.ServiceProcess;

namespace TelegramNotifier
{
	[RunInstaller(true)]
	public partial class MyServiceInstaller : System.Configuration.Install.Installer
	{
		private ServiceInstaller serviceInstaller;
		private ServiceProcessInstaller processInstaller;

		public MyServiceInstaller()
		{
			InitializeComponent();

			serviceInstaller = new ServiceInstaller
			{
				StartType = ServiceStartMode.Manual,
				ServiceName = "TelegramNotifier"
			};

			processInstaller = new ServiceProcessInstaller {Account = ServiceAccount.LocalSystem};

			Installers.Add(processInstaller);
			Installers.Add(serviceInstaller);
		}
	}
}
