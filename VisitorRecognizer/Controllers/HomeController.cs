using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VisitorRecognizer.Models;

namespace VisitorRecognizer.Controllers
{
    public class HomeController : Controller
    {
        private Visitor db = new Visitor();
        public ActionResult Index()
        {
            Visitor visitor = new Visitor();
            return View(visitor);
        }
        public void cancelFile(Visitor visit)
        {
            var sourceFile = HttpRuntime.AppDomainAppPath + "Current Visitor\\" + visit.carplate + ".txt";
            //var sourceFile = HttpRuntime.AppDomainAppPath + "VisitorRecognizer\\Current Visitor\\" + visit.carplate + ".txt";
            if (System.IO.File.Exists(sourceFile))
            {
                System.IO.File.Delete(sourceFile);
            }
        }
        public void updateFile(Visitor visit)
        {
            //var checkPlate = HttpRuntime.AppDomainAppPath + "VisitorRecognizer\\Current Visitor\\Visitor\\" + visit.carplate + ".txt";
            var checkPlate = HttpRuntime.AppDomainAppPath + "Current Visitor\\Visitor\\" + visit.carplate + ".txt";
            //var sourceFile = HttpRuntime.AppDomainAppPath + "VisitorRecognizer\\Current Visitor\\" + visit.carplate + ".txt";
            var sourceFile = HttpRuntime.AppDomainAppPath + "Current Visitor\\" + visit.carplate + ".txt";
            if (System.IO.File.Exists(checkPlate))
            {
                lineChanger(visit.reason, checkPlate, 2);
                lineChanger(visit.name, checkPlate, 3);
                lineChanger(visit.contact, checkPlate, 4);
                lineChanger(visit.block, checkPlate, 5);
                lineChanger(visit.unit, checkPlate, 6);
                System.IO.File.AppendAllText(checkPlate, "@" + DateTime.Now.ToString());
                System.IO.File.Delete(sourceFile);
            }
            else
            {
                //System.IO.File.Move(HttpRuntime.AppDomainAppPath + "Current Visitor\\" + visit.carplate + ".txt", HttpRuntime.AppDomainAppPath + "Current Visitor\\Visitor\\" + visit.carplate + ".txt");
                //var checkPlate = HttpRuntime.AppDomainAppPath + "Current Visitor\\Visitor\\" + visit.carplate + ".txt";
                if (System.IO.File.Exists(sourceFile))
                {
                    //lineChanger(visit.name, checkPlate, 2);
                    //lineChanger(visit.unit, checkPlate, 3);
                    //lineChanger(visit.reason, checkPlate, 4);
                    System.IO.File.AppendAllText(sourceFile, visit.reason);
                    System.IO.File.AppendAllText(sourceFile, System.Environment.NewLine + visit.name);
                    System.IO.File.AppendAllText(sourceFile, System.Environment.NewLine + visit.contact);
                    System.IO.File.AppendAllText(sourceFile, System.Environment.NewLine + visit.block);
                    System.IO.File.AppendAllText(sourceFile, System.Environment.NewLine + visit.unit);
                    System.IO.File.AppendAllText(sourceFile, System.Environment.NewLine + "@" + DateTime.Now.ToString());
                    System.IO.File.Move(sourceFile, checkPlate);
                }

            }
        }
        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = System.IO.File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            System.IO.File.WriteAllLines(fileName, arrLine);
        }
        public ActionResult readFile()
        {
            var uploadedFiles = new List<Visitor>();


            //var files = Directory.GetFiles(HttpRuntime.AppDomainAppPath + "VisitorRecognizer\\Current Visitor\\", "*.txt");

            var files = Directory.GetFiles(HttpRuntime.AppDomainAppPath + "Current Visitor\\", "*.txt");

            if (files.Count() < 1)
            {
                var uploadedFile = new Visitor()
                {
                    carplate = "",
                    reason = "",
                    name = "",
                    contact = "",
                    block = "",
                    unit = "",
                    pVisit = "",
                    rawImageData = ""
                };
                uploadedFiles.Add(uploadedFile);
                return Json(uploadedFiles[0], JsonRequestBehavior.AllowGet);
            }
            else
            {
                foreach (var file in files)
                {

                    //System.IO.File.AppendAllText(file, System.Environment.NewLine + "@" + DateTime.Now.ToString());
                    var fileInfo = new FileInfo(file);
                    var curPlate = Path.GetFileName(file).Substring(0, Path.GetFileName(file).Length - 4);

                    //var checkPlate = HttpRuntime.AppDomainAppPath + "VisitorRecognizer\\Current Visitor\\Visitor\\" + curPlate + ".txt";
                    var checkPlate = HttpRuntime.AppDomainAppPath + "Current Visitor\\Visitor\\" + curPlate + ".txt";
                    if (System.IO.File.Exists(checkPlate))
                    {
                        string[] lines = System.IO.File.ReadAllLines(checkPlate);
                        string[] lines2 = System.IO.File.ReadAllLines(HttpRuntime.AppDomainAppPath + "Current Visitor\\_" + curPlate + ".txt");
                        var uploadedFile = new Visitor()
                        {
                            carplate = lines[0],
                            reason = lines[1],
                            name = lines[2],
                            contact = lines[3],
                            block = lines[4],
                            unit = lines[5],
                            pVisit = lines[lines.Count()-1].Substring(1,20),
                            rawImageData = lines2[0]
                        };


                        uploadedFiles.Add(uploadedFile);

                        //System.IO.File.AppendAllText(checkPlate, System.Environment.NewLine + "@" + DateTime.Now.ToString());
                        //System.IO.File.Delete(file);
                        return Json(uploadedFiles[0], JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var uploadedFile = new Visitor()
                        {
                            carplate = Path.GetFileName(file).Substring(0, Path.GetFileName(file).Length - 4),
                            reason = "",
                            name = "",
                            contact = "",
                            block = "",
                            unit = "",
                            pVisit = "",
                            rawImageData = ""
                            
                        };
                        uploadedFiles.Add(uploadedFile);
                        return Json(uploadedFiles[0], JsonRequestBehavior.AllowGet);
                    }

                    //    var uploadedFile = new Visitor() { carplate = Path.GetFileName(file).Substring(0, Path.GetFileName(file).Length - 4) };
                    //    uploadedFiles.Add(uploadedFile);
                }
            }
            //return Json(uploadedFiles[0], JsonRequestBehavior.AllowGet);
            //return Json(new
            //{
            //    Carplate = uploadedFiles[0].carplate.ToString(),
            //    Name = uploadedFiles[0].name.ToString()
            //});
            return View();
        }
    }
}
