using TMPro;
using UnityEngine;
using UnityEngine.UI;

public struct SigninData
{
    public string username;
    public string password;
}

public struct SigninResult
{
    public int result;
}

public class SigninPanelController : PanelController
{
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField passwordInputField;

    [SerializeField] private Button confirm_btn;
    [SerializeField] private Button signup_btn;

    protected override void Awake()
    {
        base.Awake();
        confirm_btn.onClick.AddListener(OnClickConfirmBtn);
        signup_btn.onClick.AddListener(OnClickSignupBtn);
    }

    private void OnClickConfirmBtn()
    {
        string username = usernameInputField.text;
        string password = passwordInputField.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            Shake();
            return;
        }

        var signinData = new SigninData();
        signinData.username = username;
        signinData.password = password;

        StartCoroutine(NetworkManager.Instance.Signin(signinData,
            () =>
            {
                Hide();
            },
            (result) =>
            {
                if (result == 0)
                {
                    GameManager.Instance.OpenConfirmPanel("유저네임이 유효하지 않습니다.",
                        () =>
                        {
                            usernameInputField.text = "";
                            passwordInputField.text = "";
                        });
                }
                else if (result == 1)
                {
                    GameManager.Instance.OpenConfirmPanel("패스워드가 유효하지 않습니다.",
                        () =>
                        {
                            passwordInputField.text = "";
                        });
                }
            }));
    }


    private void OnClickSignupBtn()
    {
        GameManager.Instance.OpenSignupPanel();
    }
}