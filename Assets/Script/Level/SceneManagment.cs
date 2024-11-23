using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagment : MonoBehaviour
{
    public void Exit()
    {
       SceneManager.LoadScene(0);
    }
    
    public void Load(int level)
    {
       SceneManager.LoadScene(level);
    }
    
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
