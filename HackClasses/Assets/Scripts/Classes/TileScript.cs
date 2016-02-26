using UnityEngine;
using System.Collections;

public class Tile
{
    #region Atributos

    //Atributos
    private GameObject gbjTilePrefab;
    private bool bIsEmpty;
    private bool bWalkable;
    private int iTileType;
    private int iX;
    private int iY;

    //Atributos para A*
    private int iGCost;
    private int iHCost;
    private int iFCost;
    #endregion

    #region MetodosAcceso

    //Metodos de Acceso
    public GameObject getTilePrefab ()
    {
        return gbjTilePrefab;
    }

    public bool IsEmpty ()
    {
        return bIsEmpty;
    }

    public int getTileType ()
    {
        return iTileType;
    }

    public int getX ()
    {
        return iX;
    }

    public int getY ()
    {
        return iY;
    }

    public int getGCost ()
    {
        return iGCost;
    }

    public int getHCost ()
    {
        return iHCost;
    }

    public int getFCost()
    {
        return iFCost;
    }

    public bool isWalkable ()
    {
        return bWalkable;
    }

    #endregion

    #region MetodosModificacion

    ////Metodo de Modificacion
    public void setTilePrefab (GameObject gbjTile)
    {
        gbjTilePrefab = gbjTile;
    }

    public void setEmpty (bool bSet)
    {
        bIsEmpty = bSet;
    }

    public void setTileType (int iType)
    {
        iTileType = iType;
    }

    public void setX (int ix)
    {
        iX = ix;
    }

    public void setY (int iy)
    {
        iY = iy;
    }

    public void setGCost (int iG)
    {
        iGCost = iG;
    }

    public void setHCost (int iH)
    {
        iHCost = iH;
    }

    public void setFCost(int iF)
    {
        iFCost = iF;
    }
    
    public void makeWalkable (bool bMake)
    {
        bWalkable = bMake;
    }

    #endregion

    #region Constructores

    //Constructor por Default
    public Tile()
    {
        gbjTilePrefab = null;
        bIsEmpty = true;
        iTileType = 0;
        bWalkable = true;
        iGCost = 0;
        iHCost = 0;
        iFCost = 0;
        iX = 0;
        iY = 0;
    }

    //Constructor por Parametros
    public Tile(GameObject gbjTile, int iType, bool bIsEmp, bool isWalk, int iG, int iH, int iF, int ix, int iy)
    {
        gbjTilePrefab = gbjTile;
        iTileType = iType;
        bIsEmpty = bIsEmp;
        bWalkable = isWalk;
        iGCost = iG;
        iHCost = iH;
        iFCost = iF;
        iX = ix;
        iY = iy;
    }

    #endregion

    #region OtrosMetodos

    //Aqui Escribe Metodos de a clase tile si los necesitas, Documentalos con el formato de caja

    //Falta documentar
    public void ChangeMaterial (Material mtrlNew)
    {
        GameObject instant =  this.getTilePrefab();

        instant.GetComponent<Renderer>().material = mtrlNew;

    }

    #endregion
}
