using UnityEngine;
using UnityEngine.SceneManagement;

public class SublevelManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("StaticObjects", LoadSceneMode.Additive);
            SceneManager.LoadScene("DynamicObjects", LoadSceneMode.Additive);
        }
    }
}
