using System;
using easyInputs;
using GorillaLocomotion;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Maximility.Menu.Mods.Movement
{
	// Token: 0x02000008 RID: 8
	public class FlyMods
	{
		// Token: 0x0600000E RID: 14 RVA: 0x00002BB0 File Offset: 0x00000DB0
		public static void ExcelFly()
		{
			bool gripButtonDown = EasyInputs.GetGripButtonDown(EasyHand.RightHand);
			if (gripButtonDown)
			{
				Player.Instance.bodyCollider.attachedRigidbody.velocity += Player.Instance.rightHandTransform.right / 2f;
			}
			bool gripButtonDown2 = EasyInputs.GetGripButtonDown(EasyHand.LeftHand);
			if (gripButtonDown2)
			{
				Player.Instance.bodyCollider.attachedRigidbody.velocity += -Player.Instance.leftHandTransform.right / 2f;
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002C50 File Offset: 0x00000E50
		public static void TFly()
		{
			bool triggerButtonDown = EasyInputs.GetTriggerButtonDown(EasyHand.LeftHand);
			if (triggerButtonDown)
			{
				Player.Instance.transform.position += Player.Instance.leftHandTransform.transform.forward * 0.3f;
				Player.Instance.bodyCollider.attachedRigidbody.velocity = Vector3.zero;
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002CC0 File Offset: 0x00000EC0
		public static void GhostLongArms()
		{
			bool gripButtonDown = EasyInputs.GetGripButtonDown(EasyHand.LeftHand);
			bool flag = gripButtonDown;
			if (flag)
			{
				Player.Instance.rightHandOffset = new Vector3(0f, 0f, 1f);
				Player.Instance.leftHandOffset = new Vector3(0f, 0f, 1f);
			}
			else
			{
				Player.Instance.rightHandOffset = new Vector3(0f, 0f, 0f);
				Player.Instance.leftHandOffset = new Vector3(0f, 0f, 0f);
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002D5C File Offset: 0x00000F5C
		public static void CompLongArms()
		{
			bool gripButtonDown = EasyInputs.GetGripButtonDown(EasyHand.LeftHand);
			bool flag = gripButtonDown;
			if (flag)
			{
				Player.Instance.rightHandOffset = new Vector3(0f, 0f, 0.25f);
				Player.Instance.leftHandOffset = new Vector3(0f, 0f, 0.25f);
			}
			else
			{
				Player.Instance.rightHandOffset = new Vector3(0f, 0f, 0f);
				Player.Instance.leftHandOffset = new Vector3(0f, 0f, 0f);
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002DF8 File Offset: 0x00000FF8
		public static void Kill()
		{
			bool flag = !EasyInputs.GetGripButtonDown(EasyHand.RightHand);
			if (flag)
			{
				Object.Destroy(FlyMods.pointerReach);
			}
			else
			{
				RaycastHit raycastHit;
				bool flag2 = Physics.Raycast(Player.Instance.rightHandTransform.transform.position - Player.Instance.rightHandTransform.transform.up, -Player.Instance.rightHandTransform.transform.up, ref raycastHit) && FlyMods.pointerReach == null;
				bool flag3 = flag2;
				if (flag3)
				{
					FlyMods.pointerReach = GameObject.CreatePrimitive(0);
					Object.Destroy(FlyMods.pointerReach.GetComponent<Rigidbody>());
					Object.Destroy(FlyMods.pointerReach.GetComponent<SphereCollider>());
					FlyMods.pointerReach.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				}
				FlyMods.pointerReach.transform.position = raycastHit.point;
				Player owner = raycastHit.collider.GetComponentInParent<PhotonView>().Owner;
				bool triggerButtonDown = EasyInputs.GetTriggerButtonDown(EasyHand.RightHand);
				if (triggerButtonDown)
				{
					PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
					FlyMods.pointerReach.GetComponent<Renderer>().material.color = Color.red;
					PhotonNetwork.DestroyPlayerObjects(raycastHit.collider.GetComponentInParent<PhotonView>().Owner);
				}
				bool flag4 = !EasyInputs.GetTriggerButtonDown(EasyHand.RightHand);
				if (flag4)
				{
					FlyMods.pointerReach.GetComponent<Renderer>().material.color = Color.white;
				}
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002F7C File Offset: 0x0000117C
		public static void Lagall()
		{
			bool gripButtonDown = EasyInputs.GetGripButtonDown(EasyHand.RightHand);
			if (gripButtonDown)
			{
				bool isConnected = PhotonNetwork.IsConnected;
				if (isConnected)
				{
					foreach (Player player in PhotonNetwork.PlayerListOthers)
					{
						PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
						PhotonNetwork.DestroyPlayerObjects(player);
					}
				}
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002FF0 File Offset: 0x000011F0
		public static void DrawSticky()
		{
			bool gripButtonDown = EasyInputs.GetGripButtonDown(EasyHand.RightHand);
			if (gripButtonDown)
			{
				Vector3 position = Player.Instance.rightHandTransform.transform.position;
				Quaternion rotation = Player.Instance.rightHandTransform.transform.rotation;
				PhotonNetwork.Instantiate("STICKABLE TARGET", position, rotation, 0, null).transform.localScale = new Vector3(1f, 1f, 1f);
			}
			bool gripButtonDown2 = EasyInputs.GetGripButtonDown(EasyHand.LeftHand);
			if (gripButtonDown2)
			{
				Vector3 position2 = Player.Instance.leftHandTransform.transform.position;
				Quaternion rotation2 = Player.Instance.leftHandTransform.transform.rotation;
				PhotonNetwork.Instantiate("STICKABLE TARGET", position2, rotation2, 0, null).transform.localScale = new Vector3(1f, 1f, 1f);
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000030C8 File Offset: 0x000012C8
		public static void DrawStick()
		{
			bool gripButtonDown = EasyInputs.GetGripButtonDown(EasyHand.LeftHand);
			if (gripButtonDown)
			{
				Vector3 position = Player.Instance.leftHandTransform.transform.position;
				Quaternion rotation = Player.Instance.leftHandTransform.transform.rotation;
				PhotonNetwork.Instantiate("bulletPrefab", position, rotation, 0, null);
			}
			bool gripButtonDown2 = EasyInputs.GetGripButtonDown(EasyHand.RightHand);
			if (gripButtonDown2)
			{
				Vector3 position2 = Player.Instance.rightHandTransform.transform.position;
				Quaternion rotation2 = Player.Instance.rightHandTransform.transform.rotation;
				PhotonNetwork.Instantiate("bulletPrefab", position2, rotation2, 0, null);
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00003164 File Offset: 0x00001364
		public static void DrawSlingShot()
		{
			bool gripButtonDown = EasyInputs.GetGripButtonDown(EasyHand.LeftHand);
			if (gripButtonDown)
			{
				Vector3 position = Player.Instance.leftHandTransform.transform.position;
				Quaternion rotation = Player.Instance.leftHandTransform.transform.rotation;
				PhotonNetwork.Instantiate("gorillafireball", position, rotation, 0, null);
			}
			bool gripButtonDown2 = EasyInputs.GetGripButtonDown(EasyHand.RightHand);
			if (gripButtonDown2)
			{
				Vector3 position2 = Player.Instance.rightHandTransform.transform.position;
				Quaternion rotation2 = Player.Instance.rightHandTransform.transform.rotation;
				PhotonNetwork.Instantiate("gorillafireball", position2, rotation2, 0, null);
			}
		}

		// Token: 0x04000022 RID: 34
		public static GameObject pointerReach;
	}
}
