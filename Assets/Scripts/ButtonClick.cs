using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Button Button;
    void Start()
    {
        Button = GetComponent<Button>();    
        if (Button != null )
        {
            Button.onClick.AddListener(() => MusicManager.Instance.PlayButtonClick());
        }
    }

 
}
