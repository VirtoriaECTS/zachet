using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MolotovaVariant3
{
    public class Students
    {
        //переменные
        public string StuName { get; set; }
        public int GrPoint { get; set; }
        public int StuId { get; set; }

        List<Students> stulist = new List<Students>();

        public void ReadFile()
        {
            
            StreamReader txt = File.OpenText("student.txt");
            while(!txt.EndOfStream)
            {
                string text = txt.ReadLine();
                string[] array = text.Split(new char[] {'|' });
                AddList(array[0], Convert.ToInt32(array[1]));
            }
        }
        public List<Students> StudList()
        {
            return stulist;
        }

        public void AddList(string name, int point)
        {
            stulist.Add(new Students { StuId = stulist.Count, StuName = name, GrPoint = point });
        }

        public string Search(int grPointRank) 
        {
            string anwer = "";
            var students = (from stuMast in stulist
                            group stuMast by stuMast.GrPoint into g
                            orderby g.Key descending
                            select new
                            {
                                StuRecord = g.ToList()
                            }).ToList();

            students[grPointRank - 1].StuRecord
                .ForEach(i => anwer += ($"Индификатор: {i.StuId},  Имя : {i.StuName},  набрал балов : {i.GrPoint}") + "*") ;
            return anwer;
        }
        public string info ()
        {
            string anwer = "";
            stulist
                .ForEach(i => anwer += ($"Индификатор: {i.StuId},  Имя : {i.StuName},  набрал балов : {i.GrPoint}") + "*");
            return anwer;
        }
    }
}
