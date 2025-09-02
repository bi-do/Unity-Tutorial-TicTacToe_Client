using UnityEngine;
using UnityEngine.UI;

public class MainPanelController : MonoBehaviour
{

    [SerializeField] private Button single_btn;
    [SerializeField] private Button dual_btn;
    [SerializeField] private Button multi_btn;
    [SerializeField] private Button setting_btn;

    void Awake()
    {
        single_btn.onClick.AddListener(OnSinglePlayBtn);
        dual_btn.onClick.AddListener(OnDualPlayBtn);
        multi_btn.onClick.AddListener(OnMultiPlayBtn);
        setting_btn.onClick.AddListener(OnSettingsBtn);
    }

    public void OnSinglePlayBtn()
    {
        GameManager.Instance.ChangeToGameScene(Constants.GameType.Single);
    }

    public void OnMultiPlayBtn()
    {
        GameManager.Instance.ChangeToGameScene(Constants.GameType.Dual);
    }

    public void OnDualPlayBtn()
    {
        GameManager.Instance.ChangeToGameScene(Constants.GameType.Multi);
    }

    public void OnSettingsBtn()
    {
        
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
