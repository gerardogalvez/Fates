using UnityEngine;
using System.Collections;

public class Item {

    //Atributos
    private string sName;

    //Constructor por Parametros
    Item()
    {
        sName = "NO-NAME";
    }

    //Constructor por Default
    Item(string sNam)
    {
        sName = sNam;
    }

    //Metodos de Acceso

    string getName()
    {
        return sName;
    }

    //Metodos de Modificacion
    void setName(string sNom)
    {
        sName = sNom;
    }

}
