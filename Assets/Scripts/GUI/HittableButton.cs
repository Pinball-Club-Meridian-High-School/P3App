using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Multimorphic.P3App.GUI;

using MeridianPinballClub.MeridianMash.Modes;

namespace MeridianPinballClub.MeridianMash.GUI.Home
{
    public class HittableButton : P3Aware
    {
        public string eventName;

        // Use this for initialization
        void Start()
        {
            base.Start();
            Multimorphic.P3App.Logging.Logger.Log("Initialzied button with event \"" + eventName + "\"");
        }

        public void OnTriggerEnter(Collider other)
        {
            Multimorphic.P3App.Logging.Logger.Log("Button \"" + eventName + "\" hit");
            if (HitByBall(other))
            {
                Multimorphic.P3App.Logging.Logger.Log("Button hit by ball, posting event to Modes");
                PostGUIEventToModes(eventName, null);
            }
        }
    }
}