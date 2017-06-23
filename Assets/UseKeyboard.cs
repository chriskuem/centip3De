using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseKeyboard : MonoBehaviour {

	// Use this for initialization
	public void SwitchUseKeyboard(Toggle toggle) {
		bool useKeyboard = toggle.isOn; 

		if (useKeyboard) PlayerPrefs.SetInt("usekeyboard", 1);
		else PlayerPrefs.SetInt("usekeyboard", 0);
	}
}
