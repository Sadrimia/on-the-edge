using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer _am;
    [SerializeField] private Toggle _audioToggle;
    [SerializeField] private Toggle _vibrationToggle;
    [SerializeField] private Toggle _localizationToggle;
    private float _minVolume = -80f;
    private float _maxVolume = 0f;

    void Awake()
    {
        //_audioToggle.isOn = PlayerPrefs.GetFloat("SoundToggle", 0) == 1 ? true:false;
        _vibrationToggle.isOn = PlayerPrefs.GetFloat("VibrationToggle", 0) == 1 ? true:false;
        _localizationToggle.isOn = PlayerPrefs.GetFloat("LocalizationToggle", 0) == 1 ? true:false;

        if(_localizationToggle.isOn){
            StartCoroutine(SetLocale(1));
        }else{
            StartCoroutine(SetLocale(0));
        }

        if(_vibrationToggle.isOn)
        {
            Vibrator.vibrationIsOff = true;
        }else{
            Vibrator.vibrationIsOff = false;
        }

        _audioToggle.onValueChanged.AddListener(delegate{offOnSounds(_audioToggle);});
        _vibrationToggle.onValueChanged.AddListener(delegate{OffVibration(_vibrationToggle);});
        _localizationToggle.onValueChanged.AddListener(delegate{ChangeLocalization(_localizationToggle);});
    }

    private void offOnSounds(Toggle change){
       if(_audioToggle.isOn){
        _am.SetFloat("Volume", _minVolume);
        //PlayerPrefs.SetFloat("SoundToggle", _audioToggle.isOn == true?1:0);
       }else{
        _am.SetFloat("Volume", _maxVolume);
        //PlayerPrefs.SetFloat("SoundToggle", _audioToggle.isOn  == true?1:0);
       }
    }

    private void OffVibration(Toggle change)
    {
        if(_vibrationToggle.isOn){
            Vibrator.vibrationIsOff = true;
            PlayerPrefs.SetFloat("VibrationToggle", _vibrationToggle.isOn == true?1:0);
        }else{
            Vibrator.vibrationIsOff = false;
            PlayerPrefs.SetFloat("VibrationToggle", _vibrationToggle.isOn == true?1:0);
        }
    }

    private void ChangeLocalization(Toggle change)
    {
        if(!_localizationToggle.isOn){
            StartCoroutine(SetLocale(0));
            PlayerPrefs.SetFloat("LocalizationToggle", _localizationToggle.isOn == true?1:0);
        }
        if(_localizationToggle.isOn){
            StartCoroutine(SetLocale(1));
            PlayerPrefs.SetFloat("LocalizationToggle", _localizationToggle.isOn == true?1:0);
        }
    }

    IEnumerator SetLocale(int _localeID){
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
    }
}