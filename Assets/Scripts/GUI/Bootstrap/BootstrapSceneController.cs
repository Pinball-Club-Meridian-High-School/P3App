using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Multimorphic.P3SA.GUI {
	public class BootstrapSceneController : P3SASceneController {

		private P3SASetup setup;

        public Text appName;
        public Text appVersion;
        public Text companyName;
        public Text module;
        public Text error;

		// Update is called once per frame
		public override void Update () {
			base.Update ();

			if (setup == null) 
			{
				setup = GameObject.FindObjectOfType<P3SASetup>();
			}
            else
            {
                if (appName != null)
                    appName.text = setup.appName;
                if (companyName != null)
                    companyName.text = setup.companyName;
                if (error != null)
                    error.text = setup.errorText;
                if (appVersion != null)
                    appVersion.text = setup.appVersion;
                if ((module != null) && isConnectedToP3)
                    module.text = "Module:\n" + setup.playfieldModuleId + "\n" + setup.playfieldModuleDriverVersion;
            }
        }
    }
}