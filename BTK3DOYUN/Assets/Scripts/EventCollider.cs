using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EventCollider : MonoBehaviour
{
    // Start is called before the first frame update
   public void ReplayGame()
    {
        SceneManager.LoadScene("Level");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
