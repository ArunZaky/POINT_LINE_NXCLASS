using NXOpen;
using NXOpen.Features;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POINT_LINE_NXCLASS
{
    public class Class1
    {
        public static void Main()
        {
            Session session = Session.GetSession();

            //Making the opened NX part as work Part

            Part workPart = session.Parts.Work;

            //Point3d created to use in POint Class 

            Point3d p1 = new Point3d(5, 5, 0);
            Point3d p2 = new Point3d(p1.X + 20, p1.Y, p1.Z);
            Point3d p3 = new Point3d(p2.X, p1.Y + 20, p1.Z);
            Point3d p4 = new Point3d(p1.X, p1.Y + 20, p1.Z);


            //Creating an object to call Create point method in side the PointCollection Derived class

            PointCollection PC1 = workPart.Points;
            PointCollection PC2 = workPart.Points;
            PointCollection PC3 = workPart.Points;
            PointCollection PC4 = workPart.Points;



            //Creating the point method in Point Collection Subclass/Derived Class
            Point point1 = PC1.CreatePoint(p1);
            Point point2 = PC2.CreatePoint(p2);
            Point point3 = PC3.CreatePoint(p3);
            Point point4 = PC3.CreatePoint(p4);


            //Making the created point Visible

            point1.SetVisibility(SmartObject.VisibilityOption.Visible);
            point2.SetVisibility(SmartObject.VisibilityOption.Visible);
            point3.SetVisibility(SmartObject.VisibilityOption.Visible);
            point4.SetVisibility(SmartObject.VisibilityOption.Visible);


            //Feature Creation for point 1

            //Feature PF1 = null;
            //BaseFeatureCollection BF1 = workPart.BaseFeatures;
            //PointFeatureBuilder pointFeatureBuilder1 = BF1.CreatePointFeatureBuilder(PF1);
            //pointFeatureBuilder1.Point = point1;
            //pointFeatureBuilder1.Commit();
            //pointFeatureBuilder1.Destroy();

            ////Feature Creation for point 2

            //Feature PF2 = null;
            //BaseFeatureCollection BF2 = workPart.BaseFeatures;
            //PointFeatureBuilder pointFeatureBuilder2 = BF2.CreatePointFeatureBuilder(PF2);
            //pointFeatureBuilder2.Point = point2;
            //pointFeatureBuilder2.Commit();
            //pointFeatureBuilder2.Destroy();

            ////Feature Creation for point 3

            //Feature PF3 = null;
            //BaseFeatureCollection BF3 = workPart.BaseFeatures;
            //PointFeatureBuilder pointFeatureBuilder3 = BF3.CreatePointFeatureBuilder(PF3);
            //pointFeatureBuilder3.Point = point3;
            //pointFeatureBuilder3.Commit();
            //pointFeatureBuilder3.Destroy();

            //Line line1 = workPart.Curves.CreateLine(point1,point2);
            //line1.SetVisibility(SmartObject.VisibilityOption.Visible);
            BaseFeatureCollection BC = workPart.BaseFeatures;

            AssociativeLine associativeLine1 = null;
            AssociativeLineBuilder associativeLineBuilder1 = BC.CreateAssociativeLineBuilder(associativeLine1);
            associativeLineBuilder1.StartPointOptions = AssociativeLineBuilder.StartOption.Point;
            associativeLineBuilder1.StartPoint.Value = point1;
            associativeLineBuilder1.EndPointOptions = AssociativeLineBuilder.EndOption.Point;
            associativeLineBuilder1.EndPoint.Value = point2;

            associativeLineBuilder1.Commit();
            associativeLineBuilder1.Destroy();

            AssociativeLine associativeLine2 = null;
            AssociativeLineBuilder associativeLineBuilder2 = BC.CreateAssociativeLineBuilder(associativeLine2);
            associativeLineBuilder2.StartPointOptions = AssociativeLineBuilder.StartOption.Point;
            associativeLineBuilder2.StartPoint.Value = point2;
            associativeLineBuilder2.EndPointOptions = AssociativeLineBuilder.EndOption.Point;
            associativeLineBuilder2.EndPoint.Value = point3;

            associativeLineBuilder2.Commit();
            associativeLineBuilder2.Destroy();

            AssociativeLine associativeLine3 = null;
            AssociativeLineBuilder associativeLineBuilder3 = BC.CreateAssociativeLineBuilder(associativeLine3);
            associativeLineBuilder3.StartPointOptions = AssociativeLineBuilder.StartOption.Point;
            associativeLineBuilder3.StartPoint.Value = point3;
            associativeLineBuilder3.EndPointOptions = AssociativeLineBuilder.EndOption.Point;
            associativeLineBuilder3.EndPoint.Value = point4;

            associativeLineBuilder3.Commit();
            associativeLineBuilder3.Destroy();

            AssociativeLine associativeLine4 = null;
            AssociativeLineBuilder associativeLineBuilder4 = BC.CreateAssociativeLineBuilder(associativeLine4);
            associativeLineBuilder4.StartPointOptions = AssociativeLineBuilder.StartOption.Point;
            associativeLineBuilder4.StartPoint.Value = point4;
            associativeLineBuilder4.EndPointOptions = AssociativeLineBuilder.EndOption.Point;
            associativeLineBuilder4.EndPoint.Value = point1;

            associativeLineBuilder4.Commit();
            associativeLineBuilder4.Destroy();
            Point3d mp = new Point3d(15, 20, 0);

            Point midPoint = workPart.Points.CreatePoint(mp);
            midPoint.SetVisibility(SmartObject.VisibilityOption.Visible);

            AssociativeArc associativeArc1 = null;
            AssociativeArcBuilder associativeArcBuilder1 = BC.CreateAssociativeArcBuilder(associativeArc1);
            associativeArcBuilder1.StartPointOptions = AssociativeArcBuilder.StartOption.Point;
            associativeArcBuilder1.StartPoint.Value = point1;
            
            associativeArcBuilder1.EndPointOptions = AssociativeArcBuilder.EndOption.Point;
            associativeArcBuilder1.EndPoint.Value = point2;
            
            associativeArcBuilder1.MidPointOptions = AssociativeArcBuilder.MidOption.Point;
            associativeArcBuilder1.MidPoint.Value = midPoint;
            
            associativeArcBuilder1.Commit();
            associativeArcBuilder1.Destroy();

            
            
            

        }
        public static int GetUnloadOption()
        {
            return 1;
        }
    }
}
