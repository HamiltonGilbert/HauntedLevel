using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnClick : MonoBehaviour
{
    private void Start()
    {
        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(BtnNewScene);
    }
    public void BtnNewScene()
    {
        SceneManager.LoadScene("Game");
    }

}