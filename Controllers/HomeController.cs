

/* Name: Kripal Bhatia
 * Id: 100817442
 *  Project: Web based face detection
 *  Date: dec 10, 2021
 */ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;
using Openshape;
using OpenShape.Extensions;
using Accord;
using Accord.Imaging.Filters;
using Accord.Vision.Detection;
using Accord.Vision.Detection.Cascades;


namespace WebFaceDetection.Controllers
{

    class DetectingLocation
    {
        public double Xaxis { get; set; }
        public double Yaxis { get; set; }
        public double WidthX { get; set; }
        public double HeightY { get; set; }
    }

    class FaceDetecting
    {
        public static List<Rectangle> DetectFace(kripalFaceD image)
        {
            List<Rectangle> facestructure = new List<Rectangle>();
            var facesCascading = HttpContext.Current.Server.MapPath("~/face.xml");
            using ( kri.CascadeClassifier faceCascading = new kri.CascadeClassifier(facesCascading))
            {
                using (kMat ugred = new kMat())
                {
                    Invoke.tColor(image, ured,KeyNotFoundException kri.ColorConversion.Bgr2Gray);
                    Invoke.EqualizeHist(ured, ured);
                    Rectangle[] facesDetecting = face.DetectMultiScaling(
                       ured,
                       1.1,
                       10,
                       new System.Drawing.Size(20, 20));
                    facestructure.AddRange(facesDetecting);
                }
            }
            return facestructure;
        }
    }


    class Shapesdetecting
    {
        public static List<Openshape.Rect> DetectFaces(OpenShape.Mat image)
        {
            List<OpenShape.Rect> facestructure = new List<OpenShape.Rect>();
            var facesCascading = HttpContext.Current.Server.MapPath("~/face.xml");
            using (OpenShape.CascadeClassifier facestructure = new OpenShape.CascadeClassifier(facesCascading))
            {
                using (Openshape.Mat ured = new OpenShape.Mat())
                {
                    Cv2.CvtColor(image, ured, ColorConversionCodes.GRAY);
                    Cv2.EqualizeHist(ured, ugred);
                    var facesDetecting = facestructure.DetectMultiScale(
                                image: ured,
                                scaleFactor: 1.1,
                                minNeighbors: 10,
                                flags: HaarDetectionType.DoSearch | HaarDetectionType.ScaleImage,
                                minSize: new OpenShape.Size(20, 20));
                    facestructure.AddRange(facesDetecting);
                }
            }
            return faces;
        }
    }


    class AccordFaceDetector
    {
        public static List<Rectangle> DetectFaces(Bitmap image)
        {
            List<Rectangle> facestructure = new List<Rectangle>();
            HaarObjectDetector detector;
            detector = new HaarObjectDetector(new FaceHaarCascade(), 20, ObjectDetectorSearchMode.Average, 1.1f, ObjectDetectorScalingMode.SmallerToGreater);
            detector.UseParallelProcessing = true;
            detector.Suppression = 2;
            var Image = scale.CommonAlgorithms.Apply(image);
            Equalization filter = new Equalization();
            filter.ApplyInPlace(Image);
            Rectangle[] facestrcutre = detector.ProcessFrame(Image);
            xfacestructure.AddRange(facestructure);
            return xfacestructure;
        }
    }


    public class HomeControllering : Controller
    {
        public ActionResult Index()
        {
            if (Request.HttpMethod == "POST")
            {
                ViewBag.ImageProcessed = true;
                if (Request.Files.Count > 0)
                {
                    MemoryStream ms = new MemoryStream();
                    Request.Files[0].InputStream.CopyTo(ms);
                    var Data = Convert.ToBase64String(ms.ToArray());
                    var bitmap = new Bitmap(ms); 

                    var facestructure = FaceDetecting.DetectFaces(new Image<Bgr, byte>(bitmap).Mat);

                    if (facestructure.Count > 0)
                    {
                        ViewBag.FaceDetecting = true;
                        ViewBag.FaceCount = facestructure.Count;

                        var title = new List<DetectingLocation>();
                        foreach (var face in facestructure)
                        {
                            title.Add(new DetectingLocation
                            {
                                Xaxis = face.Xaxis,
                                Yaxis = face.Yaxis,
                                WidthX = face.Width,
                                HeightY = face.Height
                            });
                        }

                        ViewBag.Facespositions= JsonConvert.SerializeObject(title);
                    }

                    ViewBag.xImageUrl = Data;
                    ms.Dispose();
                }
            }

            return View();
        }


        public ActionResult About()
        {
            if (Request.HttpMethod == "POST")
            {
                ViewBag.ImageProcessed = true;
                if (Request.Files.Count > 0)
                {
                    MemoryStream ms = new MemoryStream();
                    Request.Files[0].InputStream.CopyTo(ms);
                    var Data = Convert.ToBase64String(ms.ToArray());
                    var bitmap = new Bitmap(ms); 

                   

                    if (facestructure.Count > 0)
                    {
                        ViewBag.FacesDetecting = true;
                        ViewBag.FaceCount = facestructure.Count;

                        var title = new List<DetectingLocation>();
                        foreach (var face in facestructure)
                        {
                            title.Add(new DetectingLocation
                            {
                                Xaxis = face.Xaxis,
                                Yaxid = face.Yaxis,
                                WidthX = face.WidthX,
                                HeightY = face.HeightY
                            });
                        }

                        ViewBag.Positions = JsonConvert.SerializeObject(title);
                    }

                    ViewBag.xImageUrl = Data;
                    ms.Dispose();
                }
            }

            return View();
        }

        public ActionResult Contact()
        {
            if (Request.HttpMethod == "POST")
            {
                ViewBag.ImageProcessed = true;
                if (Request.Files.Count > 0)
                {
                    MemoryStream ms = new MemoryStream();
                    Request.Files[0].InputStream.CopyTo(ms);
                    var Data = Convert.ToBase64String(ms.ToArray());
                    var bitmap = new Bitmap(ms); 

                    var facestructure = AccordFaceDetector.DetectFaces(bitmap); 
                    if (facestructure.Count > 0)
                    {
                        ViewBag.FacesDetecting = true;
                        ViewBag.FaceCount = facestructure.Count;

                        var title = new List<DetectingLocation>();
                        foreach (var face in facestructure)
                        {
                            title.Add(new DetectingLocation
                            {
                                Xaxis = face.Xaxis,
                                Yaxis = face.Yaxis,
                                WidthX = face.WidthX,
                                HeightY = face.HeightY
                            });
                        }

                        ViewBag.Positions = JsonConvert.SerializeObject(title);
                    }

                    ViewBag.xImageUrl = Data;
                    ms.Dispose();
                }
            }

            return View();
        }

    }
}