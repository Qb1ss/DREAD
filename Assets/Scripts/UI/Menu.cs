using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _controlWindow;
    [Space(height: 5f)]

    [SerializeField] private AudioSource _tap;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Button_ControlExit();
        }
    }


    public void Button_Control()
    {
        _tap.Play();
        _controlWindow.SetActive(true);
    }


    public void Button_ControlExit()
    {
        _tap.Play();
        _controlWindow.SetActive(false);
    }
}
