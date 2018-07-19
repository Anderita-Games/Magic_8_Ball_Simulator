using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {
	float Delay = 2.2f;

	void Start () {
		StartCoroutine(Fader(this.gameObject.GetComponent<UnityEngine.UI.Text>(), Delay * 1));
	}

	IEnumerator Fader (UnityEngine.UI.Text Text, float Type) { //If type is positive then fade in. Vice versa is vice versa.
		for (int i = 255; i > 0; i += Mathf.RoundToInt(Type)) {
			Text.color = new Color(Text.color.r, Text.color.g, Text.color.b, Text.color.a + Type/255);
			yield return new WaitForSecondsRealtime(.01f);
		}
		Text.color = new Color(Text.color.r, Text.color.g, Text.color.b, Type/Delay);
		yield return null;
	}
}
