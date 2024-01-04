// Copyright � 2019 Multimorphic, Inc. All Rights Reserved

using Multimorphic.P3;
using Multimorphic.P3App.Modes.Data;

namespace MeridianPinballClub.MeridianMash.Modes.Data {

	public class MeridianMashEventProfileManagerMode : EventProfileManagerMode {

		public MeridianMashEventProfileManagerMode(P3Controller controller, int priority)
			: base(controller, priority) {
		}

		protected override void AddEventProfileMode(string eventProfileName) {
			eventProfiles[eventProfileName] = new MeridianMashEventProfileMode(p3, Priority, eventProfileName, GetEventProfileDirectory(eventProfileName));
		}
	}
}