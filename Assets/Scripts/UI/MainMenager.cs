using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenager : MonoBehaviour
{
    [SerializeField]
    private bck bc;

    [SerializeField]
    private GameObject main;
    [SerializeField]
    private GameObject cred;
    [SerializeField]
    private GameObject set;
    [SerializeField]
    private Text onf;
    private bool onoff;

    public void Play(){
        SceneManager.LoadScene(1);
    }
    public void Exit(){
        Application.Quit();
    }
    public void Settings(){
        main.SetActive(false);
        cred.SetActive(false);
        set.SetActive(true);
    }
    public void Credits(){
        main.SetActive(false);
        cred.SetActive(true);
        set.SetActive(false);
    }
    public void Sound(){
        if(onoff == true){
            onoff = !onoff;
            Com.mc = !Com.mc;
            onf.text = "On";
            bc.BckSound(true);
        }
        else{
            Com.mc = !Com.mc;
            onf.text = "Off";
            onoff = !onoff;
            bc.BckSound(false);
        }
    }
    public void Back(){
        main.SetActive(true);
        cred.SetActive(false);
        set.SetActive(false);
    }
}
