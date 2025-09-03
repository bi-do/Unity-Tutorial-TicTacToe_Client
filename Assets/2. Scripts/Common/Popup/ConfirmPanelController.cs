using System;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmPanelController : PanelController
{
    [SerializeField] private TextMeshProUGUI msg_UI;
    [SerializeField] private Button confirm_btn;
    [SerializeField] private Button close_btn;

    private Action on_confirm_btn_act;

    protected override void Awake()
    {
        base.Awake();

        this.confirm_btn.onClick.AddListener(OnClickConfirmBtn);
        this.close_btn.onClick.AddListener(OnClickCloseBtn);
    }

    public void Show(string msg, Action on_confirm_btn_callback)
    {
        this.msg_UI.text = msg;
        this.on_confirm_btn_act = on_confirm_btn_callback;
        base.Show();
    }

    /// <summary> 확인 버튼 클릭 시 호출 </summary>
    public void OnClickConfirmBtn()
    {
        Hide(()=>
        {
            this.on_confirm_btn_act?.Invoke();
        });
    }

    /// <summary> 닫기 버튼 클릭 시 호출 </summary>
    public void OnClickCloseBtn()
    {
        Hide(()=>
        {
            this.gameObject.SetActive(false);
        });
    }
}
