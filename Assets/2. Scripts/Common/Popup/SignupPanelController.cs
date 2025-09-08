using TMPro;
using UnityEngine;
using UnityEngine.UI;

public struct SignupData
{
    public string username;
    public string password;
    public string nickname;
}

public class SignupPanelController : PanelController
{
    [SerializeField] private TMP_InputField username_input_field;
    [SerializeField] private TMP_InputField password_input_field;
    [SerializeField] private TMP_InputField confirm_password_input_field;
    [SerializeField] private TMP_InputField nickname_input_field;
    [SerializeField] private Button confirm_btn;
    [SerializeField] private Button cancel_btn;

    protected override void Awake()
    {
        base.Awake();

        this.confirm_btn.onClick.AddListener(OnClickConfirmButton);
        this.cancel_btn.onClick.AddListener(OnClickCancelButton);
    }

    public void OnClickConfirmButton()
    {
        string username = username_input_field.text;
        string password = password_input_field.text;
        string confirmPassword = confirm_password_input_field.text;
        string nickname = nickname_input_field.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
            string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(nickname))
        {
            Shake();
            return;
        }

        // Confirm Password 확인
        if (password.Equals(confirmPassword))
        {
            var signupData = new SignupData();
            signupData.username = username;
            signupData.password = password;
            signupData.nickname = nickname;

            StartCoroutine(NetworkManager.Instance.Signup(signupData,
                () =>
                {
                    GameManager.Instance.OpenConfirmPanel("회원가입에 성공했습니다.",
                        () =>
                        {
                            Hide();
                        });
                },
                (result) =>
                {
                    if (result == 0)
                    {
                        GameManager.Instance.OpenConfirmPanel("이미 존재하는 사용자입니다.",
                            () =>
                            {
                                username_input_field.text = "";
                                password_input_field.text = "";
                                confirm_password_input_field.text = "";
                                nickname_input_field.text = "";
                            });
                    }
                }));

        }
        else
        {

        }
    }

    public void OnClickCancelButton()
    {
        Hide();
    }
}
