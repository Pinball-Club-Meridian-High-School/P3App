// Copyright � 2019 Multimorphic, Inc. All Rights Reserved

using Multimorphic.P3;
using Multimorphic.P3App.Modes;
using Multimorphic.P3App.Modes.Data;

namespace MeridianPinballClub.MeridianMash.Modes.Data {

	public class MeridianMashEventProfileMode : EventProfileMode {

		public MeridianMashEventProfileMode(P3Controller controller, int priority, string eventProfileName, string eventProfileDir)
			: base(controller, priority, eventProfileName, eventProfileDir) {
			highScoresMode = new MeridianMashHighScoresMode(p3, Priorities.PRIORITY_HIGH_SCORES, eventProfileName, eventProfileDir);
			statisticsMode = new MeridianMashStatisticsMode(p3, Priority, eventProfileName, eventProfileDir);
		}
	}
}