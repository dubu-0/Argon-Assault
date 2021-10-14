using UnityEngine;
using UnityEngine.SceneManagement;

namespace Global
{
    public class GameSession : MonoBehaviour
    {
        public void RestartCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
