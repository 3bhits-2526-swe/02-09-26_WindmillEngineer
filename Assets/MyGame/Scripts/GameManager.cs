using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Demand")]
    public float demand = 0f;
    public float demandTimerMax;
    public Image demandBar;

    [Header("Wind")]
    public float windTimerMax;
    public Image windBar;
    public float windTimer;
    public Vector2 windLevel;

    [Header("Windmill")]
    public int activeWindmills = 5;

    [Header("Supply")]
    public Image supplyBar;

    [Header("Akku")]
    public Image AkkuBar;
    public float currentAkku = 45f;
    public float AkkuDischargeSpeed = 1f;
    public float standardAkkuChargeSpeed = 3.2f;
    
    [Header("Money")]
    public float money;
    public float reductionPersentage = 100;
    public float increment = 12.25f;
    public TextMeshProUGUI moneyText;

    [Header("Screen")]
    public GameObject gameScreen;
    public GameObject winScreen;
    public GameObject loseScreen;

    void Start()
    {
        windTimer = windTimerMax;
        
        InvokeRepeating(nameof(UpdateAkku), 0f, 1f);
        InvokeRepeating(nameof(CalcMoney), 0f, 1f);
        InvokeRepeating(nameof(RenderMoney), 0f, 1f);
        InvokeRepeating(nameof(CalcDemand), 0f, demandTimerMax);

        HideScreen(winScreen);
        HideScreen(loseScreen);
    }

    void Update()
    {
        CalcWind();
    }
    
    public void CalcDemand()
    {
        float randnr = UnityEngine.Random.Range(0f, 1f);
        demandBar.fillAmount = randnr;
        demand = randnr;
        
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
        currentAkku -= AkkuDischargeSpeed * (demand*10);
        
        float windStrength = (Mathf.Abs(windLevel.x) + Mathf.Abs(windLevel.y)) / 2f;
        currentAkku += activeWindmills * standardAkkuChargeSpeed * windStrength;

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

    public void CalcMoney()
    {
        float windStrength = (Mathf.Abs(windLevel.x) + Mathf.Abs(windLevel.y)) / 2f;
        if(AkkuDischargeSpeed > (activeWindmills * standardAkkuChargeSpeed * windStrength))
            reductionPersentage = 200;

        else if(AkkuDischargeSpeed == (activeWindmills * standardAkkuChargeSpeed * windStrength))
            reductionPersentage = 100;

        else if(AkkuDischargeSpeed < (activeWindmills * standardAkkuChargeSpeed * windStrength))
            reductionPersentage = 0;

        money += increment - (increment* (reductionPersentage/100));
    }
}