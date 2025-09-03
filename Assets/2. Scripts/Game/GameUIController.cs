using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [SerializeField] public Button back_btn;
    [SerializeField] public Button setting_btn;

    void Awake()
    {
        this.back_btn.onClick.AddListener(OnBackBtn);
        this.setting_btn.onClick.AddListener(OnSetthingBtn);
    }


    public void OnBackBtn()
    {
        // GameManager.Instance.ChangeToMainScene()
        GameManager.Instance.OpenConfirmPanel("게임을 종료하시겠습니까?" , GameManager.Instance.ChangeToMainScene);        
    }

    public void OnSetthingBtn()
    {
        
    }
}