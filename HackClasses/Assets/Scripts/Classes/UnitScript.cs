using UnityEngine;
using System.Collections;

public abstract class Unit
{
    #region Atributos
    //Atributos para interactuar en Unity
    protected GameObject gbjPrefab;
    protected int iCurrentX;
    protected int iCurrentY;

    //Equipment and Items
    protected Equipment [] eqpCurrentEquip;
    protected Item [] itmCurrentItems;

    //Status
    protected string sStatus;

    //Base Status
    protected int iBaseMovSpeed;
    protected int iBaseAttackSpeed;
    protected int iBaseMovement;
    protected string sAffinity;
    protected int iBaseStrength;
    protected int iBaseAgility;
    protected int iBaseEndurance;
    protected int iBaseLuck;
    protected int iBaseAccuracy;
    protected int iBaseMagicResist;
    protected float fBaseCritChance;
    protected float fBaseCritEvade;
    protected int iBaseHp;

    #endregion

}
