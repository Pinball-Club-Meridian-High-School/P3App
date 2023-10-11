// Copyright � 2019 Multimorphic, Inc. All Rights Reserved

using Multimorphic.P3;
using Multimorphic.P3App.Modes;
using Multimorphic.P3App.Modes.Data;

namespace Multimorphic.P3SA.Modes.Data {

	public class P3SAEventProfileMode : EventProfileMode {

		public P3SAEventProfileMode(P3Controller controller, int priority, string eventProfileName, string eventProfileDir)
			: base(controller, priority, eventProfileName, eventProfileDir) {
			highScoresMode = new P3SAHighScoresMode(p3, Priorities.PRIORITY_HIGH_SCORES, eventProfileName, eventProfileDir);
			statisticsMode = new P3SAStatisticsMode(p3, Priority, eventProfileName, eventProfileDir);
		}
	}
}