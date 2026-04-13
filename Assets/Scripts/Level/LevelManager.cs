using System.Collections;
using TMPro;
using Unity.Multiplayer.PlayMode;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    private int totalStars;
    private int collectedStars;

    public ExitDoor exitDoor;
    public CameraMove cameraMove;
    public Transform player;

    private bool levelFinished = false;
    public ButtonManager buttonManager;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public TMP_Text textCountDiamond;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StarCollectible[] stars = FindObjectsByType<StarCollectible>(FindObjectsSortMode.None);
        totalStars = stars.Length;
        collectedStars = 0;

        UpdateDiamondUI();
    }

    public void CollectStar()
    {
        collectedStars++;
        UpdateDiamondUI();

        if (collectedStars >= totalStars)
        {
            StartCoroutine(ShowDoorRoutine(exitDoor.doorPoint));
        }
    }
    public void UpdateHeartsUI(int currentLives)
    {
        heart1.SetActive(currentLives >= 1);
        heart2.SetActive(currentLives >= 2);
        heart3.SetActive(currentLives >= 3);
    }
    public void UpdateDiamondUI()
    {
        textCountDiamond.text = "x" + collectedStars.ToString();
    }
    private IEnumerator ShowDoorRoutine(Transform doorPoint)
    {
        cameraMove.SetTarget(doorPoint);
        yield return new WaitForSeconds(1f);
        exitDoor.OpenDoor();
        yield return new WaitForSeconds(2f);
        cameraMove.SetTarget(player);
    }

    public void FinishLevel()
    {
        if (levelFinished)
            return;

        levelFinished = true;
        StartCoroutine(FinishRoutine());
    }

    private IEnumerator FinishRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        buttonManager.ShowWinPanel();
    }
    public void LoseLevel()
    {
        if (levelFinished)
            return;

        levelFinished = true;
        buttonManager.ShowLosePanel();
    }
}
