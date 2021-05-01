using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MenuController : MonoBehaviour
    {
        public void LoadLevel()
        {
            SceneManager.LoadScene("BoardScene");
        }
        
        public void Exit()
        {
            Application.Quit();
        }
    }
}
