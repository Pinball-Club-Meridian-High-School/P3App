using UnityEngine;
using System.Collections;
using MeridianPinballClub.P3SA.GUI;
using Multimorphic.P3App.GUI;

namespace MeridianPinballClub.P3SA.GUI {

	public class IntroVideoSceneController : P3SASceneController {

		public bool useAlternateAudio;
		private AudioSource alternateAudio;
		private GameObject P3PlayfieldObj;
		private GameObject P3SAAudioObj;

		// Use this for initialization
		public override void Start () {
			base.Start ();

			GameObject obj = GameObject.Find ("AlternateAudio");
			if (obj) {
				alternateAudio = obj.GetComponent<AudioSource>();
				alternateAudio.gameObject.SetActive (useAlternateAudio);
			}

			// Turn off playfield so that video runs smoothly
			P3PlayfieldObj = GameObject.Find ("P3Playfield(Clone)");
			if (P3PlayfieldObj)
				P3PlayfieldObj.SetActive(false);

			P3SAAudioObj = GameObject.Find ("P3SAAudio(Clone)");
			if (P3SAAudioObj) {
				P3SAAudioObj.SetActive(!useAlternateAudio);
				P3SAAudioObj.GetComponent<P3SAAudio>().moveWithCamera = false;
			}

			P3SAAudio.Instance.ChangePlaylistByName("IntroAnimAudio");
		}

		protected override void CreateEventHandlers() {
			base.CreateEventHandlers ();
			AddModeEventHandler("Evt_StopIntroVideo", StopVideo);
		}
		
		// Update is called once per frame
		public override void Update () {
			IntroActive = false;
			base.Update ();
		}

		protected override void SceneLive() {
			base.SceneLive();
		}

		private void StopVideo(string eventName, object eventObject) {
            if (P3SAAudio.Instance)
                P3SAAudio.Instance.StopAllPlaylists();
		}

		protected override void OnDestroy () {
            if (P3SAAudio.Instance)
                P3SAAudio.Instance.StopAllPlaylists();

			// Reneable objects for normal gameplay
			if (P3PlayfieldObj)
				P3PlayfieldObj.SetActive(true);

			if (P3SAAudioObj) {
				P3SAAudioObj.SetActive(true);
				P3SAAudioObj.GetComponent<P3SAAudio>().moveWithCamera = true;
			}

			base.OnDestroy();
		}
	}
}