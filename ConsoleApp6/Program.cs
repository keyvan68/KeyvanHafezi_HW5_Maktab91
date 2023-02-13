using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //question 1
            //string path1 = @"F:\test\";
            //Console.WriteLine("enter your string to search :");
            //string input = Console.ReadLine();
            //Findtext(path1, input);

            //qustion 2

            //string path2 = @"f:\test1\";
            //Rename(path2);

            //qustion3
            Console.WriteLine("enter number 1 :");
            int number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter number 2 :");
            int number2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter your path : ");
            string path = Console.ReadLine();
            ExHandle(path, number1, number2);
        }
        //question1
        public static void Findtext(string path1, string fintToText)
        {
            //var Finfo = new FileInfo(path1);
            var filepath = Directory.GetFiles(path1, "*.txt", SearchOption.AllDirectories);

            foreach (var item in filepath)
            {
                var File1 = File.ReadAllLines(item);
                
                if (File1.Any())
                {


                    foreach (var item1 in File1.Select((value, i) => (value, i)))
                    {
                        if (item1.value.Contains(fintToText))
                        {
                            Console.WriteLine(item);
                            Console.WriteLine(item1.value);
                            Console.WriteLine(item1.i);
                        }
                        else
                        {
                            Console.WriteLine("not found your string !");
                        }


                    }
                }
                
            }
        }
        //question2

        public static void Rename(string path2)
        {
            var filepath = Directory.GetFiles(path2, "*", SearchOption.AllDirectories);
            foreach (var item in filepath)
            {
                //msktab - maktsb - naktab(
                var filename = Path.GetFileName(item);
                FileInfo fi = new FileInfo(item);
                string fileExt = fi.Extension;
                string newFileName = "maktab"+fileExt;


                if (filename == "msktab" + fileExt || filename == "maktsb" + fileExt || filename == "naktab" + fileExt)
                {
                    newFileName = filename.Replace(filename, "maktab" + fileExt);
                    Console.WriteLine(newFileName);
                    //solution 1
                    File.Move(@"F:\test1\" + filename, @"F:\test1\" + newFileName);
                    //solution 2
                    //File.Copy(@"F:\test1\" + filename, @"F:\test1\" + newFileName);
                    //File.Delete(@"F:\test1\" + filename);
                }
                else
                {
                    Console.WriteLine(filename);
                }




                //if (filename == "msktab" + fileExt || filename == "maktsb" + fileExt || filename == "naktab" + fileExt)
                //{
                //    newFileName = filename.Replace(filename, "maktab" + fileExt);
                //    Console.WriteLine(newFileName);
                //}
                //else
                //{
                //    Console.WriteLine(filename);
                //}


            }
        }

        //question3
        public static void ExHandle(string path, int num1, int num2)
        {

            var attribute = new FileInfo(path);
            var Readonly = attribute.IsReadOnly;
            string str = $@"{path}";
            try
            {
                
                if (num2 != 0)
                {
                    int result = num1 / num2;
                    Console.WriteLine(" devided result is :" + result);
                    

                }
                else if (num2 == 0)
                {
                    throw new DivideByZeroException("Can Not Devided To Zero");
                }
                if (File.Exists(str) && !(Readonly))
                {
                    Console.WriteLine("Found");

                    File.Delete(str);
                    Console.WriteLine("File is deleted");
                    Console.ReadKey();
                }
                else if (File.Exists(str) && Readonly)
                {
                    throw new MemberAccessException("access denied");
                }
                else
                {
                    
                        throw new FileNotFoundException("File Not Found");

                }
                

            }
            catch(Exception e)
            {
                log(e);
                Console.WriteLine(e.Message);
            }
            
        }
        public static void log(Exception e)
        {
            string creatingLog = @"F:\test2\logger.txt";
            var datetime = DateTime.Now;
            using (StreamWriter sw = File.AppendText(creatingLog))
            {
                sw.WriteLine("error message  is : ----------- " + e.Message + "------------" + "time of error --------" + datetime + "---------------");
            }

        }


    }
    
}
