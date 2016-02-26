using UnityEngine;
using System.Collections;

public class Equipment {

    //Atributos
    private string sName;

    //Constructor por Parametros
    Equipment()
    {
        sName = "NO-NAME";
    }
    
    //Constructor por Default
    Equipment(string sNam)
    {
        sName = sNam;
    }

    //Metodos de Acceso

    string getName ()
    {
        return sName;
    }

    //Metodos de Modificacion
    void setName (string sNom)
    {
        sName =  sNom;
    }
}
