using System;

namespace PGGXUnit.Packages.GXUnit.GXUnitCore
{
    public class DTFolder : DTObjeto
    {
        private String NombrePadre;
        public Guid IdObjeto { get; set; }

        public DTFolder(String nom, Guid Id, String nomPadre)
            : base(nom)
        {
            NombrePadre = nomPadre;
            IdObjeto = Id;
        }

        public String GetNombrePadre()
        {
            return NombrePadre;
        }
    }
}
