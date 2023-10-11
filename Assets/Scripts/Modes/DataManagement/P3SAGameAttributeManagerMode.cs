using Multimorphic.NetProcMachine.Machine;
using Multimorphic.P3;
using Multimorphic.P3App.Modes;
using Multimorphic.P3App.Modes.Data;
using Multimorphic.P3SA.Modes.Data;
using System;
using System.Collections.Generic;

namespace Multimorphic.P3SA.Modes.Data
{
    public class P3SAGameAttributeManagerMode : GameAttributeManagerMode
	{
		List<HighScoreCategory> highScoreCats;
		public P3SAGameAttributeManagerMode (P3Controller controller, int priority)
			: base(controller, priority)
		{
		}

		protected override void InstantiateAndAddModes()
		{
			base.InstantiateAndAddModes();

			settingsMode = new P3SASettingsMode (p3, Priority);
			// Use PRIORITY_HIGH_SCORES mode for the high score logic so the score boards work properly in Attract Mode.
			highScoresMode = new P3SAHighScoresMode (p3, Priorities.PRIORITY_HIGH_SCORES);
			statisticsMode = new P3SAStatisticsMode (p3, Priority);

			eventProfileManagerMode = new P3SAEventProfileManagerMode(p3, Priority+1);
		}

		public override void mode_started ()
		{
			base.mode_started ();
			highScoreCats = P3SAHighScoreCategories.GetCategories();
			SendHSCatsToHSModes();
		}


		private void SendHSCatsToHSModes()
		{
			foreach (HighScoreCategory cat in highScoreCats)
			{
				PostModeEventToModes ("Evt_AddHighScoreCategory", cat);
			}
		}

		protected override bool NewEventProfileAddedEventHandler (string evtName, object evtData)
		{
			SendHSCatsToHSModes();
			return base.NewEventProfileAddedEventHandler (evtName, evtData);
		}

		protected override void CreateStockProfiles()
		{
			base.CreateStockProfiles();
            /*
			profileManagerMode.AddStockProfile ("Default");
			profileManagerMode.AddStockProfile ("Easy");
			profileManagerMode.AddStockProfile ("Medium");
			profileManagerMode.AddStockProfile ("Hard");
			profileManagerMode.AddStockProfile ("Custom");
            */

            /*
			settingsMode.UpdateStockProfileAttributes ("Default");
			settingsMode.UpdateStockProfileAttributes ("Easy");
			settingsMode.UpdateStockProfileAttributes ("Medium");
			settingsMode.UpdateStockProfileAttributes ("Hard");
			settingsMode.UpdateStockProfileAttributes ("Custom");
            */
		}

	} 

}

