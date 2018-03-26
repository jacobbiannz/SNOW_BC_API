using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using snow_bc_api.src.model;

namespace snow_bc_api.src.data
{
    public class DbInitializer
    {
        public static void Initialize(BcApiDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Countries.Any())
            {
                return;
            }

            //-------------
            var Countries = new Country[]
            {
                new Country{Name="CHINA", CreatedDate = DateTime.Now },

            };

            foreach (Country c in Countries)
            {
                context.Countries.Add(c);
            }
            context.SaveChanges();

            //-------------
            var Proviences = new Provience[]
            {
                new Provience{Name="Beijing", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now, Rate = 5},
                new Provience{Name="Shanghai", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now, Rate = 4},
                new Provience{Name="Xizang", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now, Rate = 3},
                new Provience{Name="Sichuan", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now, Rate = 2},
                new Provience{Name="Yunnan", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now, Rate = 1},

                new Provience{Name="Zhejiang", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now, Rate = 5},
                new Provience{Name="Hainan", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now, Rate = 4},
                new Provience{Name="Fujian", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now, Rate = 3},
                new Provience{Name="Jiangsu", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now, Rate = 2},
                new Provience{Name="Guangdong", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now, Rate = 1},

                new Provience{Name="Guangxi", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now, Rate = 5},
                new Provience{Name="Guizhou", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now, Rate = 4},
                new Provience{Name="Shandong", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now, Rate = 3},
                new Provience{Name="Shanxi", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now, Rate = 2},
                new Provience{Name="Hunan", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now, Rate = 1},

                new Provience{Name="Hubei", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now, Rate = 5},
                new Provience{Name="Anhui", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now, Rate = 4},
                new Provience{Name="Jiangxi", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now, Rate = 3},
                new Provience{Name="Hebei", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now, Rate = 2},
                new Provience{Name="Henan", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now, Rate = 1},
                new Provience{Name="Neimenggu", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now, Rate = 5},
                new Provience{Name="Gansu", Country = Countries.FirstOrDefault(), CreatedDate = DateTime.Now, Rate = 5}

            };


            foreach (Provience p in Proviences)
            {
                context.Proviences.Add(p);
            }
            context.SaveChanges();

            //--------------

            var cities = new List<City>();

            // si chuan
            var siChuan = Proviences.ToList().Find(s => s.Name == "Sichuan");

            var sichuanCities = new City[]
            {
                new City{Name="Chengdu", Provience = siChuan, CreatedDate = DateTime.Now, Rate = siChuan.Rate},
                new City{Name="Daocheng", Provience = siChuan, CreatedDate = DateTime.Now , Rate = siChuan.Rate},
                new City{Name="Dujiangyan", Provience = siChuan, CreatedDate = DateTime.Now , Rate = siChuan.Rate},
                new City{Name="Jiuzhaigou", Provience = siChuan, CreatedDate = DateTime.Now, Rate = siChuan.Rate},
                new City{Name="Seda", Provience = siChuan, CreatedDate = DateTime.Now , Rate = siChuan.Rate},
                new City{Name="Yading", Provience = siChuan, CreatedDate = DateTime.Now , Rate = siChuan.Rate},
                new City{Name="Aba", Provience = siChuan, CreatedDate = DateTime.Now, Rate = siChuan.Rate},
                new City{Name="Ermeishan", Provience = siChuan, CreatedDate = DateTime.Now , Rate = siChuan.Rate},
                new City{Name="Niubeishan", Provience = siChuan, CreatedDate = DateTime.Now , Rate = siChuan.Rate},
            };

            cities.AddRange(sichuanCities);

            //Yun nan
            var yunnan = Proviences.ToList().Find(s => s.Name == "Yunnan");

            var yunnanCities = new City[]
            {
                new City{Name="Lijing", Provience = yunnan, CreatedDate = DateTime.Now, Rate = yunnan.Rate},
                new City{Name="Dali", Provience = yunnan, CreatedDate = DateTime.Now , Rate = yunnan.Rate},
                new City{Name="Kunming", Provience = yunnan, CreatedDate = DateTime.Now , Rate = yunnan.Rate},
                new City{Name="Xianggelila", Provience = yunnan, CreatedDate = DateTime.Now, Rate = yunnan.Rate},
                new City{Name="Luguhu", Provience = yunnan, CreatedDate = DateTime.Now , Rate = yunnan.Rate},
                new City{Name="Shuanglang", Provience = yunnan, CreatedDate = DateTime.Now , Rate = yunnan.Rate},
                new City{Name="Xishuangbanna", Provience = yunnan, CreatedDate = DateTime.Now, Rate = yunnan.Rate},
                new City{Name="Suhe", Provience = yunnan, CreatedDate = DateTime.Now , Rate = yunnan.Rate},
                new City{Name="Tengchong", Provience = yunnan, CreatedDate = DateTime.Now , Rate = yunnan.Rate},
                new City{Name="Yubeng", Provience = yunnan, CreatedDate = DateTime.Now , Rate = yunnan.Rate}
            };

            cities.AddRange(yunnanCities);


            //Zhe jiang
            var zhejiang = Proviences.ToList().Find(s => s.Name == "Zhejiang");

            var zhejiangCities = new City[]
            {
                new City{Name="Hangzhou", Provience = zhejiang, CreatedDate = DateTime.Now, Rate = zhejiang.Rate},
                new City{Name="Wuzhen", Provience = zhejiang, CreatedDate = DateTime.Now , Rate = zhejiang.Rate},
                new City{Name="Xitang", Provience = zhejiang, CreatedDate = DateTime.Now , Rate = zhejiang.Rate},
                new City{Name="Qiandaohu", Provience = zhejiang, CreatedDate = DateTime.Now, Rate = zhejiang.Rate},
                new City{Name="Putuoshan", Provience = zhejiang, CreatedDate = DateTime.Now , Rate = zhejiang.Rate},
                new City{Name="Dongjidao", Provience = zhejiang, CreatedDate = DateTime.Now , Rate = zhejiang.Rate},
                new City{Name="Nantou", Provience = zhejiang, CreatedDate = DateTime.Now, Rate = zhejiang.Rate}

            };
            cities.AddRange(zhejiangCities);

            //Hai nan
            var hainan = Proviences.ToList().Find(s => s.Name == "Hainan");

            var hainanCities = new City[]
            {
                new City{Name="Sanya", Provience = hainan, CreatedDate = DateTime.Now, Rate = hainan.Rate},
                new City{Name="Wuzhizhou", Provience = hainan, CreatedDate = DateTime.Now , Rate = hainan.Rate},
                new City{Name="Haikou", Provience = hainan, CreatedDate = DateTime.Now , Rate = hainan.Rate},
                new City{Name="Wenchang", Provience = hainan, CreatedDate = DateTime.Now, Rate = hainan.Rate},
                new City{Name="Lingshui", Provience = hainan, CreatedDate = DateTime.Now , Rate = hainan.Rate},
                new City{Name="Qionghai", Provience = hainan, CreatedDate = DateTime.Now , Rate = hainan.Rate},
                new City{Name="Boao", Provience = hainan, CreatedDate = DateTime.Now, Rate = hainan.Rate}

            };

            cities.AddRange(hainanCities);



            //Jiang su
            var jiangsu = Proviences.ToList().Find(s => s.Name == "Jiangsu");

            var jiangsuCities = new City[]
            {
                new City{Name="Nanjing", Provience = jiangsu, CreatedDate = DateTime.Now, Rate = jiangsu.Rate},
                new City{Name="Suzhou", Provience = jiangsu, CreatedDate = DateTime.Now , Rate = jiangsu.Rate},
                new City{Name="Wuxi", Provience = jiangsu, CreatedDate = DateTime.Now , Rate = jiangsu.Rate},
                new City{Name="Yangzhou", Provience = jiangsu, CreatedDate = DateTime.Now, Rate = jiangsu.Rate},
                new City{Name="Zhouzhuang", Provience = jiangsu, CreatedDate = DateTime.Now , Rate = jiangsu.Rate},
                new City{Name="Changzhou", Provience = jiangsu, CreatedDate = DateTime.Now , Rate = jiangsu.Rate},
                new City{Name="Lianyungang", Provience = jiangsu, CreatedDate = DateTime.Now, Rate = jiangsu.Rate},
                new City{Name="Tongli", Provience = jiangsu, CreatedDate = DateTime.Now, Rate = jiangsu.Rate}

            };

            cities.AddRange(jiangsuCities);



            //Guang dong
            var guangdong = Proviences.ToList().Find(s => s.Name == "Guangdong");

            var guangdongCities = new City[]
            {
                new City{Name="Guangzhou", Provience = guangdong, CreatedDate = DateTime.Now, Rate = guangdong.Rate},
                new City{Name="Shenzhen", Provience = guangdong, CreatedDate = DateTime.Now , Rate = guangdong.Rate},
                new City{Name="Zhuhai", Provience = guangdong, CreatedDate = DateTime.Now , Rate = guangdong.Rate},
                new City{Name="Shantou", Provience = guangdong, CreatedDate = DateTime.Now, Rate = guangdong.Rate},
                new City{Name="Beihai", Provience = guangdong, CreatedDate = DateTime.Now , Rate = guangdong.Rate}

            };
            cities.AddRange(guangdongCities);



            //xizang
            var xizang = Proviences.ToList().Find(s => s.Name == "Xizang");

            var xizangCities = new City[]
            {
                new City{Name="Lasa", Provience = xizang, CreatedDate = DateTime.Now, Rate = xizang.Rate},
                new City{Name="Linzhi", Provience = xizang, CreatedDate = DateTime.Now , Rate = xizang.Rate},
                new City{Name="Ali", Provience = xizang, CreatedDate = DateTime.Now , Rate = xizang.Rate},
                new City{Name="Qiandongnan", Provience = xizang, CreatedDate = DateTime.Now, Rate = xizang.Rate},
                new City{Name="Libo", Provience = xizang, CreatedDate = DateTime.Now , Rate = xizang.Rate},

                new City{Name="Zhenyuan", Provience = xizang, CreatedDate = DateTime.Now, Rate = xizang.Rate},
                new City{Name="Xijing", Provience = xizang, CreatedDate = DateTime.Now , Rate = xizang.Rate},
                new City{Name="Huangguoshu", Provience = xizang, CreatedDate = DateTime.Now , Rate = xizang.Rate}

            };
            cities.AddRange(xizangCities);


            //shan xi
            var shanxi = Proviences.ToList().Find(s => s.Name == "Shanxi");

            var shanxiCities = new City[]
            {
                new City{Name="Xi'an", Provience = shanxi, CreatedDate = DateTime.Now, Rate = shanxi.Rate}

            };
            cities.AddRange(shanxiCities);


            //Gansu
            var gansu = Proviences.ToList().Find(s => s.Name == "Gansu");

            var gansuCities = new City[]
            {
                new City{Name="Qilian", Provience = gansu, CreatedDate = DateTime.Now, Rate = gansu.Rate},
                new City{Name="Dunhuang", Provience = gansu, CreatedDate = DateTime.Now, Rate = gansu.Rate},
                new City{Name="Lanzhou", Provience = gansu, CreatedDate = DateTime.Now, Rate = gansu.Rate},
                new City{Name="Gannan", Provience = gansu, CreatedDate = DateTime.Now, Rate = gansu.Rate},
                new City{Name="Zhangye", Provience = gansu, CreatedDate = DateTime.Now, Rate = gansu.Rate},
                new City{Name="Jiayuguan", Provience = gansu, CreatedDate = DateTime.Now, Rate = gansu.Rate}

            };
            cities.AddRange(gansuCities);


            //Shan dong
            var shandong = Proviences.ToList().Find(s => s.Name == "Shandong");

            var shandongCities = new City[]
            {
                new City{Name="Qingdao", Provience = shandong, CreatedDate = DateTime.Now, Rate = shandong.Rate},
                new City{Name="Taishan", Provience = shandong, CreatedDate = DateTime.Now, Rate = shandong.Rate},
                new City{Name="Rizhao", Provience = shandong, CreatedDate = DateTime.Now, Rate = shandong.Rate},
                new City{Name="Weihai", Provience = shandong, CreatedDate = DateTime.Now, Rate = shandong.Rate},
                new City{Name="Yantai", Provience = shandong, CreatedDate = DateTime.Now, Rate = shandong.Rate},
                new City{Name="Changdao", Provience = shandong, CreatedDate = DateTime.Now, Rate = shandong.Rate},
                new City{Name="Penglai", Provience = shandong, CreatedDate = DateTime.Now, Rate = shandong.Rate}
            };
            cities.AddRange(shandongCities);


            //Hu nan
            var hunan = Proviences.ToList().Find(s => s.Name == "Hunan");

            var hunanCities = new City[]
            {
                new City{Name="Zhangjiajie", Provience = hunan, CreatedDate = DateTime.Now, Rate = hunan.Rate},
                new City{Name="Fenghuang", Provience = hunan, CreatedDate = DateTime.Now, Rate = hunan.Rate},
                new City{Name="Bingzhou", Provience = hunan, CreatedDate = DateTime.Now, Rate = hunan.Rate},
                new City{Name="Wuhan", Provience = hunan, CreatedDate = DateTime.Now, Rate = hunan.Rate},
                new City{Name="Enshi", Provience = hunan, CreatedDate = DateTime.Now, Rate = hunan.Rate},
                new City{Name="Shennongjia", Provience = hunan, CreatedDate = DateTime.Now, Rate = hunan.Rate}
            };
            cities.AddRange(hunanCities);


            //Jiang xi
            var jingxi = Proviences.ToList().Find(s => s.Name == "Jiangxi");

            var jingxiCities = new City[]
            {
                new City{Name="Jingdezhen", Provience = jingxi, CreatedDate = DateTime.Now, Rate = jingxi.Rate},
                new City{Name="Lushan", Provience = jingxi, CreatedDate = DateTime.Now, Rate = jingxi.Rate},
                new City{Name="Sanqingshan", Provience = jingxi, CreatedDate = DateTime.Now, Rate = jingxi.Rate},
                new City{Name="Nanchang", Provience = jingxi, CreatedDate = DateTime.Now, Rate = jingxi.Rate}
            };
            cities.AddRange(jingxiCities);


            //An hui
            var anhui = Proviences.ToList().Find(s => s.Name == "Anhui");

            var anhuiCities = new City[]
            {
                new City{Name="Huangshan", Provience = anhui, CreatedDate = DateTime.Now, Rate = anhui.Rate},
                new City{Name="Hongcun", Provience = anhui, CreatedDate = DateTime.Now, Rate = anhui.Rate},
                new City{Name="Liyuan", Provience = anhui, CreatedDate = DateTime.Now, Rate = anhui.Rate}
            };
            cities.AddRange(anhuiCities);



            //He bei
            var heibei = Proviences.ToList().Find(s => s.Name == "Hebei");

            var heibeiCities = new City[]
            {
                new City{Name="Beidaihe", Provience = heibei, CreatedDate = DateTime.Now, Rate = heibei.Rate},
                new City{Name="Qinhuangdao", Provience = heibei, CreatedDate = DateTime.Now, Rate = heibei.Rate},
                new City{Name="Chengde", Provience = heibei, CreatedDate = DateTime.Now, Rate = heibei.Rate},
                new City{Name="Zhangbei", Provience = heibei, CreatedDate = DateTime.Now, Rate = heibei.Rate}
            };
            cities.AddRange(heibeiCities);


            //He nan
            var heinan = Proviences.ToList().Find(s => s.Name == "Henan");

            var heinanCities = new City[]
            {
                new City{Name="Shaolinsi", Provience = heinan, CreatedDate = DateTime.Now, Rate = heinan.Rate},
                new City{Name="Luoyang", Provience = heinan, CreatedDate = DateTime.Now, Rate = heinan.Rate},
                new City{Name="Longmenshiku", Provience = heinan, CreatedDate = DateTime.Now, Rate = heinan.Rate}
            };
            cities.AddRange(heinanCities);

            //neimenggu
            var neimenggu = Proviences.ToList().Find(s => s.Name == "Neimenggu");

            var neimengguCities = new City[]
            {
                new City{Name="Hulunbeier", Provience = neimenggu, CreatedDate = DateTime.Now, Rate = neimenggu.Rate},
                new City{Name="Aershan", Provience = neimenggu, CreatedDate = DateTime.Now, Rate = neimenggu.Rate},
                new City{Name="Hailaer", Provience = neimenggu, CreatedDate = DateTime.Now, Rate = neimenggu.Rate}

            };
            cities.AddRange(neimengguCities);


            foreach (City c in cities)
            {
                context.Cities.Add(c);
            }
            context.SaveChanges();
        }
    }
}
