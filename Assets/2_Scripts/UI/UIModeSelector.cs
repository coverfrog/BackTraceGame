using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class UIModeSelector : MonoBehaviour
{
    [Header("Options")]
    [SerializeField] private string sceneName = "Game";
    
    [Header("References")]
    [SerializeField] private Button buttonSolo;
    [SerializeField] private Button buttonMulti;

    public void Init(Object sender)
    {
        buttonSolo?.onClick.AddListener(OnClickSolo);
        buttonMulti?.onClick.AddListener(OnClickMulti);
    }

    private void OnClickSolo()
    {
        SceneManager.LoadScene(sceneName);
    }
    
    private void OnClickMulti()
    {
       
    }
}
