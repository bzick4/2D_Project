
using UnityEngine;
using UnityEngine.UI;

public class UnlockLevel : MonoBehaviour
{
    private int _levelLock;
    [SerializeField] private Button[] _Buttons;

    private void Start()
    {
        UnlockLevels();
    }
    
    void UnlockLevels()
    {
        _levelLock = PlayerPrefs.GetInt("Level", 1);
        for (int i = 0; i < _Buttons.Length; i++)
        {
            _Buttons[i].interactable = false;
        }

        for (int i = 0; i < _levelLock; i++)
        {
            _Buttons[i].interactable = true; 
        }
    }
}
