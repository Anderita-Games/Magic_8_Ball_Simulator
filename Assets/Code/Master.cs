using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Master : MonoBehaviour {
	public TextAsset Predictions;
	public GameObject Prediction_Prefab;
	public GameObject Instructions;
	GameObject Clone;
	string Prediction;

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			if (Instructions) {
				DestroyImmediate(Instructions, true);
			}
			Destroy(Clone);
			Clone = Instantiate(Prediction_Prefab, this.gameObject.transform);
			int Text_Length = Predictions.text.Split('\n').Length;
			Debug.Log(Random.Range(0, Text_Length));
			StreamReader SR = new StreamReader(new MemoryStream(Predictions.bytes));
			int Random_Number = Random.Range(0, Text_Length);
			for (int i = 0; i <= Random_Number; i++) {
				Prediction = SR.ReadLine();
			}
			Clone.GetComponent<UnityEngine.UI.Text>().text = Prediction; 
			SR.Close();
		}
	}
}
