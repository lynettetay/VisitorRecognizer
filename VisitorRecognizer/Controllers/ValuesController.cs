using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace VisitorRecognizer.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public async Task<string> PostAsync([FromBody]Models.cData cdata)
        {
            var url = "http://172.3.0.14:8355//img//9EPDW5H6YS4V23UUPHZ07KNDZT4KYDFOS8T47L20-2090140647-1553657204900" + ".jpg"; //+ cdata.best_uuid
            string buf = await GetImageAsBase64Url(url);
            //byte[] buf = GetImage(url);
            //WebClient webClient = new WebClient();
            //webClient.DownloadFile(url, HttpRuntime.AppDomainAppPath + "VisitorRecognizer\\Current Visitor\\" + cdata.candidates[0].plate + ".jpg");
            //webClient.DownloadFile(url, HttpRuntime.AppDomainAppPath + "Current Visitor\\" + cdata.candidates[0].plate + ".jpg");
            //using (System.IO.StreamWriter xW = new System.IO.StreamWriter(HttpRuntime.AppDomainAppPath + "VisitorRecognizer\\Current Visitor\\" + cdata.candidates[0].plate + ".txt"))
            using (System.IO.StreamWriter xW = new System.IO.StreamWriter(HttpRuntime.AppDomainAppPath + "Current Visitor\\" + cdata.candidates[0].plate + ".txt"))
            {               
               // xW.WriteLine(bytes);
                xW.WriteLine(cdata.candidates[0].plate);
            }
            using (System.IO.StreamWriter xW = new System.IO.StreamWriter(HttpRuntime.AppDomainAppPath + "Current Visitor\\_" + cdata.candidates[0].plate + ".txt"))
            {
                // xW.WriteLine(bytes);
                xW.WriteLine(buf);
            }
            //byte[] xBuffer = Convert.FromBase64String(xDatas[1]);
            //string sPath = "C:\\Users\\Presentation\\Documents\\image";
            //System.IO.File.WriteAllBytes(HttpRuntime.AppDomainAppPath + "Current Visitor\\" + cdata.candidates[0].plate + "jpg", buf);
            return cdata.candidates[0].plate;
        }
        public async static Task<string> GetImageAsBase64Url(string url)
        {
            using (var client = new HttpClient())
            {
                var bytes = await client.GetByteArrayAsync(url);
                return "image/jpeg;base64," + Convert.ToBase64String(bytes);
            }
        }
        private byte[] GetImage(string url)
        {
            Stream stream = null;
            byte[] buf;

            try
            {
                WebProxy myProxy = new WebProxy();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                stream = response.GetResponseStream();

                using (BinaryReader br = new BinaryReader(stream))
                {
                    int len = (int)(response.ContentLength);
                    buf = br.ReadBytes(len);
                    br.Close();
                }

                stream.Close();
                response.Close();
            }
            catch (Exception exp)
            {
                buf = null;
            }

            return (buf);
        }

        public String ConvertImageURLToBase64(String url)
        {
            StringBuilder _sb = new StringBuilder();

            Byte[] _byte = this.GetImage(url);

            _sb.Append(Convert.ToBase64String(_byte, 0, _byte.Length));

            return _sb.ToString();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
