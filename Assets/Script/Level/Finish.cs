using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public int levelIndex;
    [SerializeField] private GameObject _WinPanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hero"))
        {
            _WinPanel.SetActive(true);
            PlayerPrefs.SetInt("Level" + levelIndex.ToString(), 1);
        }
    }
}
