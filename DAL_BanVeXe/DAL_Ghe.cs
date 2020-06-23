using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_BanVeXe;

namespace DAL_BanVeXe
{
    
    public class DAL_Ghe
    {
        Data_BanVeXeDataContext _db = new Data_BanVeXeDataContext();
        public List<XE> LoadXe()
        {
            return _db.XEs.Select(p => p).ToList<XE>();
        }

        public List<LOAIXE> LoadLoaiXe()
        {
            return _db.LOAIXEs.Select(p => p).ToList<LOAIXE>();
        }

        public List<DTO_Ghe> LoadGhe(string bienSo)
        {
            var a = from xe in _db.XEs
                    from lxe in _db.LOAIXEs
                    where xe.ID_LOAIXE == lxe.ID && xe.BIENSO == bienSo
                    select new
                    {
                        ID = xe.ID,
                        ID_LoaiXe = xe.ID_LOAIXE,
                        BienSo = xe.BIENSO,
                        SoChoNgoi = lxe.SOCHONGOI,
                        TrangThai = xe.TRANGTHAI,
                    };
            List<DTO_Ghe> result = a.ToList().ConvertAll(t => new DTO_Ghe
            {
                ID = t.ID,
                ID_LoaiXe = int.Parse(t.ID_LoaiXe.ToString()),
                BienSo = t.BienSo,
                SoChoNgoi = int.Parse(t.SoChoNgoi.ToString()),
                TrangThai = t.TrangThai,
            });
            return result.ToList<DTO_Ghe>();
        }
    }
}
