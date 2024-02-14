using System;
using Multimorphic.P3;
using Multimorphic.P3App.Modes;
using Multimorphic.NetProcMachine.Machine;
using System.Collections.Generic;

namespace MeridianPinballClub.MeridianMash.Modes.Rooms
{
    public class RoomMode : SceneMode
    {
        private readonly HomeMode homeMode;

        public RoomMode(P3Controller controller, string SceneName, HomeMode homeMode)
            : base(controller, MeridianMashPriorities.PRIORITY_SCENE_MODE, SceneName)
        {
            this.homeMode = homeMode;

            // SETUP EVENTS
            // GUI events
            Multimorphic.P3App.Logging.Logger.Log("Listening for event \"" + MeridianMashEventNames.LeaveRoomTriggered + "\"");
            AddGUIEventHandler(MeridianMashEventNames.LeaveRoomTriggered, LeaveRoomTriggered);
        }

        private void LeaveRoomTriggered(string eventName, object eventData)
        {
            homeMode.leaveRoom(this);
        }

        // Code generated when creating a scene using Multimorphic tools
        public override void mode_started()
        {
            base.mode_started();

            // p3.AddMode(someRelatedMode);

            // AddGUIEventHandler ("Evt_SomeGUIEventName", SomeHandlerFunction);
            // AddModeEventHandler ("SomeModeEventName", SomeHandlerFunction, priority);
        }

        public override void mode_stopped()
        {
            // p3.RemoveMode (someRelatedMode);
            // RemoveGUIEventHandler ("Evt_SomeGUIEventName", SomeHandlerFunction);
            // RemoveModeEventHandler ("Evt_SomeModeEventName", SomeHandlerFunction, priority);
            // p3.RemoveMode(someRelatedMode);
            base.mode_stopped();
        }

        public override void LoadPlayerData()
        {
            base.LoadPlayerData();
            // Add any special data loading needed here for this scene and this player
        }

        public override void SavePlayerData()
        {
            base.SavePlayerData();
            // Add any special data loading needed here for this scene and this player
        }

        public override void SceneLiveEventHandler(string evtName, object evtData)
        {
            base.SceneLiveEventHandler(evtName, evtData);
            // Add any special setup that the scene requires here, including sending messages to the GUI.
        }

        protected override void StartPlaying()
        {
            base.StartPlaying();

            PostModeEventToGUI("Evt_TestSetup", 0);

            // PostInstructionEvent("Some instructions");
            MeridianMashBallLauncher.launch();
        }

        protected override void Completed(long score)
        {
            base.Completed(score);
            PostModeEventToModes("Evt_TestCompleted", 0);
        }


        public bool sw_slingL_active(Switch sw)
        {
            // Add code here to let he GUI side know about that a sling has been hit
            //e.g. PostModeEventToGUI("Evt_TestSlingHit", false);

            return SWITCH_CONTINUE;   // use SWITCH_STOP to prevent other modes from receiving this notification.
        }

        public bool sw_slingR_active(Switch sw)
        {
            // Add code here to let he GUI side know about that a sling has been hit
            // e.g. PostModeEventToGUI("Evt_TestSlingHit", false);
            return SWITCH_CONTINUE;   // use SWITCH_STOP to prevent other modes from receiving this notification.
        }

        public override void End()
        {
            // someRelatedMode.End();

            Pause();
            // Save any remaining stats

            base.End();
        }

        public void Pause()
        {
            p3.ModesToGUIEventManager.Post("Evt_ScenePause", null);
        }

        public override ModeSummary getModeSummary()
        {
            ModeSummary modeSummary = new ModeSummary();
            modeSummary.Title = sceneName;
            modeSummary.Completed = modeCompleted;
            if (modeCompleted)
                modeSummary.SetItemAndValue(0, "Test completed!", "");
            else
                modeSummary.SetItemAndValue(1, "Test not yet completed!", "");
            modeSummary.SetItemAndValue(2, "", "");
            return modeSummary;
        }
    }
}
