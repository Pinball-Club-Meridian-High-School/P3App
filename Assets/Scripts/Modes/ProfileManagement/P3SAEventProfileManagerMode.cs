// Copyright � 2019 Multimorphic, Inc. All Rights Reserved

using Multimorphic.P3;
using Multimorphic.P3App.Modes.Data;

namespace MeridianPinballClub.P3SA.Modes.Data {

	public class P3SAEventProfileManagerMode : EventProfileManagerMode {

		public P3SAEventProfileManagerMode(P3Controller controller, int priority)
			: base(controller, priority) {
		}

		protected override void AddEventProfileMode(string eventProfileName) {
			eventProfiles[eventProfileName] = new P3SAEventProfileMode(p3, Priority, eventProfileName, GetEventProfileDirectory(eventProfileName));
		}
	}
}