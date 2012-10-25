using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using tao_of_t.Viewmodel;

namespace tao_of_t.Controllers
{
    public class PayPalController : Controller
    {
        private const string Server_URL = "https://www.sandbox.paypal.com/cgi-bin/webscr?";
        //
        // GET: /PayPal/

        public ActionResult Index()
        {
            PayPalViewmodel viewmodel = new PayPalViewmodel();
            viewmodel.Firstname = "Morna";
            viewmodel.Lastname = "Tirona";
            viewmodel.Email = "mtirona@gmail.com";
            return View(viewmodel);
        }

        public RedirectResult PostToPayPal(PayPalViewmodel viewmodel)
        {
            string custom = GetTransactionFromDB(viewmodel);
            string cmd = "_xclick";
            string business = "SELLEREMAIL";
            string notify_url = "Localhost/PayPal/IPN";
            int amount = 165;
            string item_name = "Ticket";
            string redirect = string.Format("{0}&cmd={1}¬ify_url={2}&amount={3}&item_name={4}&custom={5}&business={6}",Server_URL,cmd,notify_url,amount,item_name,custom,business);
            return Redirect(redirect);  
        }
 
        private string GetTransactionFromDB(PayPalViewmodel viewmodel)
        {
            //store from model in DB and return transactionID
            //store amount also,need to verify later.
            return "123-234-5678";
        }
 
 
        public void IPN()
        {
            var formVals = new Dictionary<string, string>();
            formVals.Add("cmd", "_notify-validate");
            string response = GetPayPalResponse(formVals, true);
            if (response == "VERIFIED")
            {
                string sAmountPaid = Request["mc_gross"];
                string paymentStatus = Request["payment_status"];
                string customField = Request["custom"];
                string id = "1";
                if (sAmountPaid == GetPriceFromDatabase(id) && paymentStatus == "Completed")
                {
                    string buyerEmail = Request["payer_email"];
                    string transactionID = Request["txn_id"];//PayPal Transaction ID(Store It)
                    string firstName = Request["first_name"];
                    string lastName = Request["last_name"];
                    //Call to SP saying Payment Processed
                }
                else
                {
                    //Call to SP Saying Payment Corrupt or Invalid
                }
            }
            else if (response == "INVALID")
            {
                //Call to SP Saying Payment Failed;
            }
            else
            {
                //Send Email to Admin with response details
            }
        }
 
        private string GetPriceFromDatabase(string id)
        {
            return "15";
        }
 
  
        public string GetPayPalResponse(Dictionary<string, string>formVals, bool useSandbox)
        {
            string paypalUrl = useSandbox ? "https://www.sandbox.paypal.com/cgi-bin/webscr" : "https://www.paypal.com/cgi-bin/webscr";
 
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(paypalUrl);
 
            // Set values for the request back
 
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
 
            byte[] param = Request.BinaryRead(Request.ContentLength);
            string strRequest = Encoding.ASCII.GetString(param);
 
            StringBuilder sb = new StringBuilder();
            sb.Append(strRequest);
 
            foreach (string key in formVals.Keys)
            {
                sb.AppendFormat("&{0}={1}", key, formVals[key]);
            }
            strRequest += sb.ToString();
            req.ContentLength = strRequest.Length;
 
            string response = "";
            using (StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII))
            { 
                streamOut.Write(strRequest);
                streamOut.Close();
                using (StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream()))
                {
                    response = streamIn.ReadToEnd();
                }
            } 
            return response;
        }

        //
        // GET: /PayPal/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /PayPal/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PayPal/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PayPal/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /PayPal/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PayPal/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /PayPal/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
