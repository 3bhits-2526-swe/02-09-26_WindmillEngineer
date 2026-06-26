using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Configurable Variables")]
    public float demandTimerMax;
    public float windTimerMax;

    [Header("UI")]
    public Image demandBar;
    public Image supplyBar;
    public Image batteryBar;
    public Image windArrow;
    public TextMeshProUGUI windLevelIndicator;

    [Header("Other Variables")]
    public float demandTimer;
    public float windTimer;
    public Vector2 windDirection;
    public float windLevel;
    public float money;

<<<<<<< HEAD
    [Header("Windmill")]
    public int activeWindmills = 5;

    [Header("Supply")]

    [Header("Akku")]
    public Image AkkuBar;
    public float currentAkku = 45f;
    public float AkkuDischargeSpeed = 1f;
    public float standardAkkuChargeSpeed = 3.2f;
    
    [Header("Money")]
    public float reductionPercentage = 100;
    public float increment = 12.25f;
    public TextMeshProUGUI moneyText;

    [Header("Screen")]
    public GameObject gameScreen;
    public GameObject winScreen;
    public GameObject loseScreen;
=======
>>>>>>> parent of 26ac51b (Merge branch 'main' into winbar-design-#23)

    void Start()
    {
        demandTimer = demandTimerMax;
        windTimer = windTimerMax;
    }

    // Update is called once per frame
    void Update()
    {
        CalcDemand();
        CalcWind();
        RenderMoney();
        RenderWind();
    }
    
    public void CalcDemand()
    {
        demandTimer += Time.deltaTime;
        if (demandTimer >= demandTimerMax)
        {
            float demand = 0;
            demand = UnityEngine.Random.Range(0f, 1f);
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
            windLevel = UnityEngine.Random.Range(0f, 1f);
            windDirection = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
            float angle = Mathf.Atan2(windDirection.y, windDirection.x) * Mathf.Rad2Deg;
            windTimer = 0f;
        }
    }
    public void RenderWind()
    {
        float angle = Mathf.Atan2(windDirection.y, windDirection.x) * Mathf.Rad2Deg;
        float arrowScale = Mathf.Lerp(0.2f, 1.2f, Mathf.Clamp01(windLevel));
        windArrow.rectTransform.localScale = new Vector3(arrowScale, arrowScale, windArrow.rectTransform.localScale.z);
        windArrow.rectTransform.rotation = Quaternion.Euler(0, 0, angle);
<<<<<<< HEAD
        windLevelIndicator.text = (windLevel * 100f).ToString("F0") + "%";        
    }

    public void UpdateAkku()
    {
        currentAkku -= AkkuDischargeSpeed * (demand*10);
        
        currentAkku += activeWindmills * standardAkkuChargeSpeed * windLevel;

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
    
        if(AkkuDischargeSpeed > (activeWindmills * standardAkkuChargeSpeed * windLevel))
            reductionPercentage = 200;

        else if(AkkuDischargeSpeed == (activeWindmills * standardAkkuChargeSpeed * windLevel))
            reductionPercentage = 100;

        else if(AkkuDischargeSpeed < (activeWindmills * standardAkkuChargeSpeed * windLevel))
            reductionPercentage = 0;

        money += increment - (increment * reductionPercentage / 100);
=======
        windLevelIndicator.text = (windLevel * 100f).ToString("F0") + "%";
>>>>>>> parent of 26ac51b (Merge branch 'main' into winbar-design-#23)
    }
}
