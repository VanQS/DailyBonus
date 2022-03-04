using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.U2D;

[System.Serializable]
public class Days
{
    public int day;
    public int coin;
    public int gem;
}


public class DailyBonusRewar : MonoBehaviour
{
    public TextAsset txtJson;
    public GameObject Dailyprefab;
    public GameObject GridDaily;
    public SpriteAtlas SpriteAtlasCheckIcon;
    public SpriteAtlas SpriteAtlasBox;
    public List<Days> ListDataDays = new List<Days>();
    public List<DailyBonusItem> ListSetData = new List<DailyBonusItem>();
    public int currday;
    public GameController gameController = new GameController();

    private Days dataDay = new Days();
    private bool init;

   

    void Start()
    {
        initItem();
        gameController.btnDiemdanh.onClick.AddListener(initItem);

    }

    private void initItem()
    {
        this.ListDataDays = JsonConvert.DeserializeObject<List<Days>>(txtJson.text);
        currday = DailyBonusMange.GetIndex();

        if(ListDataDays == null || ListDataDays.Count == null)
        {
            return;
        }
        if (init)
        {
            for (int i = 0; i < ListDataDays.Count; i++)
            {
                ListSetData[i].SetData(this, ListDataDays[i], currday == i, currday > i, currday < i );
               
            }
        }


        else if (init == false)
        {
            for (int i = 0; i < ListDataDays.Count; i++)
            {
                GameObject dailyBonusItem = GameObject.Instantiate(Dailyprefab);
                dailyBonusItem.transform.SetParent(GridDaily.transform);
                dailyBonusItem.transform.localScale = Vector3.one;
                dailyBonusItem.transform.localPosition = Vector3.zero;
                dailyBonusItem.transform.localRotation = Quaternion.identity;
                dailyBonusItem.SetActive(true);
                DailyBonusItem conmpoment = dailyBonusItem.GetComponent<DailyBonusItem>();

                conmpoment.SetData(this, ListDataDays[i], currday == i, currday > i,  currday<i );
                ListSetData.Add(conmpoment);

            }
        }

        init = true;

    }
    
    IEnumerator CloseDailyBonus()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }    

   
}
