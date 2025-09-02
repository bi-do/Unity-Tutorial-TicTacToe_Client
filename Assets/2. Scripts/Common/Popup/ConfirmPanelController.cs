using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmPanelController : PanelController
{
    [SerializeField] private TextMeshProUGUI msg_UI;
    [SerializeField] private Button confirm_btn;
    [SerializeField] private Button close_btn;

    protected override void Awake()
    {
        base.Awake();
        
        this.confirm_btn.onClick.AddListener(OnClickConfirmBtn);
        this.close_btn.onClick.AddListener(OnClickCloseBtn);
    }


    public void Show(string msg)
    {
        this.msg_UI.text = msg;
        base.Show();
    }

    /// <summary> 확인 버튼 클릭 시 호출 </summary>
    public void OnClickConfirmBtn()
    {
        Hide();
        GameManager.Instance.ChangeToMainScene();
        Destroy(this.gameObject);
    }

    /// <summary> 닫기 버튼 클릭 시 호출 </summary>
    public void OnClickCloseBtn()
    {
        Hide();
    }
}
