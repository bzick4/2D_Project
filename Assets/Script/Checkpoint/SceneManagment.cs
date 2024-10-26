using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagment : MonoBehaviour
{
   
   [SerializeField] private int numberScene;
   
   public void Restart()
   {
      SceneManager.LoadScene(numberScene);
   }
    
   public void NextLevel()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
}
