using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DALUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelCourses modelCourses = new ModelCourses();
            var result1 = modelCourses.Getdata();
            foreach(var value in result1)
            {
                Console.WriteLine(value);
            }
            Batch batch = new Batch();
            batch.ConnectToDB();
            var result2 = batch.ReadfromDB();
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }
            Course course = new Course();
            course.ConnectToDB();
            var result3 = course.ReadfromDB();
            foreach (var item in result3)
            {
                Console.WriteLine(item);
            }
            Faculty faculty = new Faculty();
            faculty.ConnectToDB();
            var result4 = faculty.ReadfromDB();
            foreach (var item in result4)
            {
                Console.WriteLine(item);
            }
            Grader grader = new Grader();
            grader.ConnectToDB();
            var result5 = grader.ReadfromDB();
            foreach (var item in result5)
            {
                Console.WriteLine(item);
            }
            Model model = new Model();
            model.ConnectToDB();
            var result6 = model.ReadfromDB();
            foreach (var item in result6)
            {
                Console.WriteLine(item);
            }
            Participant participant = new Participant();
            participant.ConnectToDB();
            var result7 = participant.ReadfromDB();
            foreach (var item in result7)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
