using UnityEngine;
using System.Collections;
using System;
using Multimorphic.P3App.GUI;
using MeridianPinballClub.P3SA.Modes;

namespace MeridianPinballClub.P3SA.GUI
{
	public class P3SASetup : Setup {

		public override void Awake() {
			baseAppModeType = typeof(P3SABaseGameMode);
			base.Awake();

            if (Application.isEditor)   // Only filter the log in the Unity editor
            {
                // Filter the log here.  For performance reasons, don't overdo it.
                // P3App.Logging.Logger.IncludeOnlyMessagesContaining.Add("InterestingFoo");
                // P3App.Logging.Logger.IncludeOnlyMessagesContaining.Add("InterestingBar");
                // P3App.Logging.Logger.ExcludeMessagesContaining.Add("AnnoyingThing");
                // P3App.Logging.Logger.ExcludeMessagesContaining.Add("AnotherAnnoyingThing");
            }
        }

        // Use this for initialization
        public override void Start () {
			base.Start();

			if (GameObject.FindObjectOfType<P3SAAudio>() == null ) {
				GameObject mainCamera = GameObject.Find ("Main Camera");
				UnityEngine.Object resource = Resources.Load<GameObject>("Prefabs/P3SAAudio");
				GameObject audio = (GameObject) GameObject.Instantiate(resource, mainCamera.transform.position, mainCamera.transform.localRotation);
				GameObject.DontDestroyOnLoad(audio);
			}
		}
	}
}
