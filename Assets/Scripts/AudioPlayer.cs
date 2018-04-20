using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

	bool combatThemeStarter = true;
	public AudioSource audioSource;
	float combatThemeStartTimer = 8.139f;
	public AudioClip combatThemeStart;
	public AudioClip combatThemeMain;

	// Update is called once per frame
	void Update () {
		if (combatThemeStarter == true)
			audioSource.enabled = true;

		if (combatThemeStarter == true) {
			if (combatThemeStartTimer > 0)
				combatThemeStartTimer -= Time.deltaTime;
			else {
				audioSource.clip = combatThemeMain;
				combatThemeStartTimer = 8.139f;
				combatThemeStarter = false;
			}
		}
	}

	void PlayCombatTheme() {
		combatThemeStarter = true;
	}
}
