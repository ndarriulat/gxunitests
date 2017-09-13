using System;

namespace PGGXUnit.Packages.GXUnit.GXUnitCore
{
    public static class Constantes
    {
        public const String PARM_INOUT  = "PARM_INOUT";
        public const String PARM_IN     = "PARM_IN";
        public const String PARM_OUT    = "PARM_OUT";

        public enum Estructurado {BC, SDT};

        public enum Tipo { Boolean, CHARACTER, DATE, DATETIME, BC, BC_LEVEL, EXTERNAL_OBJECT, SDT, INT, LONGVARCHAR, NUMERIC, VARCHAR };

        public const String RESULTADO = "Result";
        public const String VALOR_ESPERADO = "Expected";
        public const String ITEM = "Item";

        public static readonly DTFolder carpetaGXUnit = new DTFolder ("GXUnit", new Guid("ad5508ec-0000-43ae-a1a2-a671fb0ff967"), "");
        public static readonly DTFolder carpetaSuites = new DTFolder("Suites", new Guid("ad5508ec-0001-43ae-a1a2-a671fb0ff967"), carpetaGXUnit.GetNombre());
        public static readonly DTFolder carpetaResults = new DTFolder("Results", new Guid("ad5508ec-0002-43ae-a1a2-a671fb0ff967"), carpetaGXUnit.GetNombre());
        public static readonly DTFolder carpetaGXUnitFramework = new DTFolder("Framework", new Guid("ad5508ec-0003-43ae-a1a2-a671fb0ff967"), carpetaGXUnit.GetNombre());
        public static readonly DTFolder carpetaFrameworkAsserts = new DTFolder("Asserts", new Guid("ad5508ec-0004-43ae-a1a2-a671fb0ff967"), carpetaGXUnitFramework.GetNombre());
        public static readonly DTFolder carpetaFrameworkGXUITest = new DTFolder("GXUITest", new Guid("ad5508ec-0005-43ae-a1a2-a671fb0ff967"), carpetaGXUnitFramework.GetNombre());
        public static readonly DTFolder carpetaFrameworkSDT = new DTFolder("SDTs", new Guid("ad5508ec-0006-43ae-a1a2-a671fb0ff967"), carpetaGXUnitFramework.GetNombre()); 


        public const String About = "Proyecto GXUnit\r\nNicolás Carro\r\nMarcos Olivera\r\nJuan Pablo Goyení\r\n2010 - 2011";

        public const String RESULT_PATH = "\\GXUnitResults\\";

        public const String RUNNER_PROC = "RunnerProcedure";
    }
}
