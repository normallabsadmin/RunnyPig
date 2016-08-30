using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour {

    public Sprite _unlockedImage;
    public int _characterIndex;
    public bool _unlocked;
    public int _cost;

    public GameObject _unlocker;

    void Update()
    {
        var spritey = GetComponent<Image>();

        var thisCharacterPrefName = "CharacterUnlocked" + _characterIndex.ToString();

        if(PlayerPrefs.GetInt("HighScore") >= _cost)
        {
            PlayerPrefs.SetInt(thisCharacterPrefName, 1);
        }

        if(PlayerPrefs.GetInt(thisCharacterPrefName) == 1)
        {
            _unlocked = true;
        }

        if (_unlocked)
        {
            spritey.sprite = (_unlockedImage);
        }
    }

    public void ButtonPress()
    {
        if (_unlocked)
        {
            PlayerPrefs.SetInt("ActiveCharacter", _characterIndex);
        }
        else
        {
            _unlocker.SetActive(true);
            _unlocker.GetComponent<CharacterUnlocker>().SetUp(_unlockedImage, _cost, _characterIndex);
        }
    }
}
