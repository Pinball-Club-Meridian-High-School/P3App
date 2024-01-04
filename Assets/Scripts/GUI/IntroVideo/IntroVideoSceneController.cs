using UnityEngine;
using System.Collections;
using MeridianPinballClub.MeridianMash.GUI;
using Multimorphic.P3App.GUI;

namespace MeridianPinballClub.MeridianMash.GUI {

	public class IntroVideoSceneController : MeridianMashSceneController {

		public bool useAlternateAudio;
		private AudioSource alternateAudio;
		private GameObject P3PlayfieldObj;
		private GameObject MeridianMashAudioObj;

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

			MeridianMashAudioObj = GameObject.Find ("MeridianMashAudio(Clone)");
			if (MeridianMashAudioObj) {
				MeridianMashAudioObj.SetActive(!useAlternateAudio);
				MeridianMashAudioObj.GetComponent<MeridianMashAudio>().moveWithCamera = false;
			}

			MeridianMashAudio.Instance.ChangePlaylistByName("IntroAnimAudio");
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
            if (MeridianMashAudio.Instance)
                MeridianMashAudio.Instance.StopAllPlaylists();
		}

		protected override void OnDestroy () {
            if (MeridianMashAudio.Instance)
                MeridianMashAudio.Instance.StopAllPlaylists();

			// Reneable objects for normal gameplay
			if (P3PlayfieldObj)
				P3PlayfieldObj.SetActive(true);

			if (MeridianMashAudioObj) {
				MeridianMashAudioObj.SetActive(true);
				MeridianMashAudioObj.GetComponent<MeridianMashAudio>().moveWithCamera = true;
			}

			base.OnDestroy();
		}
	}
}