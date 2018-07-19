using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Master : MonoBehaviour {
	public TextAsset Predictions;
	public GameObject Prediction;
	public GameObject Instructions;
	GameObject Clone;

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			if (Instructions) {
				DestroyImmediate(Instructions, true);
			}
			Destroy(Clone);
			Clone = Instantiate(Prediction, this.gameObject.transform);
			int Text_Length = Predictions.text.Split('\n').Length;
			StreamReader SR = new StreamReader(new MemoryStream(Predictions.bytes));
			for (int i = 0; i <= UnityEngine.Random.Range(0, Text_Length); i++) {
				Prediction.GetComponent<UnityEngine.UI.Text>().text = SR.ReadLine();
			}
			SR.Close();
		}
	}
}
