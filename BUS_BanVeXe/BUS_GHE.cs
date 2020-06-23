using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_BanVeXe;
using DAL_BanVeXe;

namespace BUS_BanVeXe
{
    public class BUS_GHE
    {
        DAL_Ghe dal_Ghe = new DAL_Ghe();
        
        public List<LOAIXE> LoadLoaiXe()
        {
            return dal_Ghe.LoadLoaiXe();
        }

        public List<DTO_Ghe> Load_Ghe_Xe(string bienSo)
        {
            return dal_Ghe.LoadGhe(bienSo);
        }
        


    }
}
