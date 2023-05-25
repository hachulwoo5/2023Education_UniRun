using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 게임 오버 상태를 표현하고, 게임 점수와 UI를 관리하는 게임 매니저
// 씬에는 단 하나의 게임 매니저만 존재할 수 있다.
public class GameManager : MonoBehaviour {
    public static GameManager instance; 
    public PlayerController PlayerController;

    public bool isGameover = false; 
    public Text scoreText; 
    public GameObject gameoverUI; 
    public Text bestui;
    public int newScore;

    public float time;

    private int score = 0; // 게임 점수
    public float bestScore;

    public float Checktime;


    void Awake() {

        Init();

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }


    }

    void Update() {

        time = Time.time - Checktime;
        bestui.text = "Best : " + bestScore;
        if (!PlayerController.isDead)
        {
            score = newScore;
            scoreText.text = "SCORE : " + newScore;
        }

        if (Input.GetKeyDown(KeyCode.R) && PlayerController.isDead)
        {
            Init();
            SceneManager.LoadScene("SampleScene");
            
        }
    }

    // 점수를 증가시키는 메서드
    public void AddScore() {
        newScore++;
        
    }

    // 플레이어 캐릭터가 사망시 게임 오버를 실행하는 메서드
    public void OnPlayerDead() 
    {
        gameoverUI.SetActive(true);
        if (bestScore == 0 || score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetFloat("BestRecord_Ball", bestScore);
        }


    }
    public void Init()
    {

        bestScore = PlayerPrefs.GetFloat("BestRecord_Ball", bestScore);
        Checktime = Time.time;


     

    }
}