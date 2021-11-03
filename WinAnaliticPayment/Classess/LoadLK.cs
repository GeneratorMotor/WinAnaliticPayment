using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAnaliticPayment.Classess
{
    public static class LoadLK
    {
        public static List<ЛьготнаяКатегория> GetLK()
        {
            List<ЛьготнаяКатегория> list = new List<ЛьготнаяКатегория>();

            ЛьготнаяКатегория item = new ЛьготнаяКатегория();
            item.ЛьготнаяКатегорияНаименование = "Ветеран военной службы";
            item.Id = 42;

            list.Add(item);

            ЛьготнаяКатегория item2 = new ЛьготнаяКатегория();
            item2.ЛьготнаяКатегорияНаименование = "Ветеран труда";
            item2.Id = 46;

            list.Add(item2);

            ЛьготнаяКатегория item3 = new ЛьготнаяКатегория();
            item3.ЛьготнаяКатегорияНаименование = "Реабилитированные лица";
            item3.Id = 260;

            list.Add(item3);

            ЛьготнаяКатегория item4 = new ЛьготнаяКатегория();
            item4.ЛьготнаяКатегорияНаименование = "Ветеран труда Саратовской области";
            item4.Id = 2297;

            list.Add(item4);

            ЛьготнаяКатегория item5 = new ЛьготнаяКатегория();
            item5.ЛьготнаяКатегорияНаименование = "Труженник тыла";
            item5.Id = 2181;

            list.Add(item5);

            return list;
        }
    }
}
