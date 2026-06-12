using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Demand")]
    public float demandTimerMax;
    public float demandTimer;
    public Image demandBar;

    [Header("Wind")]
    public float windTimerMax;
    public Image windBar;
    public float windTimer;
    public Vector2 windLevel;

    [Header("Windmill")]
    public int activWindmills = 1;

    [Header("Supply")]
    public Image supplyBar;

    [Header("Akku")]
    public Image AkkuBar;
    public float currentAkku = 45f;
    public float AkkuDischargeSpeed = 2.25f;
    public float standardAkkuChargeSpeed = 1.50f;
    
    [Header("Money")]
    public float money;
    public TextMeshProUGUI moneyText;

    [Header("Screen")]
    public GameObject gameScreen;
    public GameObject winScreen;
    public GameObject loseScreen;

    void Start()
    {
        demandTimer = demandTimerMax;
        windTimer = windTimerMax;
        
        InvokeRepeating(nameof(UpdateAkku), 0f, 1f);

        HideScreen(winScreen);
        HideScreen(loseScreen);
    }

    void Update()
    {
        CalcDemand();
        CalcWind();
        RenderMoney();
    }
    
    public void CalcDemand()
    {
        demandTimer += Time.deltaTime;
        if (demandTimer >= demandTimerMax)
        {
            float demand = UnityEngine.Random.Range(0f, 1f);
            demandBar.fillAmount = demand;
            demandTimer = 0f;
        }
    }

    public void RenderMoney()
    {
        moneyText.text = "$" + money.ToString();
    }

    public void CalcWind()
    {
        windTimer += Time.deltaTime;
        if (windTimer >= windTimerMax)
        {
            windLevel = UnityEngine.Random.insideUnitCircle;
            windBar.fillAmount = (Mathf.Abs(windLevel.x) + Mathf.Abs(windLevel.y)) / 2f;
            windTimer = 0f;
        }
    }

    public void UpdateAkku()
    {
        currentAkku -= AkkuDischargeSpeed;
        
        float windStrength = (Mathf.Abs(windLevel.x) + Mathf.Abs(windLevel.y)) / 2f;
        currentAkku += activWindmills * standardAkkuChargeSpeed * windStrength;

        money += 12.8f;

        AkkuBar.fillAmount = currentAkku / 100f;

        if (currentAkku >= 100f)
        {
            currentAkku = 100f;
            HideScreen(gameScreen);
            ShowScreen(winScreen);
            CancelInvoke(nameof(UpdateAkku));
        }
        else if (currentAkku <= 0f)
        {
            currentAkku = 0f;
            HideScreen(gameScreen);
            ShowScreen(loseScreen);
            CancelInvoke(nameof(UpdateAkku));
        }
    }

    public void ShowScreen(GameObject screen)
    {
        if (screen != null)
        {
            screen.SetActive(true);
        }
    }

    public void HideScreen(GameObject screen)
    {
        if (screen != null)
        {
            screen.SetActive(false);
        }
    }
}