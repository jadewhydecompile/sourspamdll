using System;
using Maximility.Menu.Mods.Movement;
using MelonLoader;

namespace Maximility
{
	// Token: 0x02000003 RID: 3
	public class ModManager : MelonMod
	{
		// Token: 0x06000002 RID: 2 RVA: 0x00002064 File Offset: 0x00000264
		public void Mods()
		{
			bool excelFly = Plugin.ExcelFly;
			if (excelFly)
			{
				FlyMods.ExcelFly();
			}
			bool tfly = Plugin.TFly;
			if (tfly)
			{
				FlyMods.TFly();
			}
			bool ghostlong = Plugin.ghostlong;
			if (ghostlong)
			{
				FlyMods.GhostLongArms();
			}
			bool complong = Plugin.Complong;
			if (complong)
			{
				FlyMods.CompLongArms();
			}
			bool kill = Plugin.Kill;
			if (kill)
			{
				FlyMods.Kill();
			}
			bool target = Plugin.Target;
			if (target)
			{
				FlyMods.DrawSticky();
			}
			bool stick = Plugin.Stick;
			if (stick)
			{
				FlyMods.DrawStick();
			}
			bool highttechslingshot = Plugin.Highttechslingshot;
			if (highttechslingshot)
			{
				FlyMods.DrawSlingShot();
			}
		}
	}
}
