using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAM.Modules
{
    class Categories
    {
        public class ICategory
        {
            public int CategoryId;
            public string CategoryName;
            public string Column1 = "";
            public string[] Column2 = new string[0];

            public double Min;
            public double Max;
        }

        public static List<ICategory> BySection()
        {
            List<ICategory> list = new List<ICategory>();

            list.Add(new ICategory() { CategoryId = 1, CategoryName = "کشاورزی", Column1 = "کشاورزی" });
            list.Add(new ICategory() { CategoryId = 2, CategoryName = "صنعت", Column1 = "صنعت" });
            list.Add(new ICategory() { CategoryId = 3, CategoryName = "مسکن", Column1 = "مسکن" });
            list.Add(new ICategory() { CategoryId = 6, CategoryName = "قرض الحسنه", Column2 = new string[] { "قرض الحسنه" } });
            list.Add(new ICategory() { CategoryId = 6, CategoryName = "قرض الحسنه", Column2 = new string[] { "ازدواج" } });
            list.Add(new ICategory() { CategoryId = 6, CategoryName = "قرض الحسنه", Column2 = new string[] { "کمیته امداد" } });
            list.Add(new ICategory() { CategoryId = 6, CategoryName = "قرض الحسنه", Column2 = new string[] { "بهزیستی" } });
            list.Add(new ICategory() { CategoryId = 6, CategoryName = "قرض الحسنه", Column2 = new string[] { "زندان" } });
            list.Add(new ICategory() { CategoryId = 4, CategoryName = "بازرگانی و خدمات", Column1 = "بازرگانی" });
            list.Add(new ICategory() { CategoryId = 4, CategoryName = "بازرگانی و خدمات", Column1 = "خدمات" });
            list.Add(new ICategory() { CategoryId = 4, CategoryName = "بازرگانی و خدمات", Column1 = "سایر" });
            list.Add(new ICategory() { CategoryId = 100, CategoryName = "سایر", Column1 = "" });
            return list;
        }

        public static List<ICategory> ByContractType()
        {
            List<ICategory> list = new List<ICategory>();

            list.Add(new ICategory() { CategoryId = 1, CategoryName = "فروش اقساطی", Column2 = new string[] { "فروش اقساطی" } });
            list.Add(new ICategory() { CategoryId = 2, CategoryName = "مضاربه", Column2 = new string[] { "مضاربه" } });
            list.Add(new ICategory() { CategoryId = 3, CategoryName = "مشارکت مدنی", Column2 = new string[] { "مشارکت" } });
            list.Add(new ICategory() { CategoryId = 4, CategoryName = "قرض الحسنه", Column2 = new string[] { "قرض الحسنه" } });
            list.Add(new ICategory() { CategoryId = 5, CategoryName = "اجاره به شرط تملیک", Column2 = new string[] { "اجاره به شرط تملیک" } });
            list.Add(new ICategory() { CategoryId = 5, CategoryName = "اجاره به شرط تملیک", Column2 = new string[] { "اجاره بشرط تملیک" } });
            list.Add(new ICategory() { CategoryId = 6, CategoryName = "سلف", Column2 = new string[] { "سلف" } });
            list.Add(new ICategory() { CategoryId = 7, CategoryName = "جعاله", Column2 = new string[] { "جعاله" } });
            list.Add(new ICategory() { CategoryId = 8, CategoryName = "خرید دین", Column2 = new string[] { "اعتبار", "حسابجاری" } });
            list.Add(new ICategory() { CategoryId = 8, CategoryName = "خرید دین", Column2 = new string[] { "خرید دین" } });
            list.Add(new ICategory() { CategoryId = 9, CategoryName = "مرابحه", Column2 = new string[] { "مرابحه" } });
            list.Add(new ICategory() { CategoryId = 100, CategoryName = "سایر", Column2 = new string[] { "" } });
            return list;
        }

        public static List<ICategory> ByFacilityName()
        {
            List<ICategory> list = new List<ICategory>();

            list.Add(new ICategory() { CategoryId = 1, CategoryName = "بنگاه های زود بازده", Column2 = new string[] { "بنگاه" } });
            list.Add(new ICategory() { CategoryId = 2, CategoryName = "اشتغال فراگیر", Column2 = new string[] { "اشتغال فراگیر" } });
            list.Add(new ICategory() { CategoryId = 3, CategoryName = "پذیرندگان", Column2 = new string[] { "پذیرندگان" } });
            list.Add(new ICategory() { CategoryId = 3, CategoryName = "پذیرندگان", Column2 = new string[] { "pos" } });
            list.Add(new ICategory() { CategoryId = 4, CategoryName = "متخصصین", Column2 = new string[] { "متخصصین" } });
            list.Add(new ICategory() { CategoryId = 4, CategoryName = "متخصصین", Column2 = new string[] { "پزشکی" } });
            list.Add(new ICategory() { CategoryId = 5, CategoryName = "اوج", Column2 = new string[] { "اوج" } });
            list.Add(new ICategory() { CategoryId = 6, CategoryName = "شاپ کارت", Column2 = new string[] { "شاپ کارت" } });
            list.Add(new ICategory() { CategoryId = 7, CategoryName = "جام زرین", Column2 = new string[] { "زرین" } });
            list.Add(new ICategory() { CategoryId = 8, CategoryName = "باشگاه مشتریان", Column2 = new string[] { "امتیازی" } });
            list.Add(new ICategory() { CategoryId = 9, CategoryName = "فرهیختگان", Column2 = new string[] { "فرهیختگان" } });

            list.Add(new ICategory() { CategoryId = 10, CategoryName = "نسیه دفعی", Column2 = new string[] { "مرابحه", "دفعی" } });
            list.Add(new ICategory() { CategoryId = 11, CategoryName = "پرنیان", Column2 = new string[] { "کارت اعتباری پرنیان" } });
            list.Add(new ICategory() { CategoryId = 12, CategoryName = "بدون مسدودی", Column2 = new string[] { "کارت اعتباری مرابحه", "مدیریتهای شعب" } });
            list.Add(new ICategory() { CategoryId = 13, CategoryName = "مرابحه", Column2 = new string[] { "کارت اعتباری مرابحه" } });

            list.Add(new ICategory() { CategoryId = 14, CategoryName = "ازدواج", Column2 = new string[] { "ازدواج" } });
            list.Add(new ICategory() { CategoryId = 15, CategoryName = "کمیته امداد", Column2 = new string[] { "کمیته امداد" } });
            list.Add(new ICategory() { CategoryId = 16, CategoryName = "بهزیستی", Column2 = new string[] { "بهزیستی" } });
            list.Add(new ICategory() { CategoryId = 17, CategoryName = "زندانیان", Column2 = new string[] { "زندان" } });
            list.Add(new ICategory() { CategoryId = 18, CategoryName = "مشاغل خانگی", Column2 = new string[] { "مشاغل خانگی" } });
            list.Add(new ICategory() { CategoryId = 18, CategoryName = "مشاغل خانگی", Column2 = new string[] { "اشتغالزایی", "وزارت کار" } });

            list.Add(new ICategory() { CategoryId = 19, CategoryName = "بنیاد شهید", Column2 = new string[] { "بنیاد شهید" } });
            list.Add(new ICategory() { CategoryId = 19, CategoryName = "بنیاد شهید", Column2 = new string[] { "بنیادشهید" } });

            list.Add(new ICategory() { CategoryId = 20, CategoryName = "مسکن روستایی", Column2 = new string[] { "روستایی" } });

            list.Add(new ICategory() { CategoryId = 21, CategoryName = "بافت فرسوده", Column2 = new string[] { "بافت", "فرسوده" } });

            list.Add(new ICategory() { CategoryId = 22, CategoryName = "حوادث", Column2 = new string[] { "حوادث" } });
            list.Add(new ICategory() { CategoryId = 22, CategoryName = "حوادث", Column2 = new string[] { "سیل" } });
            list.Add(new ICategory() { CategoryId = 22, CategoryName = "حوادث", Column2 = new string[] { "طوفان" } });
            list.Add(new ICategory() { CategoryId = 22, CategoryName = "حوادث", Column2 = new string[] { "زلزله" } });

            list.Add(new ICategory() { CategoryId = 23, CategoryName = "اعتبار در حسابجاری", Column2 = new string[] { "اعتبار", "حسابجاری" } });
            list.Add(new ICategory() { CategoryId = 24, CategoryName = "مشارکت مدنی", Column2 = new string[] { "مشارکت" } });
            list.Add(new ICategory() { CategoryId = 25, CategoryName = "فروش اقساطی", Column2 = new string[] { "فروش اقساطی" } });
            list.Add(new ICategory() { CategoryId = 26, CategoryName = "جعاله", Column2 = new string[] { "جعاله" } });
            list.Add(new ICategory() { CategoryId = 27, CategoryName = "سلف", Column2 = new string[] { "سلف" } });
            list.Add(new ICategory() { CategoryId = 28, CategoryName = "خرید دین", Column2 = new string[] { "خرید دین" } });
            list.Add(new ICategory() { CategoryId = 29, CategoryName = "مضاربه", Column2 = new string[] { "مضاربه" } });
            list.Add(new ICategory() { CategoryId = 30, CategoryName = "قرض الحسنه", Column2 = new string[] { "قرض الحسنه" } });
            list.Add(new ICategory() { CategoryId = 31, CategoryName = "مرابحه", Column2 = new string[] { "کارت " } });
            list.Add(new ICategory() { CategoryId = 31, CategoryName = "مرابحه", Column2 = new string[] { "مرابحه" } });
            list.Add(new ICategory() { CategoryId = 31, CategoryName = "مرابحه", Column2 = new string[] { "خرید ملت" } });
            list.Add(new ICategory() { CategoryId = 31, CategoryName = "مرابحه", Column2 = new string[] { "خریدملت" } });

            list.Add(new ICategory() { CategoryId = 100, CategoryName = "سایر", Column2 = new string[] { "" } });
            return list;
        }

        public static List<ICategory> ByBedehkaran()
        {
            List<ICategory> list = new List<ICategory>();

            list.Add(new ICategory() { CategoryId = 1453, CategoryName = "بدهکاران ضمانتنامه ریالی", Column1 = "1453" });
            list.Add(new ICategory() { CategoryId = 1459, CategoryName = "بدهکاران اعتبارات اسنادی داخلی", Column1 = "1459" });
            list.Add(new ICategory() { CategoryId = 1492, CategoryName = "مشکوک الوصول ضمانتنامه ریالی", Column1 = "1492" });
            list.Add(new ICategory() { CategoryId = 1489, CategoryName = "مشکوک الوصول اعتبارات اسنادی داخلی", Column1 = "1489" });
            list.Add(new ICategory() { CategoryId = 1448, CategoryName = "بدهکاران اعتبارات اسنادی وارداتی", Column1 = "1448" });
            list.Add(new ICategory() { CategoryId = 1491, CategoryName = "مشکوک الوصول اعتبارات اسنادی وارداتی", Column1 = "1491" });
            list.Add(new ICategory() { CategoryId = 1451, CategoryName = "بدهکاران اعتبارات اسنادی وارداتی", Column1 = "1451" });

            return list;
        }

        public static List<ICategory> ByAmount1()
        {
            List<ICategory> list = new List<ICategory>();

            list.Add(new ICategory() { CategoryId = 1, CategoryName = "1 تا 100", Min = 0, Max = 100 });
            list.Add(new ICategory() { CategoryId = 2, CategoryName = "100 تا 200", Min = 100, Max = 200 });
            list.Add(new ICategory() { CategoryId = 3, CategoryName = "200 تا 500", Min = 200, Max = 500 });
            list.Add(new ICategory() { CategoryId = 4, CategoryName = "500 تا 1000", Min = 500, Max = 1000 });
            list.Add(new ICategory() { CategoryId = 5, CategoryName = "بالاتر از 1000", Min = 1000, Max = -1 });
            return list;
        }

        public static List<ICategory> ByAmount2()
        {
            List<ICategory> list = new List<ICategory>();

            list.Add(new ICategory() { CategoryId = 1, CategoryName = "1 تا 10", Min = 0, Max = 10 });
            list.Add(new ICategory() { CategoryId = 2, CategoryName = "10 تا 20", Min = 10, Max = 20 });
            list.Add(new ICategory() { CategoryId = 3, CategoryName = "20 تا 50", Min = 20, Max = 50 });
            list.Add(new ICategory() { CategoryId = 4, CategoryName = "50 تا 100", Min = 50, Max = 100 });
            return list;
        }

        public static List<ICategory> ByAmount3()
        {
            List<ICategory> list = new List<ICategory>();

            list.Add(new ICategory() { CategoryId = 1, CategoryName = "1 تا 10", Min = 0, Max = 10 });
            list.Add(new ICategory() { CategoryId = 2, CategoryName = "10 تا 500", Min = 10, Max = 500 });
            list.Add(new ICategory() { CategoryId = 3, CategoryName = "500 تا 2000", Min = 500, Max = 2000 });
            list.Add(new ICategory() { CategoryId = 4, CategoryName = "بالاتر از 2000", Min = 2000, Max = -1 });
            return list;
        }

        public static ICategory GetCategory(List<ICategory> categoryType, string column1, string column2)
        {
            return categoryType.Where(x => column1.Contains(x.Column1) & x.Column2.All(column2.Contains)).FirstOrDefault();
        }

        public static ICategory GetCategory(List<ICategory> categoryType, double amount)
        {
            foreach (var cat in Categories.ByAmount1())
            {
                if (cat.Max == -1)
                {
                    if (amount >= cat.Min)
                    {
                        return cat;
                    }
                }
                else
                {
                    if (amount >= cat.Min & amount < cat.Max)
                    {
                        return cat;
                    }
                }
            }

            return null;
        }
    }
}
