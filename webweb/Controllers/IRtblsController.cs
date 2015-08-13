using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webweb;
using webweb.DataAccess;

namespace webweb.Controllers
{
    public class IRtblsController : Controller
    {
        //  private SRSDBEntities db = new SRSDBEntities();

        // GET: IRtbls
        public ActionResult Index()
        {
            return View();
        }

        // GET: IRtbls/Details/5
        public ActionResult Details(int? id)
        {
            return View();
        }

        // GET: IRtbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IRtbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string Req_Text, string Sentence, string Word, string POSWords)
        {
            SRSDBEntities objEntities = new SRSDBEntities();
            tblParagraph obj = new tblParagraph();
            obj.Req_Text = Req_Text;
            obj.CreatedDate = DateTime.Now;
            objEntities.tblParagraphs.Add(obj);
            objEntities.SaveChanges();

            //====================Start of Sentence Segmentation Code=========================

               
                tblSentence objSentence = null;
                string[] _ArrSentence = Req_Text.ToString().Split('.');
                foreach (var i in _ArrSentence)
                {
                    if (!string.IsNullOrEmpty(i))
                    {
                        objSentence = new tblSentence(); 
                        objEntities = new SRSDBEntities();
                        objSentence.Sentence = i;
                        objSentence.tblParagraph_ID = obj.ID;
                        objSentence.createdDate = DateTime.Now;
                        objEntities.tblSentences.Add(objSentence);
                        objEntities.SaveChanges();

                    }
                }
        
                // ===========End of Sentence Segmentation Code=========================



                //======================Start of Tokenzation Code=======================

                tblWord objWord = null;
                string[] _ArrWord = Req_Text.ToString().Split(' ','.');
                foreach (var j in _ArrWord)
                {
                    if (!string.IsNullOrEmpty(j))
                    {
                        objWord = new tblWord();
                        objWord.Word = j;
                        objWord.tblSentences_ID = objSentence.ID;
                        objWord.createdDate = DateTime.Now;
                        objEntities.tblWords.Add(objWord);
                        objEntities.SaveChanges();


                    }
                }
           
                //======================End of Tokenzation Code=======================



                //======================Start of POS Code=======================



                tblPOSS objPOS = null;
                string[] _ArrPOS = Req_Text.ToString().Split(' ', '.');
                foreach (var K in _ArrPOS)
                {
                    if (!string.IsNullOrEmpty(K))
                    {
                        objPOS = new tblPOSS();
                        objPOS.POSWords = K;
                        objPOS.tblWords_ID = objWord.ID;
                        objPOS.createDate = DateTime.Now;
                        objEntities.tblPOSSes.Add(objPOS);
                        objEntities.SaveChanges();

                    }
                }


           

                //''''''''''''''''''''''''''''''''Start of DataDictonery Code'''''''''''''''''''''''''
            
                tblDD_POS objDD_POS = new tblDD_POS();



                  tblDD obj_DD = new tblDD();
                 
     

                  var cha   = objEntities.tblDDs.Count();

                  for (int u = 1; u <= cha; u++)
                  {
                      obj_DD = objEntities.tblDDs.Find(u);







                      List<string[]> l = new List<string[]>
                {
                        new string[] {obj_DD.Nouns}
                       
                        
                };
                      List<string[]> list_Verbs_ = new List<string[]>
                {
                        
                        new string[] {obj_DD.Verbs}
                       
                };
                      List<string[]> list_Adjectives_ = new List<string[]>
                {
                       
                        new string[] {obj_DD.Adjectives}
                       
                };


                      string abc = obj_DD.Nouns;
                      string abcd = obj_DD.Verbs;
                      string abcde = obj_DD.Adjectives;
                      string[] baba = Req_Text.ToString().Split(' ', '.');
                      List<string[]> wordss = new List<string[]>{
                    new string[] {baba.ToString()}};

                      foreach (var Z in l)//var Z in l
                      {
                          foreach (var y in baba)//var y in baba
                          {

                              if (Z[0].ToString().ToLower()==y.ToString().ToLower())// Contains(y))
                              {


                                  objDD_POS.Word = y + "  " + "/noun";
                                  objDD_POS.POSTagging = "Noun";
                                  objDD_POS.tblPOSS = objPOS.ID;
                                  objDD_POS.tblDD = obj_DD.ID;

                                  objDD_POS.createDate = DateTime.Now;


                                  objEntities.tblDD_POS.Add(objDD_POS);

                                  objEntities.SaveChanges();

                              }
                              foreach (var verbs in list_Verbs_)//var Z in l
                              {

                                  if (verbs.Contains(y))
                                  {


                                      objDD_POS.Word = y + "/verb";
                                      objDD_POS.POSTagging = "Verb";
                                      objDD_POS.tblPOSS = objPOS.ID;
                                      objDD_POS.tblDD = obj_DD.ID;

                                      objDD_POS.createDate = DateTime.Now;


                                      objEntities.tblDD_POS.Add(objDD_POS);

                                      objEntities.SaveChanges();

                                  }
                              }

                              foreach (var verbs in list_Adjectives_)//var Z in l
                              {

                                  if (verbs.Contains(y))
                                  {


                                      objDD_POS.Word = y + "/Adjectives";
                                      objDD_POS.POSTagging = "Adjective";
                                      objDD_POS.tblPOSS = objPOS.ID;
                                      objDD_POS.tblDD = obj_DD.ID;

                                      objDD_POS.createDate = DateTime.Now;


                                      objEntities.tblDD_POS.Add(objDD_POS);

                                      objEntities.SaveChanges();

                                  }
                              }

                          }


                      }





                  }   //======================End of Tokenzation Code=======================

                   
                    return View();
        }


        public ActionResult diagrams()
        {


            return View();
        }                      
        
            
        

        // GET: IRtbls/Edit/5
        public ActionResult Edit(int? id)
        {

            return View();
        }

        // POST: IRtbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            return View();
        }

        // GET: IRtbls/Delete/5
        public ActionResult Delete(int? id)
        {
            return View();
        }

        // POST: IRtbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
