using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;

using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;
using Tekla.Structures.Plugins;
using Point = Tekla.Structures.Geometry3d.Point;
using Vector = Tekla.Structures.Geometry3d.Vector;
using Line = Tekla.Structures.Geometry3d.Line;
using Position = Tekla.Structures.Model.Position;
using TeklaPH;
using System.Linq;
using Tekla.Structures.Model.Operations;
using static Tekla.Structures.Filtering.Categories.ReinforcingBarFilterExpressions;

namespace BottomDuctPlugin

{
    public class PluginData
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
        public double LenShell;
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
       


        #endregion
    }

    [Plugin("BottomDuctPlugin")]
    [PluginUserInterface("BottomDuctPlugin.MainForm")]
    public class BottomDuctPlugin : PluginBase
    {
        #region Fields
        private Model _Model;
        private PluginData _Data;
        //
        // Define variables for the field values.
        //
        
        private double _Thickness;
        private double _TopDuctLength;
        private double _TopDuctHight;
        private double _TopDuctWidth;
        private double _TopXOffset;
        private double _TopYOffset;

        private double _CenterDuctHight;
        private double _CenterDuctWidth;
        private double _CenterDuctLength;

        private double _RightDuctDiamete;
        private double _RightDuctLength;
        private double _RightDuctRim;
        private double _RightVerticalOffset;
        private double _RightHorizontalOffset;
        private int _NoOfSections;

        private double _LeftDuctHight;
        private double _LeftDuctLength;
        private double _LeftDuctWidth;
        private double _LeftDuctRim;
        private double _LeftVerticalOffset;
        private double _LeftHorizontalOffset;

        private int _CenterStiffnerCount;
        private string _CenterStiffnerText;
        private double _CenterStiffnerLeftOffset;
        private double _CenterStiffnerRightOffset;
        private double _CenterHorizaltalStiffner;
        private double _LeftStiffnerOffset;
        private double _RightStiffnerOffset;

        private string _Material;
        private string _Profile;

        private double _TopCapDiameter;
        private double _TopCapHight;
        private double _TopCapYoffset;
        private double _TopCapXoffset;

        private int _ChimnyLayout;

       
        private double _TopDiaC;
        private double _LenShell;
        private double _PltThkCon;
        private string _FinishChinmy;
        private int _SegCon;
        private int _QtyCon;
        private string _MtlCon;

        private double _StudDiameter;
        private int _NoOfStuds;
        private double _VirtDisbetwStuds;
        private double _StudLength;
        private double _InnerPlateThickness;
        private string _StudMaterial;
        private string _PlateMaterial;


        #endregion

        #region Properties
        private Model Model
        {
            get { return this._Model; }
            set { this._Model = value; }
        }

        private PluginData Data
        {
            get { return this._Data; }
            set { this._Data = value; }
        }
        #endregion

        #region Constructor
        public BottomDuctPlugin(PluginData data)
        {
            Model = new Model();
            Data = data;
        }
        #endregion

        #region Overrides
        public override List<InputDefinition> DefineInput()
        {
            //
            // This is an example for selecting two points; change this to suit your needs.

            //
            List<InputDefinition> PointList = new List<InputDefinition>();
            try
            {
                 PointList = new List<InputDefinition>();
                Picker Picker = new Picker();
                Point PickedPoint1 = Picker.PickPoint("Pick the Point");
                Point PickedPoint2 = Picker.PickPoint("Pick the Point for orientation");

                PointList.Add(new InputDefinition(PickedPoint1));
                PointList.Add(new InputDefinition(PickedPoint2));
            }
            catch (Exception ex)
            {
                Operation.DisplayPrompt(ex.Message);
            }
            return PointList;
        }

        public override bool Run(List<InputDefinition> Input)
        {
            Model model = new Model();
            try
            {
                GetValuesFromDialog();

                //
                // This is an example for selecting two points; change this to suit your needs.
                //
               
                Point origine = (Point)Input[0].GetInput();
                Point direction = (Point)Input[1].GetInput();

                Vector xAxis = new Vector(direction - origine);
                Vector yAxis = Vectors.FindPerpendicularVectorInXYPlane(xAxis);

                var coordinates = new CoordinateSystem(origine, xAxis, yAxis);

                TransformationPlane currentTransformation = model.GetWorkPlaneHandler().GetCurrentTransformationPlane();
                var newWorkPlane = new TransformationPlane(coordinates);
                // workPlaneHandler.SetCurrentTransformationPlane(newWorkPlane);
                model.GetWorkPlaneHandler().SetCurrentTransformationPlane(newWorkPlane);

                List<Point> points1 = new List<Point>(),
                   points2 = new List<Point>(),
                   points3 = new List<Point>();


                List<Part> CenterDuctParts = CenterDuctCreation(_CenterDuctHight,_CenterDuctWidth, _CenterDuctLength, out points1, out points2);
                double lefthight = _LeftDuctHight,
                    leftWidth = _LeftDuctWidth,
                    leftRim = _LeftDuctRim,
                    leftLength = _LeftDuctLength,
                    leftVerticalOffset = _LeftVerticalOffset,
                    leftHorizontalOffset = _LeftHorizontalOffset;
                var ts = LeftDuctRimCreation(lefthight, leftWidth, leftRim, leftLength, leftVerticalOffset, leftHorizontalOffset, out points3);
                LeftDuctCoveringCreation(points1, points3);
                TopDuctCreation(_TopDuctHight, _TopDuctWidth, _TopDuctLength, _CenterDuctHight, CenterDuctParts[3] , out List<Point> pointsForTopCap);
                Part rightRim = RightDuctRimCreation(_RightDuctDiamete, _RightDuctRim, _RightDuctLength, _CenterDuctLength, _CenterDuctHight);
                RightDuctCreation(points2, _RightDuctDiamete, _RightDuctRim, _RightDuctLength, _CenterDuctLength, _CenterDuctHight, rightRim, out List<List<Point>> stiffnerpoints);
                RightStiffnerCreation(stiffnerpoints, rightRim);
                CenterDuctStiffnersCreation(_CenterDuctHight, _CenterDuctLength, _CenterDuctWidth, _TopDuctHight, _TopDuctLength, _TopDuctWidth, _Thickness);
                LeftStiffnerCreation(points1, points3);
                Point chinmyOrigin = new Point(_TopCapXoffset, _TopCapYoffset, _CenterDuctHight + _TopDuctHight + _TopCapHight);
                TopCapDuctCreation(pointsForTopCap, _TopCapDiameter , chinmyOrigin, out stiffnerpoints, "4",out List<Point> capTopQuadeantsPoints);
                List<Part> capHorizontalStiffners = TopHorizontalStiffneerCreation(pointsForTopCap);
                VerticalChinmyStiffners(capTopQuadeantsPoints, chinmyOrigin, _LenShell,(_ChimnyLayout == 1)? _TopDiaC : _TopCapDiameter, capHorizontalStiffners);


                List<ControlArc> arcs1 = new List<ControlArc>(),
                    arcs2 = new List<ControlArc>();
                ChimnyCreation(chinmyOrigin, _PltThkCon, _TopCapDiameter, _TopDiaC, _MtlCon,"99",out arcs1);


                StudsForChinmyCreation(chinmyOrigin, _TopCapDiameter / 2,(_ChimnyLayout == 1)? _TopDiaC / 2 : _TopCapDiameter / 2, _NoOfStuds, _LenShell,_VirtDisbetwStuds,_StudLength);

                ChimnyCreation(chinmyOrigin, _InnerPlateThickness, _TopCapDiameter - (_StudLength + _InnerPlateThickness) * 2, _TopDiaC - (_StudLength + _InnerPlateThickness) * 2, _PlateMaterial,"8",out arcs2);
                TopCapDuctCreation(pointsForTopCap, _TopCapDiameter - ((_StudLength + _InnerPlateThickness) * 2), chinmyOrigin, out stiffnerpoints, "8",out  capTopQuadeantsPoints);
                ChinmyCap(arcs1, arcs2);



                model.GetWorkPlaneHandler().SetCurrentTransformationPlane(currentTransformation);

                
                //
                // Write your code here; better yet, create private methods and call them from here.
                //
            }
            catch (Exception Exc)
            {
               //MessageBox.Show(Exc.ToString());
               Operation.DisplayPrompt(Exc.Message);
            }

            return true;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Gets the values from the dialog and sets the default values if needed
        /// </summary>
        private void GetValuesFromDialog()
        {


            _Thickness = Data.Thickness;
            _TopDuctLength = Data.TopDuctLength;
            _TopDuctHight = Data.TopDuctHight;
            _TopDuctWidth = Data.TopDuctWidth;
            _TopXOffset = Data.TopXOffset;
            _TopYOffset = Data.TopYOffset;

            _CenterDuctHight = Data.CenterDuctHight;
            _CenterDuctWidth = Data.CenterDuctWidth;
            _CenterDuctLength = Data.CenterDuctLength;

            _RightDuctDiamete = Data.RightDuctDiamete;
            _RightDuctLength = Data.RightDuctLength;
            _RightDuctRim = Data.RightDuctRim;
            _RightVerticalOffset = Data.RightVerticalOffset;
            _RightHorizontalOffset = Data.RightHorizontalOffset;
            _NoOfSections = Data.NoOfSections;

            _LeftDuctHight = Data.LeftDuctHight;
            _LeftDuctLength = Data.LeftDuctLength;
            _LeftDuctWidth = Data.LeftDuctWidth;
            _LeftDuctRim = Data.LeftDuctRim;
            _LeftVerticalOffset = Data.LeftVerticalOffset;
            _LeftHorizontalOffset = Data.LeftHorizontalOffset;

            _CenterStiffnerCount = Data.CenterStiffnerCount;
            _CenterStiffnerText = Data.CenterStiffnerText;
            _CenterStiffnerLeftOffset = Data.CenterStiffnerLeftOffset;
            _CenterStiffnerRightOffset = Data.CenterStiffnerRightOffset;
            _CenterHorizaltalStiffner = Data.CenterHorizaltalStiffner;
            _LeftStiffnerOffset = Data.LeftStiffnerOffset;
            _RightStiffnerOffset = Data.RightStiffnerOffset;

            _Material = Data.Material;
            _Profile = Data.Profile;

            _TopCapDiameter = Data.TopCapDiameter;
            _TopCapHight = Data.TopCapHight;
            _TopCapXoffset = Data.TopCapXoffset;
            _TopCapYoffset = Data.TopCapYoffset;

            _ChimnyLayout = Data.ChimnyLayout;

            _TopDiaC = Data.TpRadC;
            _LenShell = Data.LenShell;
            _PltThkCon = Data.PltThkCon;
            _SegCon = Data.SegCon;
            _QtyCon = Data.QtyCon;
            _FinishChinmy = Data.FnCon;
            _MtlCon = Data.MtlCon;

            

            if (IsDefaultValue(_Thickness))
                _Thickness = 20;
            if (IsDefaultValue(_TopDuctLength))
                _TopDuctLength = 6000;
            if (IsDefaultValue(_TopDuctHight))
                _TopDuctHight = 3000;
            if (IsDefaultValue(_TopDuctWidth))
                _TopDuctWidth = 6000;
            if (IsDefaultValue(_TopXOffset))
                _TopXOffset = 0;
            if (IsDefaultValue(_TopYOffset))
                _TopYOffset = 0;
            if (IsDefaultValue(_CenterDuctHight))
                _CenterDuctHight = 10000;
            if (IsDefaultValue(_CenterDuctWidth))
                _CenterDuctWidth = 9000;
            if (IsDefaultValue(_CenterDuctLength))
                _CenterDuctLength = 10000;
            if (IsDefaultValue(_RightDuctDiamete))
                _RightDuctDiamete = 7000;
            if (IsDefaultValue(_RightDuctLength))
                _RightDuctLength = 7000;
            if (IsDefaultValue(_RightDuctRim))
                _RightDuctRim = 500;
            if (IsDefaultValue(_RightVerticalOffset))
                _RightVerticalOffset = 0;
            if (IsDefaultValue(_RightHorizontalOffset))
                _RightHorizontalOffset = 0;
            if (IsDefaultValue(_NoOfSections))
                _NoOfSections = 12;
            if (IsDefaultValue(_LeftDuctHight))
                _LeftDuctHight = 8000;
            if (IsDefaultValue(_LeftDuctLength))
                _LeftDuctLength = 7000;
            if (IsDefaultValue(_LeftDuctWidth))
                _LeftDuctWidth = 8000;
            if (IsDefaultValue(_LeftDuctRim))
                _LeftDuctRim = 500;
            if (IsDefaultValue(_LeftVerticalOffset))
                _LeftVerticalOffset = 2000;
            if (IsDefaultValue(_LeftHorizontalOffset))
                _LeftHorizontalOffset = 0;
            if (IsDefaultValue(_CenterStiffnerCount))
                _CenterStiffnerCount = 5;
            if (IsDefaultValue(_CenterStiffnerText))
                _CenterStiffnerText = "2000.0 2000.0 2000.0";
            if (IsDefaultValue(_CenterStiffnerLeftOffset))
                _CenterStiffnerLeftOffset = 1000;
            if (IsDefaultValue(_CenterStiffnerRightOffset))
                _CenterStiffnerRightOffset = 1000;
            if (IsDefaultValue(_CenterHorizaltalStiffner))
                _CenterHorizaltalStiffner = 3000;
            if (IsDefaultValue(_LeftStiffnerOffset))
                _LeftStiffnerOffset = 4000;
            if (IsDefaultValue(_RightStiffnerOffset))
                _RightStiffnerOffset = 4000;
            if (IsDefaultValue(_Material))
                _Material = "43A";
            if (IsDefaultValue(_Profile))
                _Profile = "ISHB300";
            if (IsDefaultValue(_TopCapDiameter))
                _TopCapDiameter = 10000;
            if (IsDefaultValue(_TopCapHight))
                _TopCapHight = 3000;
            if (IsDefaultValue(_TopCapXoffset))
                _TopCapXoffset = 0;
            if (IsDefaultValue(_TopCapYoffset))
                _TopCapYoffset = 0;
            if (IsDefaultValue(_ChimnyLayout))
                _ChimnyLayout = 0;

            if (IsDefaultValue(_TopDiaC))
            {
                _TopDiaC = 8000;
            }
            if (IsDefaultValue(_LenShell))
            {
                _LenShell = 20000;
            }

            if (IsDefaultValue(_PltThkCon))
            {
                _PltThkCon = 20;
            }
            if (IsDefaultValue(_SegCon))
            {
                _SegCon = 4;

            }
            if (IsDefaultValue(_QtyCon))
            {
                _QtyCon = 5;
            }
            if (IsDefaultValue(_FinishChinmy))
            {
                _FinishChinmy = "STRIDELY";
            }
            if (IsDefaultValue(_MtlCon))
            {
                _MtlCon = "Steel_Undefined";
            }

            _StudDiameter = Data.StudDiameter;
            _NoOfStuds = Data.NoOfStuds;
            _VirtDisbetwStuds = Data.VirtDisbetwStuds;
            _StudLength = Data.StudLength;
            _InnerPlateThickness = Data.InnerPlateThickness;
            _StudMaterial = Data.StudMaterial;
            _PlateMaterial = Data.PlateMaterial;

            if (IsDefaultValue(_StudDiameter))
            {
                _StudDiameter = 30;
            }
            if (IsDefaultValue(_NoOfStuds))
            {
                _NoOfStuds = 60;
            }
            if (IsDefaultValue(_VirtDisbetwStuds))
            {
                _VirtDisbetwStuds = 1000;
            }
            if (IsDefaultValue(_StudLength))
            {
                _StudLength = 300;
            }
            if (IsDefaultValue(_InnerPlateThickness))
            {
                _InnerPlateThickness = 10;
            }
            if (IsDefaultValue(_StudMaterial))
            {
                _StudMaterial = "Insulation";
            }
            if (IsDefaultValue(_PlateMaterial))
            {
                _PlateMaterial = "Insulation";
            }



        }

        private List<Part> CenterDuctCreation(double hight, double width, double length, out List<Point> points1, out List<Point> points2)
        {
            points1 = new List<Point>();
            points2 = new List<Point>();
            Point p1 = new Point(length / 2, width / 2, 0),
                p2 = new Point(-length / 2, width / 2, 0),
                p3 = new Point(-length / 2, -width / 2, 0),
                p4 = new Point(length / 2, -width / 2, 0);
            ArrayList platePoints = new ArrayList();
            points1.Add(p2);
            points1.Add(p3);
            points2.Add(p1);
            points2.Add(p4);
            foreach (Point p in new List<Point> { p1, p2, p3, p4 })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);
                ControlPoint controlPoint = new ControlPoint(p);
                controlPoint.Insert();
            }
            ContourPlate cp = new ContourPlate();
            cp.Contour.ContourPoints = platePoints;
            cp.Profile.ProfileString = "PL" + _Thickness ;
            cp.Material.MaterialString = _Material;
            cp.Class = "4";
            cp.Position.Depth = Position.DepthEnum.BEHIND;
            bool f = cp.Insert();

            p1 = new Point(length / 2, width / 2, 0);
            p2 = new Point(-length / 2, width / 2, 0);
            p3 = new Point(-length / 2, width / 2, hight);
            p4 = new Point(length / 2, width / 2, hight);
            platePoints = new ArrayList();
            foreach (Point p in new List<Point> { p1, p2, p3, p4 })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);

            }
            ContourPlate cp1 = new ContourPlate();
            cp1.Contour.ContourPoints = platePoints;
            cp1.Profile.ProfileString = "PL" + _Thickness;
            cp1.Material.MaterialString = _Material;
            cp1.Class = "4";
            cp1.Position.Depth = Position.DepthEnum.FRONT;
            f = cp1.Insert();

            p1 = new Point(-length / 2, -width / 2, 0);
            p2 = new Point(length / 2, -width / 2, 0);
            p3 = new Point(length / 2, -width / 2, hight);
            p4 = new Point(-length / 2, -width / 2, hight);
            platePoints = new ArrayList();
            foreach (Point p in new List<Point> { p1, p2, p3, p4 })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);

            }
            ContourPlate cp2 = new ContourPlate();
            cp2.Contour.ContourPoints = platePoints;
            cp2.Profile.ProfileString = "PL" + _Thickness;
            cp2.Material.MaterialString = _Material;
            cp2.Class = "4";
            cp2.Position.Depth = Position.DepthEnum.FRONT;
            f = cp2.Insert();

            p1 = new Point(length / 2, width / 2, hight);
            p2 = new Point(-length / 2, width / 2, hight);
            p3 = new Point(-length / 2, -width / 2, hight);
            p4 = new Point(length / 2, -width / 2, hight);
            platePoints = new ArrayList();
            points1.Add(p3);
            points1.Add(p2);
            points2.Add(p4);
            points2.Add(p1);
            foreach (Point p in new List<Point> { p1, p2, p3, p4 })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);
                ControlPoint controlPoint = new ControlPoint(p);
                controlPoint.Insert();
            }
            ContourPlate cp3 = new ContourPlate();
            cp3.Contour.ContourPoints = platePoints;
            cp3.Profile.ProfileString = "PL" + _Thickness;
            cp3.Material.MaterialString = _Material;
            cp3.Class = "4";
            cp3.Position.Depth = Position.DepthEnum.FRONT;
            f = cp3.Insert();

            return new List<Part> { cp, cp1, cp2, cp3 };
        }
        private List<Part> LeftDuctRimCreation(double hight, double width, double rim, double length1, double offsetX, double offsetY, out List<Point> points)
        {
            double length = length1 - rim;
            double centerlength = _CenterDuctLength;
            points = new List<Point>();
            Point p1 = new Point(-(centerlength / 2 + length), width / 2 + offsetY, offsetX),
                p2 = new Point(-(centerlength / 2 + length1), width / 2 + offsetY, offsetX),
                p3 = new Point(-(centerlength / 2 + length1), -width / 2 + offsetY, offsetX),
                p4 = new Point(-(centerlength / 2 + length), -width / 2 + offsetY, offsetX);
            ArrayList platePoints = new ArrayList();
            points.Add(p1);
            points.Add(p4);
            foreach (Point p in new List<Point> { p1, p2, p3, p4 })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);
                //ControlPoint controlPoint = new ControlPoint(p);
                //controlPoint.Insert();
            }
            ContourPlate cp = new ContourPlate();
            cp.Contour.ContourPoints = platePoints;
            cp.Profile.ProfileString = "PL" + _Thickness;
            cp.Material.MaterialString = _Material;
            cp.Class = "4";
            cp.Position.Depth = Position.DepthEnum.BEHIND;
            bool f = cp.Insert();

            p1 = new Point(-(length + centerlength / 2), width / 2 + offsetY, offsetX);
            p2 = new Point(-(length1 + centerlength / 2), width / 2 + offsetY, offsetX);
            p3 = new Point(-(length1 + centerlength / 2), width / 2 + offsetY, offsetX + hight);
            p4 = new Point(-(length + centerlength / 2), width / 2 + offsetY, offsetX + hight);
            platePoints = new ArrayList();
            foreach (Point p in new List<Point> { p1, p2, p3, p4 })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);

            }
            ContourPlate cp1 = new ContourPlate();
            cp1.Contour.ContourPoints = platePoints;
            cp1.Profile.ProfileString = "PL" + _Thickness;
            cp1.Material.MaterialString = _Material;
            cp1.Class = "4";
            cp1.Position.Depth = Position.DepthEnum.FRONT;
            f = cp1.Insert();

            p1 = new Point(-(length + centerlength / 2), -width / 2 + offsetY, offsetX);
            p2 = new Point(-(length1 + centerlength / 2), -width / 2 + offsetY, offsetX);
            p3 = new Point(-(length1 + centerlength / 2), -width / 2 + offsetY, offsetX + hight);
            p4 = new Point(-(length + centerlength / 2), -width / 2 + offsetY, offsetX + hight);
            platePoints = new ArrayList();
            foreach (Point p in new List<Point> { p1, p2, p3, p4 })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);

            }
            ContourPlate cp2 = new ContourPlate();
            cp2.Contour.ContourPoints = platePoints;
            cp2.Profile.ProfileString = "PL" + _Thickness;
            cp2.Material.MaterialString = _Material;
            cp2.Class = "4";
            cp2.Position.Depth = Position.DepthEnum.BEHIND;
            f = cp2.Insert();

            p1 = new Point(-(length + centerlength / 2), width / 2 + offsetY, offsetX + hight);
            p2 = new Point(-(length1 + centerlength / 2), width / 2 + offsetY, offsetX + hight);
            p3 = new Point(-(length1 + centerlength / 2), -width / 2 + offsetY, offsetX + hight);
            p4 = new Point(-(length + centerlength / 2), -width / 2 + offsetY, offsetX + hight);
            platePoints = new ArrayList();
            points.Add(p4);
            points.Add(p1);
            foreach (Point p in new List<Point> { p1, p2, p3, p4 })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);
                //ControlPoint controlPoint = new ControlPoint(p);
                //controlPoint.Insert();
            }
            ContourPlate cp3 = new ContourPlate();
            cp3.Contour.ContourPoints = platePoints;
            cp3.Profile.ProfileString = "PL" + _Thickness;
            cp3.Material.MaterialString = _Material;
            cp3.Class = "4";
            cp3.Position.Depth = Position.DepthEnum.FRONT;
            f = cp3.Insert();

            return new List<Part> { cp, cp1, cp2, cp3 };
        }
        private List<Part> LeftDuctCoveringCreation(List<Point> points1, List<Point> points2)
        {
            ArrayList platePoints = new ArrayList();
            foreach (Point p in new List<Point> { points1[0], points1[1], points2[1], points2[0] })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);
                //ControlPoint controlPoint = new ControlPoint(p);
                //controlPoint.Insert();
            }
            ContourPlate cp = new ContourPlate();
            cp.Contour.ContourPoints = platePoints;
            cp.Profile.ProfileString = "PL" + _Thickness;
            cp.Material.MaterialString = _Material;
            cp.Class = "4";
            cp.Position.Depth = Position.DepthEnum.BEHIND;
            bool f = cp.Insert();

            platePoints = new ArrayList();
            foreach (Point p in new List<Point> { points1[2], points1[1], points2[1], points2[2] })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);
                //ControlPoint controlPoint = new ControlPoint(p);
                //controlPoint.Insert();
            }
            ContourPlate cp1 = new ContourPlate();
            cp1.Contour.ContourPoints = platePoints;
            cp1.Profile.ProfileString = "PL" + _Thickness;
            cp1.Material.MaterialString = _Material;
            cp1.Class = "4";
            cp1.Position.Depth = Position.DepthEnum.BEHIND;
            f = cp1.Insert();

            platePoints = new ArrayList();
            foreach (Point p in new List<Point> { points1[2], points1[3], points2[3], points2[2] })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);
                //ControlPoint controlPoint = new ControlPoint(p);
                //controlPoint.Insert();
            }
            ContourPlate cp2 = new ContourPlate();
            cp2.Contour.ContourPoints = platePoints;
            cp2.Profile.ProfileString = "PL" + _Thickness;
            cp2.Material.MaterialString = _Material;
            cp2.Class = "4";
            cp2.Position.Depth = Position.DepthEnum.FRONT;
            f = cp2.Insert();

            platePoints = new ArrayList();
            foreach (Point p in new List<Point> { points1[0], points1[3], points2[3], points2[0] })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);
                //ControlPoint controlPoint = new ControlPoint(p);
                //controlPoint.Insert();
            }
            ContourPlate cp3 = new ContourPlate();
            cp3.Contour.ContourPoints = platePoints;
            cp3.Profile.ProfileString = "PL" + _Thickness;
            cp3.Material.MaterialString = _Material;
            cp3.Class = "4";
            cp3.Position.Depth = Position.DepthEnum.BEHIND;
            f = cp3.Insert();
            return new List<Part> { cp, cp1, cp2, cp3 };
        }
        private List<Part> TopDuctCreation(double hight, double width, double length, double centerHight, Part part,out List<Point> pointsForTopCap)
        {
            double topXOffset = _TopXOffset,
                topYOffset = _TopYOffset;
            double centerlength = _CenterDuctLength;
            Point p1 = new Point(length / 2 + topXOffset, width / 2 + topYOffset, centerHight),
                p2 = new Point(-length / 2 + topXOffset, width / 2 + topYOffset, centerHight),
                p3 = new Point(-length / 2 + topXOffset, -width / 2 + topYOffset, centerHight),
                p4 = new Point(length / 2 + topXOffset, -width / 2 + topYOffset, centerHight),
                p5 = new Point(length / 2 + topXOffset, width / 2 + topYOffset, centerHight + hight),
                p6 = new Point(-length / 2 + topXOffset, width / 2 + topYOffset, centerHight + hight),
                p7 = new Point(-length / 2 + topXOffset, -width / 2 + topYOffset, centerHight + hight),
                p8 = new Point(length / 2 + topXOffset, -width / 2 + topYOffset, centerHight + hight);
            pointsForTopCap = new List<Point> {  p8,p7, p6, p5 };


            ArrayList platePoints = new ArrayList();

            foreach (Point p in new List<Point> { p1, p2, p3, p4 })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);
                //ControlPoint controlPoint = new ControlPoint(p);
                //controlPoint.Insert();
            }
            ContourPlate cp = new ContourPlate();
            cp.Contour.ContourPoints = platePoints;
            cp.Profile.ProfileString = "PL" + _Thickness*2.5;
            cp.Material.MaterialString = _Material;
            cp.Class = BooleanPart.BooleanOperativeClassName;
            cp.Position.Depth = Position.DepthEnum.MIDDLE;
            bool f = cp.Insert();
            BooleanPart boolpart1 = new BooleanPart();
            boolpart1.Father = part;
            boolpart1.SetOperativePart(cp);

            if (!boolpart1.Insert())
                Console.WriteLine("Insert failed!");
            cp.Delete();


            platePoints = new ArrayList();
            foreach (Point p in new List<Point> { p1, p2, p6, p5 })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);
                //ControlPoint controlPoint = new ControlPoint(p);
                //controlPoint.Insert();
            }
            ContourPlate cp1 = new ContourPlate();
            cp1.Contour.ContourPoints = platePoints;
            cp1.Profile.ProfileString = "PL" + _Thickness;
            cp1.Material.MaterialString = _Material;
            cp1.Class = "4";
            cp1.Position.Depth = Position.DepthEnum.FRONT;
            f = cp1.Insert();

            platePoints = new ArrayList();
            foreach (Point p in new List<Point> { p2, p3, p7, p6 })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);
                //ControlPoint controlPoint = new ControlPoint(p);
                //controlPoint.Insert();
            }
            ContourPlate cp2 = new ContourPlate();
            cp2.Contour.ContourPoints = platePoints;
            cp2.Profile.ProfileString = "PL" + _Thickness;
            cp2.Material.MaterialString = _Material;
            cp2.Class = "4";
            cp2.Position.Depth = Position.DepthEnum.FRONT;
            f = cp2.Insert();

            platePoints = new ArrayList();
            foreach (Point p in new List<Point> { p3, p4, p8, p7 })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);
                //ControlPoint controlPoint = new ControlPoint(p);
                //controlPoint.Insert();
            }
            ContourPlate cp3 = new ContourPlate();
            cp3.Contour.ContourPoints = platePoints;
            cp3.Profile.ProfileString = "PL" + _Thickness;
            cp3.Material.MaterialString = _Material;
            cp3.Class = "4";
            cp3.Position.Depth = Position.DepthEnum.FRONT;
            f = cp3.Insert();

            platePoints = new ArrayList();
            foreach (Point p in new List<Point> { p1, p4, p8, p5 })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);
                //ControlPoint controlPoint = new ControlPoint(p);
                //controlPoint.Insert();
            }
            ContourPlate cp4 = new ContourPlate();
            cp4.Contour.ContourPoints = platePoints;
            cp4.Profile.ProfileString = "PL" + _Thickness;
            cp4.Material.MaterialString = _Material;
            cp4.Class = "4";
            cp4.Position.Depth = Position.DepthEnum.BEHIND;
            f = cp4.Insert();

            return new List<Part> { cp4, cp1, cp2, cp3 };
        }
        private Part RightDuctRimCreation(double diameter, double rightRim, double rightLength, double centerLength, double centerhight)
        {
            Point center = new Point(
                centerLength / 2 + rightLength - rightRim / 2,
                0,
                centerhight / 2);

            Beam beam = new Beam();
            beam.StartPoint = new Point(
                centerLength / 2 + rightLength - rightRim,
                0 + _RightHorizontalOffset,
                (centerhight / 2) + _RightVerticalOffset);
            beam.EndPoint = new Point(
                centerLength / 2 + rightLength,
                0 + _RightHorizontalOffset,
                (centerhight / 2) + _RightVerticalOffset);
            beam.Profile.ProfileString = "O" + (diameter + _Thickness * 2) + "*" + _Thickness;
            beam.Finish = "PAINT";
            beam.Position.Depth = Position.DepthEnum.MIDDLE;
            beam.Position.Plane = Position.PlaneEnum.MIDDLE;
            beam.Position.Rotation = Position.RotationEnum.FRONT;
            beam.StartPointOffset = new Offset();
            beam.EndPointOffset = new Offset();
            beam.Insert();
            return beam;
        }
        private List<Part> RightDuctCreation(List<Point> points, double diameter, double rightRim, double rightLength, double centerLength, double centerhight, Part part, out List<List<Point>> stiffnerPoints)
        {
            Point p1 = new Point(
                centerLength / 2 + rightLength - rightRim,
                0 + _RightHorizontalOffset,
                ((centerhight / 2 + diameter / 2) + _RightVerticalOffset)),
                p2 = new Point(
                    centerLength / 2 + rightLength - rightRim,
                0 + _RightHorizontalOffset,
                (centerhight / 2 - diameter / 2) + _RightVerticalOffset),
                p3 = new Point(
                    centerLength / 2 + rightLength - rightRim,
                diameter / 2 + _RightHorizontalOffset,
                (centerhight / 2) + _RightVerticalOffset),
                p4 = new Point(
                    centerLength / 2 + rightLength - rightRim,
                -diameter / 2 + _RightHorizontalOffset,
                (centerhight / 2) + _RightVerticalOffset);
            ArrayList platePoints = new ArrayList();
            foreach (Point p in new List<Point> { p1, points[2], points[3] })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);

            }
            ContourPlate cp = new ContourPlate();
            cp.Contour.ContourPoints = platePoints;
            cp.Profile.ProfileString = "PL" + _Thickness;
            cp.Material.MaterialString = _Material;
            cp.Class = "4";
            cp.Position.Depth = Position.DepthEnum.FRONT;
            bool f = cp.Insert();

            platePoints = new ArrayList();
            foreach (Point p in new List<Point> { p2, points[0], points[1] })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);

            }
            ContourPlate cp1 = new ContourPlate();
            cp1.Contour.ContourPoints = platePoints;
            cp1.Profile.ProfileString = "PL" + _Thickness;
            cp1.Material.MaterialString = _Material;
            cp1.Class = "4";
            cp1.Position.Depth = Position.DepthEnum.BEHIND;
            f = cp1.Insert();
            platePoints.Clear();
            foreach (Point p in new List<Point> { p3, points[0], points[3] })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);

            }
            ContourPlate cp2 = new ContourPlate();
            cp2.Contour.ContourPoints = platePoints;
            cp2.Profile.ProfileString = "PL" + _Thickness;
            cp2.Material.MaterialString = _Material;
            cp2.Class = "4";
            cp2.Position.Depth = Position.DepthEnum.FRONT;
            f = cp2.Insert();

            platePoints.Clear();
            foreach (Point p in new List<Point> { p4, points[1], points[2] })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);

            }
            ContourPlate cp3 = new ContourPlate();
            cp3.Contour.ContourPoints = platePoints;
            cp3.Profile.ProfileString = "PL" + _Thickness;
            cp3.Material.MaterialString = _Material;
            cp3.Class = "4";
            cp3.Position.Depth = Position.DepthEnum.BEHIND;
            f = cp3.Insert();

            List<Part> parts = new List<Part> { cp, cp1, cp2, cp3 };
            Beam beam = part as Beam;
            List<List<Point>> holdPointsSets = GenerateCirclePointsYZ(beam.StartPoint, diameter / 2, _NoOfSections);

            stiffnerPoints = new List<List<Point>>();
            GeometricPlane gp = new GeometricPlane(new Point(centerLength / 2 + _RightStiffnerOffset, 0, 0), new Vector(1, 0, 0));
            int n = 0;
            foreach (Point p in new List<Point> { points[3], points[2], points[1], points[0] })
            {
                List<Point> newPoints = new List<Point>();
                Line line = new Line(p, holdPointsSets[n][0]);
                newPoints.Add(Intersection.LineToPlane(line, gp));
                for (int i = 0; i < holdPointsSets[n].Count - 1; i++)
                {
                    line = new Line(p, holdPointsSets[n][i + 1]);
                    newPoints.Add(Intersection.LineToPlane(line, gp));
                    platePoints.Clear();
                    foreach (Point po in new List<Point> { p, holdPointsSets[n][i], holdPointsSets[n][i + 1] })
                    {
                        ContourPoint cPoints = new ContourPoint(po, new Chamfer());
                        platePoints.Add(cPoints);

                    }
                    ContourPlate cp4 = new ContourPlate();
                    cp4.Contour.ContourPoints = platePoints;
                    cp4.Profile.ProfileString = "PL" + _Thickness;
                    cp4.Material.MaterialString = _Material;
                    cp4.Class = "4";
                    cp4.Position.Depth = ((new List<Point> { points[3], points[2] }).Contains(p)) ? Position.DepthEnum.FRONT : Position.DepthEnum.BEHIND;
                    f = cp4.Insert();
                    parts.Add(cp4);
                }
                stiffnerPoints.Add(newPoints);
                n++;
            }

            return parts;
        }
        private List<Part> CenterDuctStiffnersCreation(double centerHight, double centerLength, double centerWidth, double topHight, double topLength, double topWidth, double thickness)
        {
            double rightOffset = _CenterStiffnerRightOffset,
                leftOffset = _CenterStiffnerLeftOffset,
                topXOffset = _TopXOffset,
                topYOffset = _TopYOffset;
            int count = _CenterStiffnerCount;
            bool falgRight = false;
            bool falgLeft = false;
            List<PolyBeam> polyBeams = new List<PolyBeam>();
            if ((centerLength / 2 - (topLength / 2 + topXOffset) - rightOffset) > 0)
            {
                Point p1 = new Point(
                    centerLength / 2 - rightOffset,
                    centerWidth / 2 + thickness,
                    0);
                Point p2 = new Point(
                     centerLength / 2 - rightOffset,
                    centerWidth / 2 + thickness,
                    centerHight + thickness);
                Point p3 = new Point(
                     centerLength / 2 - rightOffset,
                   -(centerWidth / 2 + thickness),
                    centerHight + thickness);
                Point p4 = new Point(
                     centerLength / 2 - rightOffset,
                    -(centerWidth / 2 + thickness),
                    0);
                ArrayList platePoints = new ArrayList();
                foreach (Point p in new List<Point> { p1, p2, p3, p4 })
                {
                    ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                    platePoints.Add(cPoints);
                    //ControlPoint controlPoint = new ControlPoint(p);
                    //controlPoint.Insert();
                }
                PolyBeam polyBeam = new PolyBeam();

                polyBeam.Contour.ContourPoints = platePoints;

                polyBeam.Profile.ProfileString = _Profile;
                polyBeam.Material.MaterialString = _Material;
                polyBeam.Finish = "PAINT";
                polyBeam.Position.Depth = Position.DepthEnum.MIDDLE;
                polyBeam.Position.Plane = Position.PlaneEnum.LEFT;
                polyBeam.Position.Rotation = Position.RotationEnum.FRONT;
                polyBeam.Class = "11";
                bool Result = false;
                Result = polyBeam.Insert();
                polyBeams.Add(polyBeam);
                falgRight = true;
            }
            double d = (centerLength / 2 - (topLength / 2 - topXOffset) - leftOffset);
            if ((centerLength / 2 - (topLength / 2 - topXOffset) - leftOffset) > 0)
            {
                Point p1 = new Point(
                    -(centerLength / 2 - leftOffset),
                    centerWidth / 2 + thickness,
                    0);
                Point p2 = new Point(
                     -(centerLength / 2 - leftOffset),
                    centerWidth / 2 + thickness,
                    centerHight + thickness);
                Point p3 = new Point(
                    -(centerLength / 2 - leftOffset),
                    -(centerWidth / 2 + thickness),
                    centerHight + thickness);
                Point p4 = new Point(
                     -(centerLength / 2 - leftOffset),
                    -(centerWidth / 2 + thickness),
                    0);
                ArrayList platePoints = new ArrayList();
                foreach (Point p in new List<Point> { p1, p2, p3, p4 })
                {
                    ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                    platePoints.Add(cPoints);
                    //ControlPoint controlPoint = new ControlPoint(p);
                    //controlPoint.Insert();
                }
                PolyBeam polyBeam = new PolyBeam();

                polyBeam.Contour.ContourPoints = platePoints;

                polyBeam.Profile.ProfileString = _Profile;
                polyBeam.Material.MaterialString = _Material;
                polyBeam.Finish = "PAINT";
                polyBeam.Position.Depth = Position.DepthEnum.MIDDLE;
                polyBeam.Position.Plane = Position.PlaneEnum.LEFT;
                polyBeam.Position.Rotation = Position.RotationEnum.FRONT;
                polyBeam.Class = "11";
                bool Result = false;

                Result = polyBeam.Insert();
                polyBeams.Add(polyBeam);
                falgLeft = true;
            }
            List<Part> parts = new List<Part>();


            if (count > 2)
            {
                double partWidth = 0.0;
                if (polyBeams.Count != 0)
                { (polyBeams[0] as ModelObject).GetReportProperty("WIDTH", ref partWidth); }
                double hold = -(centerLength / 2 - leftOffset);
                List<double> positions = Input.InputConverter(_CenterStiffnerText);
                double center = (rightOffset - leftOffset) / 2;

                Point p1 = new Point(
                    0,
                    centerWidth / 2 + thickness + topYOffset,
                    0);
                Point p2 = new Point(
                     0,
                    centerWidth / 2 + thickness + topYOffset,
                    centerHight + thickness);
                Point p3 = new Point(
                    0,
                    topWidth / 2 + thickness + topYOffset,
                    centerHight + thickness);
                Point p4 = new Point(
                    0,
                    topWidth / 2 + thickness + topYOffset,
                    centerHight + topHight - partWidth);
                Point p5 = new Point(
                    0,
                    -(centerWidth / 2 + thickness - topYOffset),
                    0);
                Point p6 = new Point(
                     0,
                    -(centerWidth / 2 + thickness - topYOffset),
                    centerHight + thickness);
                Point p7 = new Point(
                    0,
                    -(topWidth / 2 + thickness - topYOffset),
                    centerHight + thickness);
                Point p8 = new Point(
                    0,
                    -(topWidth / 2 + thickness - topYOffset),
                    centerHight + topHight - partWidth);
                double total = 0;
                int i = 1;

                foreach (double x in positions)
                {
                    total += x;
                    if (total < (centerLength - rightOffset - leftOffset) && i <= count - 2)
                    {
                        hold += x;
                        Point origin = new Point(hold, 0, 0);
                        GeometricPlane gp = new GeometricPlane(origin, new Vector(1, 0, 0));

                        ArrayList platePoints = new ArrayList();
                        foreach (Point p in new List<Point> { p1, p2, p3, p4 })
                        {
                            Point po = Projection.PointToPlane(p, gp);
                            ContourPoint cPoints = new ContourPoint(po, new Chamfer());
                            platePoints.Add(cPoints);
                            //ControlPoint controlPoint = new ControlPoint(p);
                            //controlPoint.Insert();
                        }
                        PolyBeam polyBeam = new PolyBeam();

                        polyBeam.Contour.ContourPoints = platePoints;

                        polyBeam.Profile.ProfileString = _Profile;
                        polyBeam.Material.MaterialString = _Material;
                        polyBeam.Finish = "PAINT";
                        polyBeam.Position.Depth = Position.DepthEnum.MIDDLE;
                        polyBeam.Position.Plane = Position.PlaneEnum.LEFT;
                        polyBeam.Position.Rotation = Position.RotationEnum.FRONT;
                        polyBeam.Class = "11";
                        bool Result = false;
                        Result = polyBeam.Insert();

                        parts.Add(polyBeam);

                        platePoints = new ArrayList();
                        foreach (Point p in new List<Point> { p5, p6, p7, p8 })
                        {
                            Point po = Projection.PointToPlane(p, gp);
                            ContourPoint cPoints = new ContourPoint(po, new Chamfer());
                            platePoints.Add(cPoints);
                            //ControlPoint controlPoint = new ControlPoint(p);
                            //controlPoint.Insert();
                        }
                        PolyBeam polyBeam1 = new PolyBeam();

                        polyBeam1.Contour.ContourPoints = platePoints;

                        polyBeam1.Profile.ProfileString = _Profile;
                        polyBeam1.Material.MaterialString = _Material;
                        polyBeam1.Finish = "PAINT";
                        polyBeam1.Position.Depth = Position.DepthEnum.MIDDLE;
                        polyBeam1.Position.Plane = Position.PlaneEnum.RIGHT;
                        polyBeam1.Position.Rotation = Position.RotationEnum.FRONT;
                        polyBeam1.Class = "11";
                        Result = false;
                        Result = polyBeam1.Insert();
                        parts.Add(polyBeam1);
                    }
                    else
                        break;
                    i++;
                }
                for (i = 0; i < parts.Count - 3; i += 2)
                {
                    d = _CenterHorizaltalStiffner;
                    PolyBeam polyBeam = parts[i] as PolyBeam;
                    PolyBeam polyBeam1 = parts[i + 2] as PolyBeam;
                    ArrayList points1 = polyBeam.Contour.ContourPoints;
                    ArrayList points2 = polyBeam1.Contour.ContourPoints;
                    total = d;
                    Point holdPoint1 = points1[0] as Point,
                        holdPoint2 = points2[0] as Point;
                    do
                    {
                        foreach (int n in new List<int> { 1, -1 })
                        {
                            p1 = TeklaPH.Line.FindPointOnLine(holdPoint1, points1[1] as Point, d);
                            p2 = TeklaPH.Line.FindPointOnLine(holdPoint2, points2[1] as Point, d);
                            Beam beam1 = new Beam();
                            beam1 = new Beam();
                            beam1.StartPoint = new Point(p1.X, n * p1.Y, p1.Z);
                            beam1.EndPoint = new Point(p2.X, n * p2.Y, p2.Z);

                            beam1.Profile.ProfileString = _Profile;
                            beam1.Material.MaterialString = _Material;
                            beam1.Finish = "PAINT";
                            beam1.Position.Depth = Position.DepthEnum.FRONT;
                            beam1.Position.Plane = (n == 1) ? Position.PlaneEnum.LEFT : Position.PlaneEnum.RIGHT;
                            beam1.Position.Rotation = Position.RotationEnum.FRONT;
                            beam1.Class = "11";
                            bool Result = false;
                            Result = beam1.Insert();
                        }
                        holdPoint1 = p1;
                        holdPoint2 = p2;
                        total += d;

                    } while (total < centerHight);

                }

            }
            if (falgRight)
            {
                d = _CenterHorizaltalStiffner;
                PolyBeam polyBeam = parts[0] as PolyBeam;
                PolyBeam polyBeam1 = polyBeams[polyBeams.Count - 1] as PolyBeam;
                ArrayList points1 = polyBeam.Contour.ContourPoints;
                ArrayList points2 = polyBeam1.Contour.ContourPoints;
                double total = d / 2;
                Point p1 = null, p2 = null;
                Point holdPoint1 = points1[0] as Point,
                    holdPoint2 = points2[0] as Point;

                do
                {
                    foreach (int n in new List<int> { 1, -1 })
                    {
                        p1 = TeklaPH.Line.FindPointOnLine(holdPoint1, points1[1] as Point, (total == d / 2) ? d / 2 : d);
                        p2 = TeklaPH.Line.FindPointOnLine(holdPoint2, points2[1] as Point, (total == d / 2) ? d / 2 : d);
                        Beam beam1 = new Beam();
                        beam1 = new Beam();
                        beam1.StartPoint = new Point(p1.X, n * p1.Y, p1.Z);
                        beam1.EndPoint = new Point(p2.X, n * p2.Y, p2.Z);

                        beam1.Profile.ProfileString = _Profile;
                        beam1.Material.MaterialString = _Material;
                        beam1.Finish = "PAINT";
                        beam1.Position.Depth = Position.DepthEnum.FRONT;
                        beam1.Position.Plane = (n != 1) ? Position.PlaneEnum.LEFT : Position.PlaneEnum.RIGHT;
                        beam1.Position.Rotation = Position.RotationEnum.FRONT;
                        beam1.Class = "11";
                        bool Result = false;
                        Result = beam1.Insert();
                    }
                    holdPoint1 = p1;
                    holdPoint2 = p2;
                    total += d;

                } while (total < centerHight);

            }
            if (falgLeft)
            {
                d = _CenterHorizaltalStiffner;
                PolyBeam polyBeam = parts[parts.Count - 2] as PolyBeam;
                PolyBeam polyBeam1 = polyBeams[0];
                ArrayList points1 = polyBeam.Contour.ContourPoints;
                ArrayList points2 = polyBeam1.Contour.ContourPoints;
                double total = d / 2;
                Point p1 = null, p2 = null;
                Point holdPoint1 = points1[0] as Point,
                    holdPoint2 = points2[0] as Point;

                do
                {
                    foreach (int n in new List<int> { 1, -1 })
                    {
                        p1 = TeklaPH.Line.FindPointOnLine(holdPoint1, points1[1] as Point, (total == d / 2) ? d / 2 : d);
                        p2 = TeklaPH.Line.FindPointOnLine(holdPoint2, points2[1] as Point, (total == d / 2) ? d / 2 : d);
                        Beam beam1 = new Beam();
                        beam1 = new Beam();
                        beam1.StartPoint = new Point(p1.X, n * p1.Y, p1.Z);
                        beam1.EndPoint = new Point(p2.X, n * p2.Y, p2.Z);

                        beam1.Profile.ProfileString = _Profile;
                        beam1.Material.MaterialString = _Material;
                        beam1.Finish = "PAINT";
                        beam1.Position.Depth = Position.DepthEnum.FRONT;
                        beam1.Position.Plane = (n != 1) ? Position.PlaneEnum.RIGHT : Position.PlaneEnum.LEFT;
                        beam1.Position.Rotation = Position.RotationEnum.FRONT;
                        beam1.Class = "11";
                        bool Result = false;
                        Result = beam1.Insert();
                    }
                    holdPoint1 = p1;
                    holdPoint2 = p2;
                    total += d;

                } while (total < centerHight);

            }
            return new List<Part>();
        }
        private List<Part> RightStiffnerCreation(List<List<Point>> points, Part part)
        {

            var internalList = points.Last();
            Point hold = internalList.Last();
            double thickness = _Thickness;
            Beam beam1 = part as Beam;
            Point point = Projection.PointToPlane(beam1.StartPoint, new GeometricPlane(hold, new Vector(1, 0, 0)));

            foreach (List<Point> points1 in points)
            {
                ArrayList platePoints = new ArrayList();
                foreach (Point p in points1)
                {
                    Point po = TeklaPH.Line.FindPointOnLine(p, point, -thickness);
                    ContourPoint cPoints = new ContourPoint(po, new Chamfer());
                    platePoints.Add(cPoints);
                }
                PolyBeam polyBeam = new PolyBeam();

                polyBeam.Contour.ContourPoints = platePoints;

                polyBeam.Profile.ProfileString = _Profile;
                polyBeam.Material.MaterialString = _Material;
                polyBeam.Finish = "PAINT";
                polyBeam.Position.Depth = (new List<List<Point>> { points[0], points[1] }.Contains(points1)) ? Position.DepthEnum.FRONT : Position.DepthEnum.BEHIND;
                polyBeam.Position.Plane = (new List<List<Point>> { points[0], points[1] }.Contains(points1)) ? Position.PlaneEnum.LEFT : Position.PlaneEnum.RIGHT;
                polyBeam.Position.Rotation = Position.RotationEnum.TOP;
                polyBeam.Class = "11";
                bool Result = false;
                Result = polyBeam.Insert();

                Beam beam = new Beam();
                beam.StartPoint = TeklaPH.Line.FindPointOnLine(points1[0], point, -thickness);
                beam.EndPoint = TeklaPH.Line.FindPointOnLine(hold, point, -thickness);
                hold = points1.Last();
                beam.Profile.ProfileString = _Profile;
                beam.Material.MaterialString = _Material;
                beam.Finish = "PAINT";
                beam.Position.Depth = (new List<List<Point>> { points[0], points[1] }.Contains(points1)) ? Position.DepthEnum.FRONT : (points[2] == points1) ? Position.DepthEnum.BEHIND : Position.DepthEnum.BEHIND;
                beam.Position.Plane = (points[0] == points1 || points[3] == points1) ? Position.PlaneEnum.LEFT : Position.PlaneEnum.RIGHT;
                beam.Position.Rotation = (!new List<List<Point>> { points[0], points[2] }.Contains(points1)) ? Position.RotationEnum.TOP : Position.RotationEnum.FRONT;
                beam.Class = "11";
                Result = false;
                Result = beam.Insert();

                if (points[3] == points1 && beam.StartPoint.Z > 0)
                {
                    Point mid = TeklaPH.Line.MidPoint(beam.StartPoint, beam.EndPoint);
                    beam1 = new Beam();
                    beam1.StartPoint = mid;
                    beam1.EndPoint = new Point(mid.X, mid.Y, 0);
                    hold = points1.Last();
                    beam1.Profile.ProfileString = _Profile ;
                    beam1.Material.MaterialString = _Material ;
                    beam1.Finish = "PAINT";
                    beam1.Position.Depth = Position.DepthEnum.FRONT;
                    beam1.Position.Plane = Position.PlaneEnum.MIDDLE;
                    beam1.Position.Rotation = Position.RotationEnum.FRONT;
                    beam1.Class = "11";
                    Result = false;
                    Result = beam1.Insert();
                }
            }
            return new List<Part>();
        }
        private Part LeftStiffnerCreation(List<Point> points1, List<Point> points2)
        {
            Line l1 = new Line(points1[0], points2[0]),
                l2 = new Line(points1[1], points2[1]),
                l3 = new Line(points1[2], points2[2]),
                l4 = new Line(points1[3], points2[3]);
            double leftOffset = _LeftStiffnerOffset,
                centerLength = _CenterDuctLength,
                centerHight = _CenterDuctHight,
                thickness = _Thickness;
            GeometricPlane plane = new GeometricPlane(new Point(-(centerLength / 2 + leftOffset), 0, 0), new Vector(1, 0, 0));
            Point point = new Point(-(centerLength / 2 + leftOffset), 0, centerHight / 2);
            Point p1 = Intersection.LineToPlane(l1, plane),
                p2 = Intersection.LineToPlane(l4, plane),
                p3 = Intersection.LineToPlane(l3, plane),
                p4 = Intersection.LineToPlane(l2, plane),
                po1 = TeklaPH.Line.FindPointOnLine(p1, p4, Distance.PointToPoint(p1, p4) * 0.4),
                po2 = TeklaPH.Line.FindPointOnLine(p4, p1, Distance.PointToPoint(p1, p4) * 0.4);


            ArrayList platePoints = new ArrayList();
            foreach (Point p in new List<Point> { new Point(po1.X, po1.Y, 0), po1, p1, p2, p3, p4, po2, new Point(po2.X, po2.Y, 0) })
            {

                Point po = TeklaPH.Line.FindPointOnLine(p, point, -thickness);
                ContourPoint cPoints = new ContourPoint(po, new Chamfer());
                platePoints.Add(cPoints);
            }
            PolyBeam polyBeam = new PolyBeam();

            polyBeam.Contour.ContourPoints = platePoints;

            polyBeam.Profile.ProfileString = _Profile;
            polyBeam.Material.MaterialString = _Material;
            polyBeam.Finish = "PAINT";
            polyBeam.Position.Depth = Position.DepthEnum.BEHIND;
            polyBeam.Position.Plane = Position.PlaneEnum.LEFT;
            polyBeam.Position.Rotation = Position.RotationEnum.TOP;
            polyBeam.Class = "11";
            bool Result = false;
            Result = polyBeam.Insert();

            return polyBeam;
        }
        public static List<List<Point>> GenerateCirclePointsYZ(Point origin, double radius, int pointsPerSet)
        {
            if (pointsPerSet <= 0)
                throw new ArgumentException("Number of points per set must be greater than zero.");

            if (radius <= 0)
                throw new ArgumentException("Radius must be greater than zero.");

            // Prepare the lists to hold points for each slice
            List<Point> quadrant1 = new List<Point>();
            List<Point> quadrant2 = new List<Point>();
            List<Point> quadrant3 = new List<Point>();
            List<Point> quadrant4 = new List<Point>();

            // The total number of points around the circumference
            int totalPoints = pointsPerSet * 4;

            // Increment for the angle
            double angleIncrement = 2 * Math.PI / totalPoints;

            Point hold = null;
            // Generate points
            for (int i = 0; i < totalPoints; i++)
            {
                // Calculate the angle
                double angle = i * angleIncrement;

                // Calculate the Y and Z coordinates
                double y = origin.Y + radius * Math.Cos(angle);
                double z = origin.Z + radius * Math.Sin(angle);

                // The X-coordinate remains constant
                Point point = new Point(origin.X, y, z);
                if (angle == 0)
                    hold = point;
                // Assign points to respective quadrants
                if (angle >= 0 && angle <= Math.PI / 2)
                    quadrant1.Add(point);
                if (angle >= Math.PI / 2 && angle <= Math.PI)
                    quadrant2.Add(point);
                if (angle >= Math.PI && angle <= 3 * Math.PI / 2)
                    quadrant3.Add(point);
                if (angle >= 3 * Math.PI / 2)
                    quadrant4.Add(point);
            }
            quadrant4.Add(hold);
            // Return the result as a list of quadrants
            return new List<List<Point>> { quadrant1, quadrant2, quadrant3, quadrant4 };
        }
        public static List<List<Point>> GenerateCirclePointsXY(Point origin, double radius, int pointsPerRow)
        {
            if (pointsPerRow <= 0)
                throw new ArgumentException("Number of points per set must be greater than zero.");

            if (radius <= 0)
                throw new ArgumentException("Radius must be greater than zero.");

            // Prepare the lists to hold points for each slice
            List<Point> quadrant1 = new List<Point>();
            List<Point> quadrant2 = new List<Point>();
            List<Point> quadrant3 = new List<Point>();
            List<Point> quadrant4 = new List<Point>();

            // The total number of points around the circumference
            int totalPoints = pointsPerRow * 4;

            // Increment for the angle
            double angleIncrement = 2 * Math.PI / totalPoints;

            Point hold = null;
            // Generate points
            for (int i = 0; i < totalPoints; i++)
            {
                // Calculate the angle
                double angle = i * angleIncrement;

                // Calculate the Y and Z coordinates
                double x = origin.X + radius * Math.Cos(angle);
                double y = origin.Y + radius * Math.Sin(angle);

                // The X-coordinate remains constant
                Point point = new Point(x, y, origin.Z);
                if (angle == 0)
                    hold = point;
                // Assign points to respective quadrants
                if (angle >= 0 && angle <= Math.PI / 2)
                    quadrant1.Add(point);
                if (angle >= Math.PI / 2 && angle <= Math.PI)
                    quadrant2.Add(point);
                if (angle >= Math.PI && angle <= 3 * Math.PI / 2)
                    quadrant3.Add(point);
                if (angle >= 3 * Math.PI / 2)
                    quadrant4.Add(point);
            }
            quadrant4.Add(hold);
            // Return the result as a list of quadrants
            return new List<List<Point>> { quadrant1, quadrant2, quadrant3, quadrant4 };
        }
        public static List<Point> GenerateCirclePointsXY(Point origin, double radius, int pointsPerSet,bool flag)
        {
            if (pointsPerSet <= 0)
                throw new ArgumentException("Number of points per set must be greater than zero.");

            if (radius <= 0)
                throw new ArgumentException("Radius must be greater than zero.");

            // Prepare the lists to hold points for each slice
            List<Point> quadrant1 = new List<Point>();
            

            // The total number of points around the circumference
            int totalPoints = pointsPerSet ;

            // Increment for the angle
            double angleIncrement = 2 * Math.PI / totalPoints;

           
            // Generate points
            for (int i = 0; i < totalPoints; i++)
            {
                // Calculate the angle
                double angle = i * angleIncrement;

                // Calculate the Y and Z coordinates
                double x = origin.X + radius * Math.Cos(angle);
                double y = origin.Y + radius * Math.Sin(angle);

                // The X-coordinate remains constant
                Point point = new Point(x, y, origin.Z);
               
               
                    quadrant1.Add(point);
                
            }
            
            // Return the result as a list of quadrants
            return  quadrant1;
        }
        private List<Part> TopCapDuctCreation(List<Point> points, double diameter, Point point, out List<List<Point>> stiffnerPoints ,string partClass ,out List<Point> capTopQuadrantsPoints)
        {
            capTopQuadrantsPoints = new List<Point>();
            Point p1 = new Point(
                point.X,
                point.Y + diameter/2,
                point.Z),
                p3 = new Point(
                    point.X + diameter/2 ,
                point.Y,
                point.Z),
                p2 = new Point(
                    point.X ,
                point.Y-diameter/2,
                point.Z),
                p4 = new Point(
                    point.X-diameter/2 ,
                point.Y,
                point.Z);
            capTopQuadrantsPoints = new List<Point> { p2, p4, p1, p3 };
            ArrayList platePoints = new ArrayList();
            foreach (Point p in new List<Point> { p1, points[2], points[3] })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);

            }
            ContourPlate cp = new ContourPlate();
            cp.Contour.ContourPoints = platePoints;
            cp.Profile.ProfileString = "PL" + _Thickness;
            cp.Material.MaterialString = _Material;
            cp.Class = partClass;
            cp.Position.Depth = Position.DepthEnum.BEHIND;
            bool f = cp.Insert();

            platePoints = new ArrayList();
            foreach (Point p in new List<Point> { p2, points[0], points[1] })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);

            }
            ContourPlate cp1 = new ContourPlate();
            cp1.Contour.ContourPoints = platePoints;
            cp1.Profile.ProfileString = "PL" + _Thickness;
            cp1.Material.MaterialString = _Material;
            cp1.Class = partClass;
            cp1.Position.Depth = Position.DepthEnum.BEHIND;
            f = cp1.Insert();
            platePoints.Clear();
            foreach (Point p in new List<Point> { p3, points[0], points[3] })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);

            }
            ContourPlate cp2 = new ContourPlate();
            cp2.Contour.ContourPoints = platePoints;
            cp2.Profile.ProfileString = "PL" + _Thickness;
            cp2.Material.MaterialString = _Material;
            cp2.Class = partClass;
            cp2.Position.Depth = Position.DepthEnum.BEHIND;
            f = cp2.Insert();

            platePoints.Clear();
            foreach (Point p in new List<Point> { p4, points[1], points[2] })
            {
                ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                platePoints.Add(cPoints);

            }
            ContourPlate cp3 = new ContourPlate();
            cp3.Contour.ContourPoints = platePoints;
            cp3.Profile.ProfileString = "PL" + _Thickness;
            cp3.Material.MaterialString = _Material;
            cp3.Class = partClass;
            cp3.Position.Depth = Position.DepthEnum.BEHIND;
            f = cp3.Insert();

            List<Part> parts = new List<Part> { cp, cp1, cp2, cp3 };
           
            List<List<Point>> holdPointsSets = GenerateCirclePointsXY(point, diameter / 2, _NoOfSections);

            stiffnerPoints = new List<List<Point>>();
            GeometricPlane gp = new GeometricPlane(new Point(0 , 0, point.Z), new Vector(0, 0, 1));
            int n = 0;
            foreach (Point p in new List<Point> { points[3], points[2], points[1], points[0] })
            {
                List<Point> newPoints = new List<Point>();
                Line line = new Line(p, holdPointsSets[n][0]);
                newPoints.Add(Intersection.LineToPlane(line, gp));
                for (int i = 0; i < holdPointsSets[n].Count - 1; i++)
                {
                    line = new Line(p, holdPointsSets[n][i + 1]);
                    newPoints.Add(Intersection.LineToPlane(line, gp));
                    platePoints.Clear();
                    foreach (Point po in new List<Point> { p, holdPointsSets[n][i], holdPointsSets[n][i + 1] })
                    {
                        ContourPoint cPoints = new ContourPoint(po, new Chamfer());
                        platePoints.Add(cPoints);

                    }
                    ContourPlate cp4 = new ContourPlate();
                    cp4.Contour.ContourPoints = platePoints;
                    cp4.Profile.ProfileString = "PL" + _Thickness;
                    cp4.Material.MaterialString = _Material;
                    cp4.Class = partClass;
                    cp4.Position.Depth =  Position.DepthEnum.BEHIND;
                    f = cp4.Insert();
                    parts.Add(cp4);
                }
                stiffnerPoints.Add(newPoints);
                n++;
            }

            return parts;
        }
        private List<Part> TopHorizontalStiffneerCreation(List<Point> points)
        {
            List<Part> parts = new List<Part>();
            Beam holdBeam = new Beam(),
                beam;
            Point mid = TeklaPH.Line.MidPoint(points[0], points[2]);
            double dia = Math.Sqrt(2 * _Thickness * _Thickness);
            for (int i = 0; i < points.Count; i++) 
            {
                Point p1 = TeklaPH.Line.FindPointOnLine(points[i], mid, dia * (-1));
                Point p2 = TeklaPH.Line.FindPointOnLine(points[(i == points.Count - 1) ? 0 : i + 1], mid, dia * (-1));

                beam = new Beam(p1, p2);
                beam.Profile.ProfileString = _Profile;
                beam.Material.MaterialString = _Material;
                beam.Finish = "PAINT";
                beam.Position.Depth = Position.DepthEnum.BEHIND;
                beam.Position.Plane = Position.PlaneEnum.LEFT;
                beam.Position.Rotation = Position.RotationEnum.FRONT;
                beam.Class = "11";
                bool Result = false;
                Result = beam.Insert();
                parts.Add(beam);
                if(i != 0)
                {
                    TeklaPH.Fitting.SameProfileEdgeJoint(beam, holdBeam);
                }
                holdBeam = beam;
            }
            TeklaPH.Fitting.SameProfileEdgeJoint(parts[0], parts[parts.Count - 1]);
            return parts;
        }
        private List<Part> VerticalChinmyStiffners(List<Point> capTopQuadeantsPoints, Point chinmyOrigin, double chinmyHight, double chinmyTopRadius, List<Part> capHorizontalStiffners)
        {
            Point p1 = new Point(
                chinmyOrigin.X + chinmyTopRadius * 0.5 + _PltThkCon,
                chinmyOrigin.Y,
                chinmyOrigin.Z + chinmyHight),
                p2 = new Point(
                chinmyOrigin.X,
                chinmyOrigin.Y + chinmyTopRadius * 0.5 + _PltThkCon,
                chinmyOrigin.Z + chinmyHight),
                p3 = new Point(
                chinmyOrigin.X,
                chinmyOrigin.Y - (chinmyTopRadius * 0.5 + _PltThkCon),
                chinmyOrigin.Z + chinmyHight),
                p4 = new Point(
                chinmyOrigin.X - (chinmyTopRadius * 0.5 + _PltThkCon),
                chinmyOrigin.Y,
                chinmyOrigin.Z + chinmyHight);
            List<Part> parts = new List<Part>();
            List<Point> topPoints = new List<Point> { p3, p4, p2, p1 };
            for (int i = 0; i < capTopQuadeantsPoints.Count; i++)
            {
                Point capTopPoint = capTopQuadeantsPoints[i];
                Point partMidPoint = TeklaPH.Line.MidPoint((capHorizontalStiffners[i] as Beam).StartPoint, (capHorizontalStiffners[i] as Beam).EndPoint);
                Point center = new Point(chinmyOrigin.X , chinmyOrigin.Y, capTopPoint.Z);
                Point centerPoint = TeklaPH.Line.FindPointOnLine(capTopPoint, center, -((_PltThkCon >= _Thickness) ? _PltThkCon : _Thickness));
                
                Point topPoint = topPoints[i];
                ArrayList platePoints = new ArrayList();
                
                foreach (Point p in new List<Point> { partMidPoint, centerPoint,topPoint })
                {
                    ContourPoint cPoints = new ContourPoint(p, new Chamfer());
                    platePoints.Add(cPoints);
                }
                PolyBeam polyBeam = new PolyBeam();

                polyBeam.Contour.ContourPoints = platePoints;

                polyBeam.Profile.ProfileString = _Profile;
                polyBeam.Material.MaterialString = _Material;
                polyBeam.Finish = "PAINT";
                polyBeam.Position.Depth = Position.DepthEnum.BEHIND;
                polyBeam.Position.Plane = Position.PlaneEnum.MIDDLE;
                polyBeam.Position.Rotation = Position.RotationEnum.TOP;
                polyBeam.Class = "11";
                bool Result = false;
                Result = polyBeam.Insert();
                parts.Add(polyBeam);
            }
            return parts;
        }
        private List<Part> StudsForChinmyCreation(Point origin, double bottomRadius, double topRadius, int pointsPerSet, double hight, double verticalDistance, double studLength)
        {

            double total = 0;
            List<Part> parts = new List<Part>();
            do
            {
                total += verticalDistance;
                Point newOrigin = new Point(origin.X, origin.Y, origin.Z + total);
                double radius = GetRadiusAtHeight(topRadius, bottomRadius, hight, total);
                List<Point> holdPointsSets = GenerateCirclePointsXY(newOrigin, radius, pointsPerSet, true);


                foreach (Point point in holdPointsSets)
                {

                    Point sp = new Point(point.X, point.Y, point.Z);
                    Point ep = TeklaPH.Line.FindPointOnLine(sp, newOrigin, studLength);
                    Beam beam = new Beam(sp, ep);
                    beam.Profile.ProfileString = "D50";
                    beam.Material.MaterialString = _Material;
                    beam.Finish = "PAINT";
                    beam.Position.Depth = Position.DepthEnum.MIDDLE;
                    beam.Position.Plane = Position.PlaneEnum.MIDDLE;
                    beam.Position.Rotation = Position.RotationEnum.FRONT;
                    beam.Class = "2";
                    bool Result = false;
                    Result = beam.Insert();
                    parts.Add(beam);

                }


            } while (total + verticalDistance < hight);
            return parts;
        }
        public static double GetRadiusAtHeight(double topRadius, double bottomRadius, double totalHeight, double crossSectionHeight)
        {
            // Validate inputs
            if (crossSectionHeight < 0 || crossSectionHeight > totalHeight)
            {
                throw new ArgumentException("Cross-section height must be between 0 and the total height of the cone.");
            }

            // Calculate the radius using linear interpolation
            double radius = bottomRadius + (topRadius - bottomRadius) * (crossSectionHeight / totalHeight);
            return radius;
        }
        private List<Part> ChinmyCap(List<ControlArc> arcs1, List<ControlArc> arcs2)
        {
            List<Part> parts = new List<Part>();
            for (int i = 0; i < arcs1.Count; i++)
            {
                double radangle = (360.0 / _SegCon) * (Math.PI / 180);
                LineSegment line1 = new LineSegment(TeklaPH.Line.FindPointOnLine(arcs1[i].Geometry.StartPoint + new Point(0, 0, _Thickness / 2), arcs1[i].Geometry.CenterPoint + new Point(0, 0, _Thickness / 2), _PltThkCon / -2), TeklaPH.Line.FindPointOnLine(arcs1[i].Geometry.EndPoint + new Point(0, 0, _Thickness / 2), arcs1[i].Geometry.CenterPoint + new Point(0, 0, _Thickness), _PltThkCon / -2));
                LineSegment line2 = new LineSegment(TeklaPH.Line.FindPointOnLine(arcs2[i].Geometry.StartPoint + new Point(0, 0, _Thickness / 2), arcs2[i].Geometry.CenterPoint + new Point(0, 0, _Thickness / 2), _InnerPlateThickness / 2), TeklaPH.Line.FindPointOnLine(arcs2[i].Geometry.EndPoint + new Point(0, 0, _Thickness / 2), arcs2[i].Geometry.CenterPoint + new Point(0, 0, _Thickness / 2), _InnerPlateThickness / 2));

                ControlArc arc1 = new ControlArc(line1.StartPoint, line1.EndPoint, TeklaPH.Line.FindPointOnLine(arcs1[i].Geometry.CenterPoint + new Point(0, 0, _Thickness / 2), TeklaPH.Line.MidPoint(line1), Distance.PointToPoint(line1.StartPoint, arcs1[i].Geometry.CenterPoint + new Point(0, 0, _Thickness / 2))));
                ControlArc arc2 = new ControlArc(line2.StartPoint, line2.EndPoint, TeklaPH.Line.FindPointOnLine(arcs2[i].Geometry.CenterPoint + new Point(0, 0, _Thickness / 2), TeklaPH.Line.MidPoint(line2), Distance.PointToPoint(line2.StartPoint, arcs2[i].Geometry.CenterPoint + new Point(0, 0, _Thickness / 2))));

                //ControlArc arc1 = ArcFormation(arcs1[i].Geometry.StartPoint + new Point(0, 0, _Thickness / 2), arcs1[i].Geometry.EndPoint + new Point(0, 0, _Thickness / 2), arcs1[i].Geometry.CenterPoint + new Point(0, 0, _Thickness / 2), (_TopDiaC + _Thickness * 2) / 2, radangle, ((i * 2) - 1));
                //ControlArc arc2 = ArcFormation(arcs2[i].Geometry.StartPoint + new Point(0, 0, _Thickness / 2), arcs2[i].Geometry.EndPoint + new Point(0, 0, _Thickness / 2), arcs2[i].Geometry.CenterPoint + new Point(0, 0, _Thickness / 2), (_TopDiaC - (_StudLength + _InnerPlateThickness * 1.5) * 2) / 2, radangle, ((i * 2) - 1));

                parts.Add(CreateConicalRing(arc1, arc2, _Thickness, _Material, "4"));
            }
            return parts;
        }


        private void ChimnyCreation(Point point,double thickness,double bottomDiameter ,double topDiameter,string material,string plateClass,out List<ControlArc> arcs)
        {
            try
            {
                arcs = new List<ControlArc>();
                int parts = _SegCon;
                var offset = 0.5 * thickness;
                double radangle = (360.0 / parts) * (Math.PI / 180);
                var btmradius = bottomDiameter / 2 + offset;
                var topradius = (_ChimnyLayout == 0) ? bottomDiameter / 2 + offset : topDiameter / 2 + offset;
                var totalheight = _LenShell;
                var heightring = totalheight / _QtyCon;

                for (int i = 1; i <= parts; i++)
                {

                    Point startPoint1 = new Point((point.X + (btmradius * Math.Cos((i - 1) * radangle))), (point.Y + (btmradius * Math.Sin((i - 1) * radangle))), point.Z);
                    Point endPoint1 = new Point((point.X + (btmradius * Math.Cos(i * radangle))), (point.Y + (btmradius * Math.Sin(i * radangle))), point.Z);
                    var arc1 = ArcFormation(startPoint1, endPoint1, point, btmradius, radangle, ((i * 2) - 1));


                    for (int j = 1; j <= _QtyCon; j++)
                    {
                        //double h_j = j * heightring;
                        var midradius = btmradius - ((btmradius - topradius) / totalheight) * j * heightring;
                        if (topradius > btmradius)
                        {
                            midradius = btmradius + ((topradius - btmradius) / totalheight) * j * heightring;
                        }
                        Point centrePoint2 = point + new Vector(0, 0, 1) * heightring * j;
                        Point startPoint2 = new Point((centrePoint2.X + (midradius * Math.Cos((i - 1) * radangle))), (centrePoint2.Y + (midradius * Math.Sin((i - 1) * radangle))), centrePoint2.Z);
                        Point endPoint2 = new Point((centrePoint2.X + midradius * Math.Cos(i * radangle)), (centrePoint2.Y + (midradius * Math.Sin(i * radangle))), centrePoint2.Z);
                        var arc2 = ArcFormation(startPoint2, endPoint2, centrePoint2, midradius, radangle, ((i * 2) - 1));
                        var loftedPlate2 = CreateConicalRing(arc1, arc2, thickness, material, plateClass);

                        //btmradius = midradius;
                        arc1 = arc2;
                    }
                    arcs.Add(arc1);
                }
                Operation.DisplayPrompt("Conical Ring is placed.");
            }



            catch (Exception Exc)
            {
                Operation.DisplayPrompt(Exc.ToString());
                arcs = null;
            }
            
        }
        private ControlArc ArcFormation(Point startPoint1, Point endPoint1, Point centerPoint1, double radius, double angle, int i)
        {
            ControlPoint cp1 = new ControlPoint(new Point(centerPoint1.X + radius * Math.Cos(0.5 * i * angle), centerPoint1.Y + radius * Math.Sin(0.5 * i * angle), startPoint1.Z));
            cp1.Insert();
            ControlArc controlArc1 = new ControlArc(startPoint1, endPoint1, new Point(centerPoint1.X + radius * Math.Cos(0.5 * i * angle), centerPoint1.Y + radius * Math.Sin(0.5 * i * angle), startPoint1.Z));
            controlArc1.Color = ControlObjectColorEnum.GREEN;
            controlArc1.LineType = ControlObjectLineType.SolidLine;
            bool result = false;
            result = controlArc1.Insert();
           
            return controlArc1;
        }
        private LoftedPlate CreateConicalRing(ControlArc arc1, ControlArc arc2, double thickness,string material,string plateClass)
        {
            var bottomArc = new Arc(new Point(arc1.Geometry.StartPoint), new Point(arc1.Geometry.EndPoint), new Point(arc1.Geometry.ArcMiddlePoint));
            var topArc = new Arc(new Point(arc2.Geometry.StartPoint), new Point(arc2.Geometry.EndPoint), new Point(arc2.Geometry.ArcMiddlePoint));

            var baseCurves = new List<ICurve> { bottomArc, topArc };

            var loftedPlate2 = new LoftedPlate
            {
                BaseCurves = baseCurves,
                Finish = _FinishChinmy,
            };

            loftedPlate2.Profile.ProfileString = "PLT" + thickness;
            loftedPlate2.Material.MaterialString = material;
            loftedPlate2.Class = plateClass;
            bool result = false;
            result = loftedPlate2.Insert();
           
            return loftedPlate2;
        }

        #endregion
    }
}
