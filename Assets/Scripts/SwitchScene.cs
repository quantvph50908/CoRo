using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public string NameScene;
    private void Start()
    {
        SceneManager.LoadScene(NameScene);
    }
}
