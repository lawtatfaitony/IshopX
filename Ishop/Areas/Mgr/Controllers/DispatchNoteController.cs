using Ishop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Ishop.Models.ProductMgr;
using Ishop.Utilities;
using System.Data.Entity.Infrastructure;
using Ishop.Areas.Mgr.Models;
using System.Collections;
using Ishop.Areas.Mgr.ModelView;
using Ishop.Models.PubDataModal;
using System.Data.Entity;
using LanguageResource;

namespace Ishop.Areas.Mgr.Controllers
{
    public class DispatchNoteController : Controller
    {
        private Ishop.Context.ApplicationDbContext db = new Ishop.Context.ApplicationDbContext();
        // GET: Mgr/DispatchNote
        public ActionResult Index()
        {
            EnumHelper EnumHelper1 = new Utilities.EnumHelper(); //性别
            ViewBag.DispatchNoteStatusList = EnumHelper.GetSelectList<DispatchNoteStatus>().ToList(); 
            return View();
        }

        [Authorize(Roles = "Supervisor,Admins,StoreAdmin,StorePreSales")]
        [HttpGet]
        public ActionResult DefiniteTemplateNoteList(string sortOrder, string currentFilter, string searchString, string StartDate, string EndDate, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            ViewBag.CurrentStartDate = string.IsNullOrEmpty(StartDate) ? DateTime.Now.ToString("yyyy-MM-dd HH:mm") : StartDate;
            ViewBag.CurrentEndDate = string.IsNullOrEmpty(EndDate) ? DateTime.Now.ToString("yyyy-MM-dd HH:mm") : EndDate;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var definiteTemplateNotes = from s in db.DefiniteTemplateNotes
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                definiteTemplateNotes = definiteTemplateNotes.Where(s => s.DefiniteTemplateNoteId.Contains(searchString) || s.DefiniteTemplateNoteName.Contains(searchString)
                                                                                     || s.OperatedUserName.Contains(searchString));
            }
            //DaySpan filter  
            if (StartDate != EndDate)
            {
                ViewBag.CurrentStartDate = StartDate;
                ViewBag.CurrentEndDate = EndDate;

                DateTime pStartDate = DateTime.Parse(StartDate);
                DateTime pEndDate = DateTime.Parse(EndDate);
                definiteTemplateNotes = definiteTemplateNotes.Where(s => s.OperatedDate > pStartDate && s.OperatedDate < pEndDate);
            }
            //shop filter
            definiteTemplateNotes = definiteTemplateNotes.Where(s => s.ShopID == WebCookie.ShopID);

            switch (sortOrder)
            {
                case "Date":
                    definiteTemplateNotes = definiteTemplateNotes.OrderBy(s => s.OperatedDate);
                    break;
                case "date_desc":
                    definiteTemplateNotes = definiteTemplateNotes.OrderByDescending(s => s.OperatedDate);
                    break;
                default:  // Name ascending 
                    definiteTemplateNotes = definiteTemplateNotes.OrderByDescending(s => s.OperatedDate);
                    break;
            }
            int pageSize = 30;
            int pageNumber = (page ?? 1);
            return View(definiteTemplateNotes.ToPagedList(pageNumber, pageSize));
        }

        // GET: Mgr/DispatchNote/Index
        [Authorize(Roles = "Supervisor,Admins,StoreAdmin,StorePreSales")]
        [HttpGet]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date"; 

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            } 
            ViewBag.CurrentFilter = searchString; 
            var DispatchNotesList = from s in db.DispatchNotes
                              select s;

            if (!String.IsNullOrEmpty(searchString))
            { 
                DispatchNotesList = DispatchNotesList.Where(s => s.OrderID.Contains(searchString)
                || s.DispatchNoteId.Contains(searchString)
                || s.RecommUserId.Contains(searchString)
                || s.StyleNo.Contains(searchString)
                || s.Remarks.Contains(searchString)
                || s.Recipient.Contains(searchString)
                || s.Address.Contains(searchString));
            }

            //店铺过滤
            DispatchNotesList = DispatchNotesList.Where(s => s.ShopID == WebCookie.ShopID);

            switch (sortOrder)
            {
                case "Date":
                    DispatchNotesList = DispatchNotesList.OrderBy(s => s.CreatedDate);
                    break;
                case "date_desc":
                    DispatchNotesList = DispatchNotesList.OrderByDescending(s => s.CreatedDate);
                    break;
                default:  // Name ascending 
                    DispatchNotesList = DispatchNotesList.OrderByDescending(s => s.CreatedDate);
                    break;
            }

            int pageSize = 50;
            int pageNumber = (page ?? 1);

            return View(DispatchNotesList.ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles = "Supervisor,Admins,StoreAdmin,StorePreSales")]
        [HttpPost]
        public JsonResult dNoteFinConfirm(string DispatchNoteId , [Bind(Include = "DispatchNoteId,DispatchNoteStatus")]DispatchNoteModalView DispatchNoteModalView1)
        {
            ModalDialogView ModalDialogView1 = new ModalDialogView();
            ModalDialogView1.Message = "<h1>OK</h1>";
            ModalDialogView1.MsgCode = "1";
            DispatchNote dispatchNote = db.DispatchNotes.Find(DispatchNoteId);
            dispatchNote.DispatchNoteStatus = DispatchNoteModalView1.DispatchNoteStatus;
            DbEntityEntry<DispatchNote> DispatchNoteEntry = db.Entry<DispatchNote>(dispatchNote);
            
            db.DispatchNotes.Attach(dispatchNote);
            DispatchNoteEntry.Property(e => e.DispatchNoteStatus).IsModified = true; 
            db.SaveChanges();
            return Json(ModalDialogView1);
             
        }

        [Authorize(Roles = "Supervisor,Admins,StoreAdmin,StorePreSales")]
        public ActionResult DefiniteTemplateNote(string DefiniteTemplateNoteId , string DispatchNoteId)
        {
            DefiniteTemplateNote definiteTemplateNote = new DefiniteTemplateNote();
            definiteTemplateNote = db.DefiniteTemplateNotes.Find(DefiniteTemplateNoteId);
            ViewBag.definiteTemplateNote = definiteTemplateNote;
            string RecipientColFields = "DispatchNoteId,OrderID,Recipient,Country,State,District,Address,PostCode,PhoneNumber,TelePhoneNumber";
            //about Relate Table :DispatchNote , TemplateNotePosition , DefiniteTemplateNote

            UserAddress userAddress = db.UserAddresses.Find(definiteTemplateNote.SenderUserAddressID);

            DispatchNote dispatchNote = db.DispatchNotes.Find(DispatchNoteId);
            TemplateNotePosition templateNotePosition = new TemplateNotePosition();
            Type type1 = typeof(DispatchNote);
            Type type2 = typeof(UserAddress);
            List<DispatchNotePrintView> List_DispatchNotePrintView = new List<DispatchNotePrintView>() ;
            foreach (var item in type1.GetProperties())
            {
                DispatchNotePrintView dispatchNotePrintView = new DispatchNotePrintView();
                string TableName = "DispatchNote";
                string DataField = item.Name;
                
                if (RecipientColFields.Contains(DataField))
                {
                    string TemplateNotePositionId = string.Format("{0}_{1}_{2}", DefiniteTemplateNoteId, TableName, DataField);
                    string dataFieldValue = "Recipient " + DataField;
                    if (item.GetValue(dispatchNote)!=null)
                    {
                        dataFieldValue = item.GetValue(dispatchNote).ToString() ;
                    }
                    
                    templateNotePosition = db.TemplateNotePositions.Find(TemplateNotePositionId);
                    if(templateNotePosition!=null)
                    {
                        dispatchNotePrintView.TemplateNotePositionId = TemplateNotePositionId;
                        dispatchNotePrintView.TableName = TableName;
                        dispatchNotePrintView.DataField = DataField;
                        dispatchNotePrintView.DataFieldValue = dataFieldValue;
                        dispatchNotePrintView.FontSize = templateNotePosition.FontSize;
                        dispatchNotePrintView.MaxWidth = templateNotePosition.MaxWidth;
                        dispatchNotePrintView.X = templateNotePosition.X;
                        dispatchNotePrintView.Y = templateNotePosition.Y;
                    }else
                    {
                        //initialize value
                        dispatchNotePrintView.TemplateNotePositionId = TemplateNotePositionId;
                        dispatchNotePrintView.TableName = TableName;
                        dispatchNotePrintView.DataField = DataField;
                        dispatchNotePrintView.DataFieldValue = dataFieldValue;
                        dispatchNotePrintView.FontSize = "12px"; //initialize value
                        dispatchNotePrintView.MaxWidth = "2.5cm"; //initialize value
                        dispatchNotePrintView.X = 10; //initialize value
                        dispatchNotePrintView.Y = 10; //initialize value

                        //templateNotePosition insert
                        TemplateNotePosition templateNotePosition_insert = new TemplateNotePosition();
                        templateNotePosition_insert.TemplateNotePositionId = TemplateNotePositionId;
                        templateNotePosition_insert.TableName = TableName;
                        templateNotePosition_insert.DataField = item.Name;
                        templateNotePosition_insert.FontSize = "12px"; //initialize value
                        templateNotePosition_insert.MaxWidth = "2.5cm"; //initialize value
                        templateNotePosition_insert.X = 10; //initialize value
                        templateNotePosition_insert.Y = 10; //initialize value
                        db.TemplateNotePositions.Add(templateNotePosition_insert);
                        db.SaveChanges();
                    }
                     
                    List_DispatchNotePrintView.Add(dispatchNotePrintView);
                }
            }
            //Add UserAddress
            foreach (var item in type2.GetProperties())
            {
                DispatchNotePrintView dispatchNotePrintView = new DispatchNotePrintView();
                string TableName = "UserAddress";
                string DataField = item.Name;

                if (RecipientColFields.Contains(DataField))
                {
                    string TemplateNotePositionId = string.Format("{0}_{1}_{2}", DefiniteTemplateNoteId, TableName, DataField);
                    string dataFieldValue = "Sender " + DataField;
                    if (item.GetValue(userAddress) != null)
                    {
                        dataFieldValue = item.GetValue(userAddress).ToString();
                    }

                    templateNotePosition = db.TemplateNotePositions.Find(TemplateNotePositionId);
                    if (templateNotePosition != null)
                    {
                        dispatchNotePrintView.TemplateNotePositionId = TemplateNotePositionId;
                        dispatchNotePrintView.TableName = TableName;
                        dispatchNotePrintView.DataField = DataField;
                        dispatchNotePrintView.DataFieldValue = dataFieldValue;
                        dispatchNotePrintView.FontSize = templateNotePosition.FontSize;
                        dispatchNotePrintView.MaxWidth = templateNotePosition.MaxWidth;
                        dispatchNotePrintView.X = templateNotePosition.X;
                        dispatchNotePrintView.Y = templateNotePosition.Y;
                    }
                    else
                    {
                        //initialize value
                        dispatchNotePrintView.TemplateNotePositionId = TemplateNotePositionId;
                        dispatchNotePrintView.TableName = TableName;
                        dispatchNotePrintView.DataField = DataField;
                        dispatchNotePrintView.DataFieldValue = dataFieldValue;
                        dispatchNotePrintView.FontSize = "12px"; //initialize value
                        dispatchNotePrintView.MaxWidth = "2.5cm"; //initialize value
                        dispatchNotePrintView.X = 10; //initialize value
                        dispatchNotePrintView.Y = 10; //initialize value

                        //templateNotePosition insert
                        TemplateNotePosition templateNotePosition_insert = new TemplateNotePosition();
                        templateNotePosition_insert.TemplateNotePositionId = TemplateNotePositionId;
                        templateNotePosition_insert.TableName = TableName;
                        templateNotePosition_insert.DataField = item.Name;
                        templateNotePosition_insert.FontSize = "12px"; //initialize value
                        templateNotePosition_insert.MaxWidth = "2.5cm"; //initialize value
                        templateNotePosition_insert.X = 10; //initialize value
                        templateNotePosition_insert.Y = 10; //initialize value
                        db.TemplateNotePositions.Add(templateNotePosition_insert);
                        db.SaveChanges();
                    }

                    List_DispatchNotePrintView.Add(dispatchNotePrintView);
                }
            }
            return View(List_DispatchNotePrintView.ToList());
        }
        [HttpPost]
        [Authorize(Roles = "Supervisor,Admins,StoreAdmin,StorePreSales")]
        public JsonResult getSenderUserAddressList(string UserID)
        { 
            var userAddresslist = db.UserAddresses.Where(c => c.UserId == UserID && c.ShopID == UserID).OrderByDescending(s => s.OperatedDate); 
            return Json(userAddresslist,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [Authorize(Roles = "Supervisor,Admins,StoreAdmin,StorePreSales")]
        public JsonResult handleUpdTemplateNotePosition(string TemplateNotePositionId ,string FontSize, int X ,int Y, string MaxWidth)
        {
            FontSize = string.IsNullOrEmpty(FontSize) == true ? "12px" : FontSize;
            MaxWidth = string.IsNullOrEmpty(MaxWidth) == true ? "2.5cm" : MaxWidth;
            ModalDialogView modalDialogView = new ModalDialogView();
            modalDialogView.MsgCode = "1";
            modalDialogView.Message = "SUSSESS";

            TemplateNotePosition templateNotePosition = new TemplateNotePosition();
            templateNotePosition = db.TemplateNotePositions.Find(TemplateNotePositionId);
            if(templateNotePosition != null)
            {
                templateNotePosition.FontSize = FontSize;
                templateNotePosition.X = X;
                templateNotePosition.Y = Y;
                templateNotePosition.MaxWidth = MaxWidth;
                try
                {
                    modalDialogView.Message = templateNotePosition.DataField   + "<br>SUSSESS";
                    db.Entry(templateNotePosition).State = EntityState.Modified;
                    db.SaveChanges();

                    return Json(modalDialogView);
                }
                catch(Exception e)
                {
                    modalDialogView.MsgCode = "0";
                    modalDialogView.Message = Lang.Views_GeneralUI_UpdateFail + " : " + e.Message;
                    return Json(modalDialogView);
                }

                
            }
            else
            {
                modalDialogView.MsgCode = "0";
                modalDialogView.Message = Lang.Views_GeneralUI_UpdateFail ;
            }
           
            return Json(modalDialogView);
           
        }

        [HttpGet]
        [Authorize(Roles = "Supervisor,Admins,StoreAdmin,StorePreSales")]
        public ActionResult DefiniteTemplateNoteCreate(string DefiniteTemplateNoteId)
        {
            DefiniteTemplateNote definiteTemplateNote = new DefiniteTemplateNote(); 
            
            string ShopID = WebCookie.ShopID;
            ViewBag.ShopID = ShopID;
            string ExcludeSysDataField = "RecommUserId,CreatedDate,OperatedDate,ShopID, OperatedUserName";
            
            //selectvalue
            string strRecipientColFields = "";
            string strSenderColFields = "";

            if (string.IsNullOrEmpty(DefiniteTemplateNoteId))
            { 
                ViewBag.TempDefiniteTemplateNoteId = "TemplateNoteId" + Guid.NewGuid().ToString("N"); 
            } 
            else
            { 
                //update

                ViewBag.TempDefiniteTemplateNoteId = DefiniteTemplateNoteId;
                ViewBag.CurrentDefiniteTemplateNoteId = DefiniteTemplateNoteId;
                definiteTemplateNote = db.DefiniteTemplateNotes.Find(DefiniteTemplateNoteId);
                strRecipientColFields = definiteTemplateNote.RecipientColFields;
                strSenderColFields = definiteTemplateNote.SenderColFields;
            }

            LoadChkBox(DefiniteTemplateNoteId, strRecipientColFields, strSenderColFields, ExcludeSysDataField);

            return View(definiteTemplateNote);
        }
        public void LoadChkBox(string DefiniteTemplateNoteId, string strRecipientColFields, string strSenderColFields,string ExcludeSysDataField)
        {
            Type type1 = typeof(DispatchNote);
            List<DataFieldsCollection> RecipientColFields = new List<DataFieldsCollection>();
            foreach (var item in type1.GetProperties())
            {
                DataFieldsCollection dataFieldsCollection = new DataFieldsCollection();
                dataFieldsCollection.DataFieldName = item.Name;
                dataFieldsCollection.Assigned = false;
                if(!string.IsNullOrEmpty(DefiniteTemplateNoteId))
                {
                    dataFieldsCollection.Assigned = strRecipientColFields.Contains(item.Name) == true ? true : false;
                }
               

                if (!ExcludeSysDataField.Contains(item.Name))  // Exclude System Field
                {
                    RecipientColFields.Add(dataFieldsCollection);
                }
            }

            ViewBag.RecipientColFields = RecipientColFields;

            //========================================================

            Type type2 = typeof(UserAddress);
            List<DataFieldsCollection> SenderColFields = new List<DataFieldsCollection>();
            foreach (var item in type2.GetProperties())
            {
                DataFieldsCollection dataFieldsCollection = new DataFieldsCollection();
                dataFieldsCollection.DataFieldName = item.Name;
                dataFieldsCollection.Assigned = false;
                if (!string.IsNullOrEmpty(DefiniteTemplateNoteId))
                {
                    dataFieldsCollection.Assigned = strSenderColFields.Contains(item.Name) == true ? true : false;
                } 

                if (!ExcludeSysDataField.Contains(item.Name))  // Exclude System Field
                {
                    SenderColFields.Add(dataFieldsCollection);
                }
            }
            ViewBag.SenderColFields = SenderColFields;
        }

        [HttpPost]
        [Authorize(Roles = "Supervisor,Admins,StoreAdmin,StorePreSales")]
        public JsonResult DefiniteTemplateNoteCreate(string DefiniteTemplateNoteId,string DefiniteTemplateNoteName ,string DefiniteTemplatePicture ,string SenderUserAddressID, string Width, string Height, string[] selectedRecipientColFields, string[] selectedSenderColFields)
        {
            DefiniteTemplateNote definiteTemplateNote = new DefiniteTemplateNote();

            ModalDialogView modalDialogView = new ModalDialogView();
            modalDialogView.MsgCode = "1";
            modalDialogView.Message = "SUSSESS";

            
            if (string.IsNullOrEmpty(DefiniteTemplateNoteId))
            {
                definiteTemplateNote.SenderUserAddressID = SenderUserAddressID;
                definiteTemplateNote.Width = Width;
                definiteTemplateNote.Height = Height;
                definiteTemplateNote.RecipientColFields = selectedRecipientColFields == null ? string.Empty : string.Join(",", selectedRecipientColFields);
                definiteTemplateNote.SenderColFields = selectedSenderColFields == null ? string.Empty : string.Join(",", selectedSenderColFields);
                definiteTemplateNote.ShopID = WebCookie.ShopID;
                definiteTemplateNote.OperatedUserName = User.Identity.Name;
                definiteTemplateNote.OperatedDate = DateTime.Now;
                definiteTemplateNote.DefiniteTemplateNoteId = DefiniteTemplateNoteId;
                definiteTemplateNote.DefiniteTemplateNoteName = DefiniteTemplateNoteName;
                definiteTemplateNote.DefiniteTemplatePicture = DefiniteTemplatePicture;

                //Add
                definiteTemplateNote.DefiniteTemplateNoteId = db.GetTableIdentityID("TN", "DefiniteTemplateNote", 3);
                 
                ViewBag.CurrentDefiniteTemplateNoteId = DefiniteTemplateNoteId;

                try
                {
                    db.DefiniteTemplateNotes.Add(definiteTemplateNote);
                    db.SaveChanges();
                    return Json(modalDialogView);
                }
                catch (Exception e)
                {
                    modalDialogView.MsgCode = "0";
                    modalDialogView.Message = Lang.Views_GeneralUI_OperateFail + "\n\r" + e.Message;
                    return Json(modalDialogView);
                } 
            }
            else
            {
                definiteTemplateNote = db.DefiniteTemplateNotes.Find(DefiniteTemplateNoteId);
                //update
                try
                {
                    if (definiteTemplateNote != null)
                    {
                        definiteTemplateNote.DefiniteTemplateNoteId = DefiniteTemplateNoteId;
                        definiteTemplateNote.DefiniteTemplateNoteName = DefiniteTemplateNoteName;
                        definiteTemplateNote.DefiniteTemplatePicture = DefiniteTemplatePicture;
                        definiteTemplateNote.SenderUserAddressID = SenderUserAddressID;
                        definiteTemplateNote.Width = Width;
                        definiteTemplateNote.Height = Height;

                        definiteTemplateNote.RecipientColFields = selectedRecipientColFields == null ? string.Empty : string.Join(",", selectedRecipientColFields);
                        definiteTemplateNote.SenderColFields = selectedSenderColFields == null ? string.Empty : string.Join(",", selectedSenderColFields);
                        definiteTemplateNote.ShopID = WebCookie.ShopID;
                        definiteTemplateNote.OperatedUserName = User.Identity.Name;
                        definiteTemplateNote.OperatedDate = DateTime.Now;
                        
                        try
                        {
                            db.Entry(definiteTemplateNote).State = EntityState.Modified;
                            db.SaveChanges();
                            return Json(modalDialogView);
                        }
                        catch (Exception e)
                        {
                            modalDialogView.MsgCode = "0";
                            modalDialogView.Message = Lang.Views_GeneralUI_UpdateFail + " : " + e.Message;
                            return Json(modalDialogView);
                        } 
                    }
                    else
                    {
                        modalDialogView.MsgCode = "0";
                        modalDialogView.Message = Lang.Views_GeneralUI_UpdateFail + "\n\r Invalic Id";
                        return Json(modalDialogView);
                    } 
                }
                catch (Exception e)
                {
                    modalDialogView.MsgCode = "0";
                    modalDialogView.Message = Lang.Views_GeneralUI_OperateFail + "\n\r" + e.Message;
                    return Json(modalDialogView);
                }  
            }
             
        }
        
    }

} 