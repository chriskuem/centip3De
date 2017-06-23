using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour {

	public Slider masterSlider;
	public Slider musicSlider;
	public Slider sfxSlider;
	public AudioSource musicAudio;
	public AudioSource[] sfxSound;

	static float currentTime;
	static float playAtTime;
	static bool isPause=false;

	public void Start()
    {
		masterSlider.value = PlayerPrefs.GetFloat("master_vol");
		musicSlider.value = PlayerPrefs.GetFloat("music_vol");
		sfxSlider.value = PlayerPrefs.GetFloat("sfx_vol");

		AudioListener.volume = masterSlider.normalizedValue;
		musicAudio.volume = musicSlider.normalizedValue;

		foreach (AudioSource audiosource in sfxSound) {
			audiosource.volume = sfxSlider.normalizedValue;
		}

        masterSlider.onValueChanged.AddListener(delegate {MasterValueChangeCheck(); });
        musicSlider.onValueChanged.AddListener(delegate {MusicValueChangeCheck(); });
        sfxSlider.onValueChanged.AddListener(delegate {SFXValueChangeCheck(); });
    }

	public void FixedUpdate(){
		currentTime = Time.time;

		if (isPause) {
			if(musicAudio.isPlaying)musicAudio.Pause ();
			if (currentTime > playAtTime) {
				musicAudio.Play ();
				isPause = !isPause;
			}
		}
	}

    // Invoked when the value of the slider changes.
    public void MasterValueChangeCheck()
    {
		AudioListener.volume = masterSlider.normalizedValue;
		PlayerPrefs.SetFloat("master_vol", masterSlider.normalizedValue);
    }
	public void MusicValueChangeCheck()
    {
		musicAudio.volume = musicSlider.normalizedValue;
		PlayerPrefs.SetFloat("music_vol", musicSlider.normalizedValue);
    }
	public void SFXValueChangeCheck()
    {
		foreach (AudioSource audiosource in sfxSound) {
			audiosource.volume = sfxSlider.normalizedValue;
		}
		PlayerPrefs.SetFloat("sfx_vol", sfxSlider.normalizedValue);
    }

	public static void PauseMusicFor(float seconds){
		playAtTime = currentTime + seconds;
		isPause = true;
	}
}
