using UnityEngine;
using System.Collections;

public class Player : Unit
{
    #region Constructores
    //Constructor por Default
     public Player()
    {
        gbjPrefab = null;
        iCurrentX = 0;
        iCurrentY = 0;

        eqpCurrentEquip = new Equipment[100];
        itmCurrentItems = new Item[100];
        sStatus = "Idle";

        iBaseMovSpeed = 5;
        iBaseAttackSpeed = 1;
        iBaseMovement = 4;

        sAffinity = "None";
        iBaseStrength = 1;
        iBaseAgility = 1;

        iBaseEndurance = 1;
        iBaseLuck = 0;
        iBaseAccuracy = 1;

        iBaseMagicResist = 1;
        fBaseCritChance = 0.0f;
        fBaseCritEvade = 0.0f;
        iBaseHp = 10;
    }

    //Constructor con Parametros
    public Player(GameObject gbjObj, int iX, int iY, Equipment [] Equips, Item [] Items, string sStat, int iMovSpd, int iAttckSpd, 
        int iMov, string sAff, int iStr, int iAgi, int iEnd, int iL, int iAcc, int iMagicR, float fCrit, float fCritEv, int iHp)
    {
        gbjPrefab = gbjObj;
        iCurrentX = iX;
        iCurrentY = iY;

        eqpCurrentEquip = Equips;
        itmCurrentItems = Items;
        sStatus = sStat;

        iBaseMovSpeed = iMovSpd;
        iBaseAttackSpeed = iAttckSpd;
        iBaseMovement = iMov;

        sAffinity = sAff;
        iBaseStrength = iStr;
        iBaseAgility = iAgi;

        iBaseEndurance = iEnd;
        iBaseLuck = iL;
        iBaseAccuracy = iAcc;

        iBaseMagicResist = iMagicR;
        fBaseCritChance = fCrit;
        fBaseCritEvade = fCritEv;
        iBaseHp = iHp;
    }
    #endregion

    #region Metodos_Acceso

    public GameObject getPrefab ()
    {
        return gbjPrefab;
    }

    public int getX ()
    {
        return iCurrentX;
    }

    public int getY()
    {
        return iCurrentY;
    }

    public Equipment[] getEquipments ()
    {
        return eqpCurrentEquip;
    }

    public Item[] getItems ()
    {
        return itmCurrentItems;
    }

    public string getStatus ()
    {
        return sStatus;
    }

    public int getMovSpeed ()
    {
        return iBaseMovSpeed;
    }

    public int getAttackSpeed ()
    {
        return iBaseAttackSpeed;
    }

    public int getMovement ()
    {
        return iBaseMovement;
    }

    public string getAffinity ()
    {
        return sAffinity;
    }

    public int getStrength ()
    {
        return iBaseStrength;
    }

    public int getAgility()
    {
        return iBaseAgility;
    }

    public int getEndurance()
    {
        return iBaseEndurance;
    }

    public int getLuck()
    {
        return iBaseLuck;
    }

    public int getAccuracy()
    {
        return iBaseAccuracy;
    }

    public int getMagicResist ()
    {
        return iBaseMagicResist;
    }

    public float getCritChance ()
    {
        return fBaseCritChance;
    }

    public float getCritEvade()
    {
        return fBaseCritEvade;
    }

    public int getHp ()
    {
        return iBaseHp;
    }

    #endregion

    #region Metodos_Modificacion

    public void setX (int iX)
    {
        iCurrentX = iX;
    }

    public void setY(int iY)
    {
        iCurrentY = iY;
    }

    public void setPrefab (GameObject gbjObj)
    {
        gbjPrefab = gbjObj;
    }

    public void setEquipment (Equipment[] equips)
    {
        eqpCurrentEquip = equips;
    }

    public void setItems (Item[] items)
    {
        itmCurrentItems = items;
    }

    public void setStatus (string sSta)
    {
        sStatus = sSta;
    }

    public void setBaseMovSpeed (int iMovSpeed)
    {
        iBaseMovSpeed = iMovSpeed;
    }

    public void setBaseAttackSpeed (int iAttckSpeed)
    {
        iBaseAttackSpeed = iAttckSpeed;
    }

    public void setBaseMovement (int iMovement)
    {
        iBaseMovement = iMovement;
    }

    public void setAffinity (string sAff)
    {
        sAffinity = sAff;
    }

    public void setStrength (int iStr)
    {
        iBaseStrength = iStr;
    }

    public void setAgility (int iAgi)
    {
        iBaseAgility = iAgi;
    }

    public void setEndurance (int iEnd)
    {
        iBaseEndurance = iEnd;
    }

    public void setLuck (int iL)
    {
        iBaseLuck = iL;
    }

    public void setAccuracy (int iAcc)
    {
        iBaseAccuracy = iAcc;
    }

    public void setMagicResist (int iMagicR)
    {
        iBaseMagicResist = iMagicR;
    }

    public void setCritChance (float fCrit)
    {
        fBaseCritChance = fCrit;
    }

    public void setCritEvade (float fCritEv)
    {
        fBaseCritEvade = fCritEv;
    }

    public void setHp (int iHp)
    {
        iBaseHp = iHp;
    }
    #endregion

}
