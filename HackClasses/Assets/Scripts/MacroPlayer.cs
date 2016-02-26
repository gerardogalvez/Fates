using UnityEngine;
using System.Collections;


//Este script pertenece al Prefab 'Map'

public class MacroPlayer : MonoBehaviour
{

    #region Declarations
    //Number of tiles in the X and Y coordinates
    public int iNumTilesX;
    public int iNumTilesY;

    //Width and Height of the tiles (Prefab)
    public float fWidth; //Default = 1
    public float fHeight; // Default = 1

    //Tile Object
    public GameObject gbjTile;

    //Tile Material
    public Material mtrlGrass;

    //Matriz a llenar de informacion
    public Tile[,] matTiles = new Tile[100, 100];
    private int iSizeX = 0;
    private int iSizeY = 0;

    //Objectos de Prueba PathFinder
    private Player plrtest = new Player();
    public GameObject gbjPrefab;

    #endregion


    void Start()
    {
        //Llamar a funcion para crear el mapa
        CreateMap(gbjTile, iNumTilesX, iNumTilesY, fWidth, fHeight, matTiles, ref iSizeX, ref iSizeY);
        plrtest.setPrefab(gbjPrefab);

       
    }
       


    /*////////////////////////////////////////////////////////////////////
    // CreateMap
    //
    //  Funcion que recibe los datos para crear un mapa de tiles y lo 
    //  crea teniendo la tile(0,0) en el origen de UNITY 0,0,0 ->x,y,z
    //
    //  Parametros:
    //
    //  GameObject    obj     Objecto que se genera como 'tile' del mapa
    //  int   iNumTilesX      Cantidad de tiles en X
    //  int   iNumTilesY      Cantidad de tiles en Y
    //  float fWidth          Lo que mide obj de Ancho
    //  float fHeight         Lo que mide obj de Alto  
    //  Matriz<GameObject>    Matriz Vacia, a llenar en el metodo.
    //
    //  Reegresa:
    //
    //  Nada, La funcion es void
    //
    /////////////////////////////////////////////////////////////////////*/

    public void CreateMap(GameObject obj, int iNumTilesX, int iNumTilesY, float fWidth, float fHeight, Tile[,] matTiles, ref int iSizeX, ref int iSizeY)
    {
        //Ciclo para generar 'tiles' en Y (Columnas)
        for (int j = 0; j < iNumTilesY; j++)
        {
            //Ciclo para generar 'tiles' en X (Filas)
            for (int i = 0; i < iNumTilesX; i++)
            {
                //Generar y referenciar instancia de tile en la coordenada y variable correspondiente, referenciado a 'Instant'
                GameObject Instant = (GameObject)Instantiate(obj, new Vector3(j * fHeight, 0, (iNumTilesX - 1) - fWidth * i), Quaternion.identity);

                Instant.GetComponentInChildren<Renderer>().material = mtrlGrass;
                //Instant.GetComponentInChildren<Renderer>().material.color = Color.black;

                //Nombrar Instancia de 'Tile' con la coordenada correcta
                Instant.name = "Tile_" + i + "_" + j;

                //Hacer Instacia de 'Tile' hija de 'Map'
                Instant.transform.parent = this.transform;

                //Make Tile Instance
                Tile TileInstant = new Tile(Instant, 0, true, true, 0, 0, 0, j, i);

                //Give the Tile instance the GameObject Instance
                TileInstant.setTilePrefab(Instant);

                //Llenar de informacion la Matriz
                matTiles[i, j] = TileInstant;

            }
            //Incrementa el tama;o de la Matriz en Y
            iSizeY++;
            //Incrementa el tama;o de la Matriz en X
            iSizeX++;
        }
    }


    //ESTE SCRIPT ES TEMPORAL, SE CAMBIARA DESPUES... O no.. chance no... preguntale a Andres.

    public static void MoveSelectedTo(Player plrToMove, Tile tilStartTile, Tile tilEndTile, Tile[,] tilMap)
    {
        //Contador del Array de Calculadas
        int iCalculadasCont = 0;

        //Array de Tiles Adyacentes y Calculadas
        Tile[] CalculatedTiles = new Tile[100];
        int iCalculatedSize = 0;

        //Array de Tiles que ya Cruzamos
        Tile[] WalkedOnTiles = new Tile[50];
        int iWalkedOnSize = 0;

        //Agrega La tile Inicial a las WalkedOn
        WalkedOnTiles[iWalkedOnSize++] = tilStartTile;

        //Condiciones para el primer caso
        Tile tilCurrent = new Tile();
        tilCurrent = tilStartTile;

        //Condicion de Salida
        bool bPathFound = false;

        //Hardcoded Agregar las tiles adyacentes a la current Tile


        while (!bPathFound)
        {

            //Add tile above if possible
            if (tilMap[tilCurrent.getX(), tilCurrent.getY() + 1].isWalkable() && !FindInWalkable(tilMap[tilCurrent.getX(), tilCurrent.getY() + 1], WalkedOnTiles, iWalkedOnSize))
            {
                CalculatedTiles[iCalculatedSize++] = tilMap[tilCurrent.getX(), tilCurrent.getY() + 1];
            }

            //Add tile below if possible
            if (tilMap[tilCurrent.getX(), tilCurrent.getY() - 1].isWalkable() && !FindInWalkable(tilMap[tilCurrent.getX(), tilCurrent.getY() - 1], WalkedOnTiles, iWalkedOnSize))
            {
                CalculatedTiles[iCalculatedSize++] = tilMap[tilCurrent.getX(), tilCurrent.getY() - 1];
            }

            //Add tile right if possible
            if (tilMap[tilCurrent.getX() + 1, tilCurrent.getY()].isWalkable() && !FindInWalkable(tilMap[tilCurrent.getX() + 1, tilCurrent.getY()], WalkedOnTiles, iWalkedOnSize))
            {
                CalculatedTiles[iCalculatedSize++] = tilMap[tilCurrent.getX() + 1, tilCurrent.getY()];
            }
            //Add tile left if possible
            if (tilMap[tilCurrent.getX() - 1, tilCurrent.getY()].isWalkable() && !FindInWalkable(tilMap[tilCurrent.getX() - 1, tilCurrent.getY()], WalkedOnTiles, iWalkedOnSize))
            {
                CalculatedTiles[iCalculatedSize++] = tilMap[tilCurrent.getX() - 1, tilCurrent.getY() + 1];
            }

            //Calcula el G, H Cost de las tiles vecinas
            for (; iCalculadasCont < iCalculatedSize; iCalculadasCont++)
            {
                //Calculate G cost for all adyacent
                CalculateGCost(tilStartTile, tilEndTile, tilMap, CalculatedTiles[iCalculadasCont]);
                //Calculate H cost for all adyacent
                CalculateHCost(tilStartTile, tilEndTile, tilMap, CalculatedTiles[iCalculadasCont]);
            }

            //Calculate F cost for all Adyacent
            for (int iI = 0; iI < iCalculatedSize; iI++)
            {
                CalculatedTiles[iI].setFCost(CalculatedTiles[iI].getGCost() + CalculatedTiles[iI].getHCost());
            }

            //Pick a Tile to Walk on
            tilCurrent = GetFromCalculated(CalculatedTiles, iCalculatedSize);

            //Mark that tile as walked on
            WalkedOnTiles[iWalkedOnSize++] = tilCurrent;

            if (tilCurrent == tilEndTile)
            {
                bPathFound = true;
            }

        }

        DespliegaCamino(WalkedOnTiles, iWalkedOnSize);
    }

    public static void CalculateGCost(Tile tilStart, Tile tilEnd, Tile[,] tilMap, Tile tilInstant)
    {

        int iXOffset = Mathf.Abs(tilInstant.getX() - tilStart.getX());
        int iYOffset = Mathf.Abs(tilInstant.getX() - tilStart.getY());

        tilInstant.setGCost(iXOffset + iYOffset);

    }

    public static void CalculateHCost(Tile tilStart, Tile tilEnd, Tile[,] tilMap, Tile tilInstant)
    {
        int iXOffset = Mathf.Abs(tilInstant.getX() - tilEnd.getX());
        int iYOffset = Mathf.Abs(tilInstant.getY() - tilEnd.getY());

        tilInstant.setHCost(iXOffset + iYOffset);
    }

    public static Tile GetFromCalculated(Tile[] CalculatedTiles, int iCalculatedSize)
    {
        Tile tilNextTile = new Tile();

        for (int iI = 0; iI < iCalculatedSize; iI++)
        {
            if (iI == 0)
            {
                tilNextTile = CalculatedTiles[iI];
            }
            else
            {
                if (CalculatedTiles[iI].getFCost() < tilNextTile.getFCost())
                {
                    tilNextTile = CalculatedTiles[iI];
                }
            }
        }

        return tilNextTile;
    }

    public static bool FindInWalkable(Tile tilSubject, Tile[] WalkedOnTiles, int iWalkedOnSize)
    {
        bool bFounded = false;

        for (int iI = 0; iI < iWalkedOnSize && !bFounded; iI++)
        {
            if (WalkedOnTiles[iI] == tilSubject)
            {
                bFounded = true;
            }
        }

        return bFounded;
    }

    public static void DespliegaCamino(Tile[] WalkedOnTiles, int iWalkedOnSize)
    {
        for (int iI = 0; iI < iWalkedOnSize; iI++)
        {
            RayCasting.DisplaySelectedTile(WalkedOnTiles[iI].getTilePrefab());
        }
    }

}

