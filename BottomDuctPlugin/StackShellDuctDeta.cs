using Tekla.Structures.Plugins;

namespace BottomDuctPlugin

{
    public class StackShellDuctData
    {
        #region Fields

        [StructuresField("Thickness")]
        public double Thickness;

        [StructuresField("TopDuctLength")]
        public double TopDuctLength;

        [StructuresField("TopDuctHight")]
        public double TopDuctHight;

        [StructuresField("TopDuctWidth")]
        public double TopDuctWidth;

        [StructuresField("TopXOffset")]
        public double TopXOffset;

        [StructuresField("TopYOffset")]
        public double TopYOffset;

        [StructuresField("CenterDuctHight")]
        public double CenterDuctHight;

        [StructuresField("CenterDuctWidth")]
        public double CenterDuctWidth;

        [StructuresField("CenterDuctLength")]
        public double CenterDuctLength;

        [StructuresField("RightDuctDiamete")]
        public double RightDuctDiamete;

        [StructuresField("RightDuctLength")]
        public double RightDuctLength;

        [StructuresField("RightDuctRim")]
        public double RightDuctRim;

        [StructuresField("RightVerticalOffset")]
        public double RightVerticalOffset;

        [StructuresField("RightHorizoOffset")]
        public double RightHorizontalOffset;

        [StructuresField("NoOfSections")]
        public int NoOfSections;

        [StructuresField("LeftDuctHight")]
        public double LeftDuctHight;

        [StructuresField("LeftDuctLength")]
        public double LeftDuctLength;

        [StructuresField("LeftDuctWidth")]
        public double LeftDuctWidth;

        [StructuresField("LeftDuctRim")]
        public double LeftDuctRim;

        [StructuresField("LeftVerticalOffset")]
        public double LeftVerticalOffset;

        [StructuresField("LHorizoOffset")]
        public double LeftHorizontalOffset;

        [StructuresField("CenterStiffnerCount")]
        public int CenterStiffnerCount;

        [StructuresField("CenterStiffnerText")]
        public string CenterStiffnerText;

        [StructuresField("CentStifLeftOffset")]
        public double CenterStiffnerLeftOffset;

        [StructuresField("CentStifRightOffset")]
        public double CenterStiffnerRightOffset;

        [StructuresField("CentHorizStiffner")]
        public double CenterHorizaltalStiffner;

        [StructuresField("LeftStiffnerOffset")]
        public double LeftStiffnerOffset;

        [StructuresField("RightStiffnerOffset")]
        public double RightStiffnerOffset;

        [StructuresField("Material")]
        public string Material;

        [StructuresField("Profile")]
        public string Profile;

        [StructuresField("TopCapXoffset")]
        public double TopCapXoffset;

        [StructuresField("TopCapYoffset")]
        public double TopCapYoffset;

        [StructuresField("TopCapHight")]
        public double TopCapHight;

        [StructuresField("TopCapDiameter")]
        public double TopCapDiameter;

        [StructuresField("ChimnyLayout")]
        public int ChimnyLayout;



        [StructuresField("BtRadiC")]
        public double BtRadiC;
        [StructuresField("TpRadC")]
        public double TpRadC;
        [StructuresField("LenShell")]
        public string LenShell;
        [StructuresField("QtyCon")]
        public int QtyCon;
        [StructuresField("PltThkCon")]
        public double PltThkCon;
        [StructuresField("SegCon")]
        public int SegCon;
        [StructuresField("FnCon")]
        public string FnCon;
        [StructuresField("MtlCon")]
        public string MtlCon;

        [StructuresField("StudDiameter")]
        public double StudDiameter;
        [StructuresField("NoOfStuds")]
        public int NoOfStuds;
        [StructuresField("VirtDisbetwStuds")]
        public double VirtDisbetwStuds;
        [StructuresField("StudLength")]
        public double StudLength;
        [StructuresField("InnerPlateThickness")]
        public double InnerPlateThickness;
        [StructuresField("StudMaterial")]
        public string StudMaterial;
        [StructuresField("PlateMaterial")]
        public string PlateMaterial;

        [StructuresField("DontWantInsolation")]
        public string DontWantInsolation;

        [StructuresField("ChinmyStiffVerti")]
        public double ChinmyStiffVerti;
        [StructuresField("ChinStiffMate")]
        public string ChinmeyStiffMaterial;
        [StructuresField("ChinmyStiffProfile")]
        public string ChinmyStiffProfile;

        #endregion
    }
}
