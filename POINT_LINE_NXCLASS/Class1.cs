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
            Point3d p2 = new Point3d(p1.X + 35, p1.Y, p1.Z);
            Point3d p3 = new Point3d(p1.X + 17.5, p1.Y + 20, p1.Z);

            //Creating an object to call Create point method in side the PointCollection Derived class

            PointCollection PC1 = workPart.Points;
            PointCollection PC2 = workPart.Points;
            PointCollection PC3 = workPart.Points;


            //Creating the point method in Point Collection Subclass/Derived Class
            Point point1 = PC1.CreatePoint(p1);
            Point point2 = PC2.CreatePoint(p2);
            Point point3 = PC3.CreatePoint(p3);
            
            //Making the created point Visible

            point1.SetVisibility(SmartObject.VisibilityOption.Visible);
            point2.SetVisibility(SmartObject.VisibilityOption.Visible);
            point3.SetVisibility(SmartObject.VisibilityOption.Visible);
           
            //Feature Creation for point 1
            
            Feature PF1 = null;
            BaseFeatureCollection BF1 = workPart.BaseFeatures;
            PointFeatureBuilder pointFeatureBuilder1 = BF1.CreatePointFeatureBuilder(PF1);
            pointFeatureBuilder1.Point = point1;
            pointFeatureBuilder1.Commit();
            pointFeatureBuilder1.Destroy();
            
            //Feature Creation for point 2

            Feature PF2 = null;
            BaseFeatureCollection BF2 = workPart.BaseFeatures;
            PointFeatureBuilder pointFeatureBuilder2 = BF2.CreatePointFeatureBuilder(PF2);
            pointFeatureBuilder2.Point = point2;
            pointFeatureBuilder2.Commit();
            pointFeatureBuilder2.Destroy();
            
            //Feature Creation for point 3

            Feature PF3 = null;
            BaseFeatureCollection BF3 = workPart.BaseFeatures;
            PointFeatureBuilder pointFeatureBuilder3 = BF3.CreatePointFeatureBuilder(PF3);
            pointFeatureBuilder3.Point = point3;
            pointFeatureBuilder3.Commit();
            pointFeatureBuilder3.Destroy();
        }
        public static int GetUnloadOption()
        {
            return 1;
        }
    }
}
