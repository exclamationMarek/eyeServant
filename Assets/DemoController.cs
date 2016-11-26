using UnityEngine;
using System.Collections;


public class DemoController : MonoBehaviour {

	public enum demoSteps{calibration, pickup, place, audience};
	public static demoSteps step;

	private static float timeout;

	public static void setStep(demoSteps targetStep){
		step = targetStep;
		timeout = Time.time;
	}

	public static void AdvanceDemo(){

		if (Time.time < timeout + 2f) {
			return;
		}
		timeout = Time.time;
		ArduinoSend.WriteToArduino ("n");

		switch (step) {
		case demoSteps.calibration:
			step = demoSteps.pickup;
			break;
		case demoSteps.pickup:
			step = demoSteps.place;
			break;
		case demoSteps.place:
			step = demoSteps.audience;
			break;
		case demoSteps.audience:
			step = demoSteps.pickup;
			break;
		}

	}

}
