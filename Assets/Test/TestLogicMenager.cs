
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestLogicMenager : MonoBehaviour{
    public static TestLogicMenager instance;

    [SerializeField]
    private Text ScoreDisplay,EndGameText;
    [SerializeField]
    private GameObject EndScrean,PouseScrean;

    [SerializeField]
    private int DeadPlayers =0,PlayerCount =2;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
    }
    public void AddScore(int Value){
        //dodawanie Scora
        int score = int.Parse(ScoreDisplay.text);
        ScoreDisplay.text = (score + Value).ToString();
    }
    public void EndGame(bool isVictory){
        //ekran końcowy
        Time.timeScale = 0;
        Debug.Log("victory");
        if(isVictory)EndGameText.text = "Victory";
        else EndGameText.text = "GameOver";
        EndScrean.SetActive(true);
    }
    public void ScoreBlink(){
        //miganie
    }
    //czy wszyscy gracze nie zyja
    public void PlayerDead(){
        DeadPlayers ++;
        if(DeadPlayers >= PlayerCount){
            EndGame(false);
        }
    }
    public void Pouse(bool isPoused){
        if(isPoused){
            PouseScrean.SetActive(!isPoused);
            Time.timeScale = 1;
        }
        else{
            PouseScrean.SetActive(!isPoused);
            Time.timeScale = 0;
        }
    }
    public void Exit(){
        Application.Quit();
    }
    public void Restart(){
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
