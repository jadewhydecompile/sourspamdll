using System;
using Maximility.Menu;
using MelonLoader;
using Photon.Pun;

namespace Maximility
{
	// Token: 0x02000004 RID: 4
	public class Plugin : MelonMod
	{
		// Token: 0x06000004 RID: 4 RVA: 0x0000210C File Offset: 0x0000030C
		public override void OnUpdate()
		{
			bool flag = !this.menuInitialized;
			if (flag)
			{
				Menu.LoadOnce();
				this.menuInitialized = true;
			}
			Menu.Load();
			new ModManager().Mods();
			bool flag2 = !PhotonNetwork.IsConnected;
			if (flag2)
			{
				PhotonNetwork.ConnectUsingSettings();
			}
		}

		// Token: 0x04000001 RID: 1
		public bool menuInitialized;

		// Token: 0x04000002 RID: 2
		public static bool ExcelFly;

		// Token: 0x04000003 RID: 3
		public static bool TFly;

		// Token: 0x04000004 RID: 4
		public static bool Complong;

		// Token: 0x04000005 RID: 5
		public static bool ghostlong;

		// Token: 0x04000006 RID: 6
		public static bool Kill;

		// Token: 0x04000007 RID: 7
		public static bool Target;

		// Token: 0x04000008 RID: 8
		public static bool Stick;

		// Token: 0x04000009 RID: 9
		public static bool Highttechslingshot;

		// Token: 0x0400000A RID: 10
		public static bool Stickpls;
	}
}
