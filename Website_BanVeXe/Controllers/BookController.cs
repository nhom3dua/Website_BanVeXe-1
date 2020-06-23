using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUS_BanVeXe;
using DAL_BanVeXe;
using DTO_BanVeXe;

namespace Website_BanVeXe.Controllers
{
    public class BookController : Controller
    {
        Data_BanVeXeDataContext _db = new Data_BanVeXeDataContext();
        List<int> listSelected;
        // GET: Book
        public void addItemChair(int value)
        {
            listSelected.Add(value);
        }
        [HttpGet]
        public ActionResult Index(FormCollection form)
        {
            BUS_GHE bus_Ghe = new BUS_GHE();

            ViewData["xe"] = bus_Ghe.Load_Ghe_Xe("55A-31589");

            var a = form["bien_so"];
            Console.WriteLine(a);

            var ndi = form["noidi"];
            var nden = form["noiden"];
            var ngaykhoihanh = form["dateStart"];

            ViewData["noidi"] = ndi;
            ViewData["noiden"] = nden;
            ViewData["dateStart"] = ngaykhoihanh;

            return View();
        }
        //public ActionResult LayChuyen(FormCollection f)
        //{
        //    var chuyendi = from chuyen in _db.CHUYENDIs
        //                   from tuyendi in _db.TUYENDIs
        //                   from noiden in _db.NOIDENs
        //                   from noidi in _db.NOIDIs
        //                   from xe in _db.XEs
        //                   from loaixe in _db.LOAIXEs
        //                   from diadiem in _db.DIADIEMLENXEs

        //                   where tuyendi.ID == chuyen.ID_TUYENDI
        //                   && tuyendi.ID_NOIDI == noidi.ID
        //                   && tuyendi.ID_NOIDI == int.Parse(f["noidi"].ToString())

        //                   && tuyendi.ID_NOIDEN == noiden.ID
        //                   && tuyendi.ID_NOIDEN == int.Parse(f["noiden"].ToString())

        //                   && chuyen.THOIGIANKHOIHANH == DateTime.Parse(f["dateStart"].ToString())

        //                   && xe.ID_LOAIXE == loaixe.ID

        //                   && tuyendi.ID == diadiem.ID_TUYENDI
        //                   select new
        //                   {
        //                       id_tuyen = tuyendi.ID,
        //                       ten_tuyen = tuyendi.TENTUYEN,
        //                       khoangcach = tuyendi.KHOANGCACH,
        //                       sogiochay = tuyendi.SOGIOCHAY,
        //                       dongia = tuyendi.DONGIA,

        //                       id_chuyen = chuyen.ID,
        //                       thoigiankhoihanh = chuyen.THOIGIANKHOIHANH,

        //                       id_diadiem = diadiem.ID,
        //                       ten_diadiem = diadiem.TENDD,

        //                       id_xe = xe.ID,
        //                       bienso = xe.BIENSO,
        //                   };
        //    return Json(chuyendi, JsonRequestBehavior.AllowGet);
        //}
        [HttpGet]
        public ActionResult LayTuyen(FormCollection form)
        {
            var tuyen =    from tuyendi in _db.TUYENDIs
                           from nden in _db.NOIDENs
                           from ndi in _db.NOIDIs
                           
                           where tuyendi.ID_NOIDI == int.Parse(form["noidi"])
                           && tuyendi.ID_NOIDEN == int.Parse(form["noiden"])

                           select new
                           {
                               id_tuyen = tuyendi.ID,
                               ten_tuyen = tuyendi.TENTUYEN,
                               dongia =tuyendi.DONGIA,
                               khoangcach = tuyendi.KHOANGCACH,
                               thoigianchay = tuyendi.SOGIOCHAY
                             
                           };
            return Json(tuyen, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult LayDiaDiemLenXe(FormCollection f)
        //{
        //    var tuyen = from tuyendi in _db.TUYENDIs
        //                from diadiem in _db.DIADIEMLENXEs

        //                where tuyendi.ID == diadiem.ID_TUYENDI
        //                && tuyendi.ID_NOIDI == int.Parse(f["noidi"].ToString())

                      

        //                select new
        //                {
        //                    id_tuyen = tuyendi.ID,
        //                    ten_tuyen = tuyendi.TENTUYEN,
        //                    dongia = tuyendi.DONGIA,
        //                    khoangcach = tuyendi.KHOANGCACH,
        //                    thoigianchay = tuyendi.SOGIOCHAY

        //                };
        //    return Json(tuyen, JsonRequestBehavior.AllowGet);
        //}
    }
}