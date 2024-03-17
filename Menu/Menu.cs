using System;
using System.Linq;
using easyInputs;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Maximility.Menu
{
	// Token: 0x02000007 RID: 7
	public class Menu
	{
		// Token: 0x06000009 RID: 9 RVA: 0x00002198 File Offset: 0x00000398
		public static void LoadOnce()
		{
			Menu.MainCamera = GameObject.Find("Main Camera");
			Menu.HUDObj = new GameObject();
			Menu.HUDObj2 = new GameObject();
			Menu.HUDObj2.name = "CLIENT_HUB";
			Menu.HUDObj.name = "CLIENT_HUB";
			Menu.HUDObj.AddComponent<Canvas>();
			Menu.HUDObj.AddComponent<CanvasScaler>();
			Menu.HUDObj.AddComponent<GraphicRaycaster>();
			Menu.HUDObj.GetComponent<Canvas>().enabled = true;
			Menu.HUDObj.GetComponent<Canvas>().renderMode = 2;
			Menu.HUDObj.GetComponent<Canvas>().worldCamera = Menu.MainCamera.GetComponent<Camera>();
			Menu.HUDObj.GetComponent<RectTransform>().sizeDelta = new Vector2(5f, 5f);
			Menu.HUDObj.GetComponent<RectTransform>().position = new Vector3(Menu.MainCamera.transform.position.x, Menu.MainCamera.transform.position.y, Menu.MainCamera.transform.position.z);
			Menu.HUDObj2.transform.position = new Vector3(Menu.MainCamera.transform.position.x, Menu.MainCamera.transform.position.y, Menu.MainCamera.transform.position.z - 4.6f);
			Menu.HUDObj.transform.parent = Menu.HUDObj2.transform;
			Menu.HUDObj.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 1.6f);
			Vector3 eulerAngles = Menu.HUDObj.GetComponent<RectTransform>().rotation.eulerAngles;
			eulerAngles.y = -270f;
			Menu.HUDObj.transform.localScale = new Vector3(1f, 1f, 1f);
			Menu.HUDObj.GetComponent<RectTransform>().rotation = Quaternion.Euler(eulerAngles);
			Menu.Testtext = new GameObject
			{
				transform = 
				{
					parent = Menu.HUDObj.transform
				}
			}.AddComponent<Text>();
			Menu.Testtext.text = "";
			Menu.Testtext.fontSize = 11;
			Menu.Testtext.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
			Menu.Testtext.rectTransform.sizeDelta = new Vector2(260f, 160f);
			Menu.Testtext.rectTransform.localScale = new Vector3(0.01f, 0.01f, 1f);
			Menu.Testtext.rectTransform.localPosition = new Vector3(-1.5f, 1f, 2f);
			Menu.Testtext.material = Menu.AlertText;
			Menu.NotifiText = Menu.Testtext;
			Menu.Testtext.alignment = 0;
			Menu.HUDObj2.transform.transform.position = new Vector3(Menu.MainCamera.transform.position.x, Menu.MainCamera.transform.position.y, Menu.MainCamera.transform.position.z);
			Menu.HUDObj2.transform.rotation = Menu.MainCamera.transform.rotation;
			Menu.MainMenu = new MenuOption[1];
			Menu.MainMenu[0] = new MenuOption
			{
				DisplayName = "Movement",
				_type = "submenu",
				AssociatedString = "Movement"
			};
			Menu.Movement = new MenuOption[9];
			Menu.Movement[0] = new MenuOption
			{
				DisplayName = "IronMonke(G)",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.Movement[1] = new MenuOption
			{
				DisplayName = "TFly",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.Movement[2] = new MenuOption
			{
				DisplayName = "GhostLongArms",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.Movement[3] = new MenuOption
			{
				DisplayName = "CompLongArms",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.Movement[4] = new MenuOption
			{
				DisplayName = "KillGun",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.Movement[5] = new MenuOption
			{
				DisplayName = "TargetSpam",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.Movement[6] = new MenuOption
			{
				DisplayName = "CUBESpam",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.Movement[7] = new MenuOption
			{
				DisplayName = "gorillafireball",
				_type = "toggle",
				AssociatedBool = false
			};
			Menu.Movement[8] = new MenuOption
			{
				DisplayName = "Back",
				_type = "submenu",
				AssociatedString = "Main"
			};
			Menu.MenuState = "Main";
			Menu.CurrentViewingMenu = Menu.MainMenu;
			Menu.UpdateMenuState(new MenuOption(), null, null);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000026DC File Offset: 0x000008DC
		public static void Load()
		{
			Plugin.ExcelFly = Menu.Movement[0].AssociatedBool;
			Plugin.TFly = Menu.Movement[1].AssociatedBool;
			Plugin.ghostlong = Menu.Movement[2].AssociatedBool;
			Plugin.Complong = Menu.Movement[3].AssociatedBool;
			Plugin.Kill = Menu.Movement[4].AssociatedBool;
			Plugin.Target = Menu.Movement[5].AssociatedBool;
			Plugin.Stick = Menu.Movement[6].AssociatedBool;
			Plugin.Highttechslingshot = Menu.Movement[7].AssociatedBool;
			bool flag = EasyInputs.GetThumbStickButtonDown(EasyHand.LeftHand) && EasyInputs.GetThumbStickButtonDown(EasyHand.RightHand) && !Menu.menutogglecooldown;
			if (flag)
			{
				Menu.menutogglecooldown = true;
				Menu.HUDObj2.SetActive(!Menu.HUDObj2.activeSelf);
				Menu.GUIToggled = !Menu.GUIToggled;
			}
			bool flag2 = !EasyInputs.GetThumbStickButtonDown(EasyHand.LeftHand) && !EasyInputs.GetThumbStickButtonDown(EasyHand.RightHand) && Menu.menutogglecooldown;
			if (flag2)
			{
				Menu.menutogglecooldown = false;
			}
			bool guitoggled = Menu.GUIToggled;
			if (guitoggled)
			{
				Menu.HUDObj2.transform.position = new Vector3(Menu.MainCamera.transform.position.x, Menu.MainCamera.transform.position.y, Menu.MainCamera.transform.position.z);
				Menu.HUDObj2.transform.rotation = Menu.MainCamera.transform.rotation;
				bool thumbStickButtonDown = EasyInputs.GetThumbStickButtonDown(EasyHand.LeftHand);
				if (thumbStickButtonDown)
				{
					bool flag3 = EasyInputs.GetTriggerButtonDown(EasyHand.RightHand) && !Menu.inputcooldown;
					if (flag3)
					{
						Menu.inputcooldown = true;
						bool flag4 = Menu.SelectedOptionIndex + 1 == Menu.CurrentViewingMenu.Count<MenuOption>();
						if (flag4)
						{
							Menu.SelectedOptionIndex = 0;
						}
						else
						{
							Menu.SelectedOptionIndex++;
						}
						Menu.UpdateMenuState(new MenuOption(), null, null);
					}
					bool flag5 = EasyInputs.GetGripButtonDown(EasyHand.RightHand) && !Menu.inputcooldown;
					if (flag5)
					{
						Menu.inputcooldown = true;
						Menu.UpdateMenuState(Menu.CurrentViewingMenu[Menu.SelectedOptionIndex], null, "optionhit");
					}
					bool flag6 = !EasyInputs.GetTriggerButtonDown(EasyHand.RightHand) && !EasyInputs.GetGripButtonDown(EasyHand.RightHand) && Menu.inputcooldown;
					if (flag6)
					{
						Menu.inputcooldown = false;
					}
				}
			}
			string text = string.Concat(new string[]
			{
				"<color=",
				MenuSettings.MenuColor + ">",
				MenuSettings.MenuName + " : ",
				Menu.MenuState,
				"</color>\n"
			});
			int num = 0;
			bool flag7 = Menu.CurrentViewingMenu != null;
			if (flag7)
			{
				foreach (MenuOption menuOption in Menu.CurrentViewingMenu)
				{
					bool flag8 = Menu.SelectedOptionIndex == num;
					if (flag8)
					{
						text = text + "<color=" + MenuSettings.PointerColor + ">></color>";
					}
					text += menuOption.DisplayName;
					bool flag9 = menuOption._type == "toggle";
					if (flag9)
					{
						bool associatedBool = menuOption.AssociatedBool;
						if (associatedBool)
						{
							text = text + " <color=" + MenuSettings.OnColor + ">>[ON]</color>";
						}
						else
						{
							text = text + " <color=" + MenuSettings.OffColor + ">[OFF]</color>";
						}
					}
					text += "\n";
					num++;
				}
				Menu.Testtext.text = text;
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002A60 File Offset: 0x00000C60
		private static void UpdateMenuState(MenuOption option, string _MenuState, string OperationType)
		{
			try
			{
				bool flag = OperationType == "optionhit";
				if (flag)
				{
					bool flag2 = option._type == "submenu";
					if (flag2)
					{
						bool flag3 = option.AssociatedString == "Movement";
						if (flag3)
						{
							Menu.CurrentViewingMenu = Menu.Movement;
						}
						bool flag4 = option.AssociatedString == "Main";
						if (flag4)
						{
							Menu.CurrentViewingMenu = Menu.MainMenu;
						}
						Menu.MenuState = option.AssociatedString;
						Menu.SelectedOptionIndex = 0;
					}
					bool flag5 = option._type == "toggle";
					if (flag5)
					{
						bool flag6 = !option.AssociatedBool;
						if (flag6)
						{
							option.AssociatedBool = true;
						}
						else
						{
							option.AssociatedBool = false;
						}
					}
					bool flag7 = option._type == "button" && option.AssociatedString == "ExampleButton";
					if (flag7)
					{
						PhotonNetwork.Disconnect();
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x04000014 RID: 20
		public static bool GUIToggled = true;

		// Token: 0x04000015 RID: 21
		private static GameObject HUDObj;

		// Token: 0x04000016 RID: 22
		private static GameObject HUDObj2;

		// Token: 0x04000017 RID: 23
		private static GameObject MainCamera;

		// Token: 0x04000018 RID: 24
		private static Text Testtext;

		// Token: 0x04000019 RID: 25
		private static Material AlertText = new Material(Shader.Find("GUI/Text Shader"));

		// Token: 0x0400001A RID: 26
		private static Text NotifiText;

		// Token: 0x0400001B RID: 27
		public static string MenuState = "Main";

		// Token: 0x0400001C RID: 28
		public static int SelectedOptionIndex = 0;

		// Token: 0x0400001D RID: 29
		public static MenuOption[] CurrentViewingMenu = null;

		// Token: 0x0400001E RID: 30
		public static bool inputcooldown = false;

		// Token: 0x0400001F RID: 31
		public static bool menutogglecooldown = false;

		// Token: 0x04000020 RID: 32
		public static MenuOption[] MainMenu;

		// Token: 0x04000021 RID: 33
		public static MenuOption[] Movement;
	}
}
