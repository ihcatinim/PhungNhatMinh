using System.Runtime.CompilerServices;

class Program
{
    public static void Main(string[] args)
    {
        quanliStudent ql = new quanliStudent();
        int a;
        Console.WriteLine("1.Input infomation");
        Console.WriteLine("2.Sorting student accending by average mark");
        Console.WriteLine("3.Display student");
        Console.WriteLine("4.Search by name");
        Console.WriteLine("5.delete student by id");
        Console.WriteLine("6.Exit");
        Console.WriteLine("nhap chuc nang ban chon:");
        switch(a)
        {
            case 1:
                Console.WriteLine("nhap sinh vien moi:");
                ql.Addstudent();
                break;
            case 2:
                Console.WriteLine("List Student sorting by average mark");
                ql.SortByAVgmarl();
                break;
            case 3:
                Console.WriteLine("list sv");
                ql.Showst();
                break; 
            case 4:
                Console.WriteLine("nhap ten can tim:");
                string tencan = Convert.ToString(Console.ReadLine());
                ql.FindbyName(tencan);
                break;
            case 5:
                Console.WriteLine("xoa ten theo id:");
                Console.WriteLine("Nhap id can xoa:");
                int idxoa = Convert.ToInt32(Console.ReadLine());
                ql.DeletebyID(idxoa);
                break;
            case 6:
                break;
        }
        

        
    }
    class student
    {
        public int id {  get; set; }    
        public string name {  get; set; }
        public string gender {  get; set; }
        public string dob {  get; set; }

        public string Class { set; get; }
        
        public double mark1 {  get; set; }
        public double mark2 { get; set; }
        public double mark3 { get; set; }

        public double dtb { get; set; }

        
        public student()
        {

        }
        public student(int id, string name, string dob, string Class, double mark1, double mark2, double mark3)
        {

            this.id = id;
            this.name = name;
            this.dob = dob;
            this.Class = Class;
            this.mark1 = mark1;
            this.mark2 = mark2;
            this.mark3 = mark3;
            this.dtb = dtb;
        }
       
        
    }
    class quanliStudent
    {
        private List<student> Liststudents;
        public quanliStudent()
        {
            Liststudents = new List<student>();
        }
        

        private int GenerateID()
        {
            int max = 1;
            if (Liststudents != null && Liststudents.Count > 0)
            {
                max = Liststudents[0].id;


                foreach (student st in Liststudents)
                {
                    if (max < st.id)
                    {
                        max = st.id;
                    }

                }

                max++;
            }
                return max; 
        }
        public void SortByAVgmarl()
        {
            Liststudents.Sort(delegate (student st1, student st2)
            {
                return st1.dtb.CompareTo(st2.dtb);
            });
        }
        public void mark_AVG(student st)
        {
            double mark_avg = (st.mark1+st.mark2+ st.mark3)/3;
            st.dtb = mark_avg;
        }
        
        public void Addstudent()
        {
            student st = new student();
            st.id = GenerateID();
            Console.WriteLine("nhap ten sinh vien moi:");
            st.name= Convert.ToString(Console.ReadLine());
            Console.WriteLine("Nhap gioi tinh:");
            st.gender = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Nhap ngay sinh nhat:");
            st.dob = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Nhap lop cua sinh vien:");
            st.Class = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Nhap diem so1:");
            st.mark1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Nhap diem so2:");
            st.mark2 = Convert.ToDouble(Console.ReadLine());  
            Console.WriteLine("Nhap diem so3:");
            st.mark3 = Convert.ToDouble(Console.ReadLine());
            
            Liststudents.Add(st);
        }
        public void Teststudent()
        {
            student student = new student(1,"minh","17112001","lop1",12,2,1);
            Liststudents.Add(student);
        }
        public void Showst()
        {
            foreach(student student in Liststudents)
            {
                Console.WriteLine(student.id);
                Console.WriteLine(student.name);
                Console.WriteLine(student.gender);
                Console.WriteLine(student.Class);
                Console.WriteLine(student.mark1);
                Console.WriteLine(student.mark2);
                Console.WriteLine(student.mark3);
                Console.WriteLine(student.dtb);
            }
        }
        public student FindbyId(int id)
        {
            student src1 = null;
            if (Liststudents != null && Liststudents.Count > 0)
            {
                foreach (student student in Liststudents) {
                    if (student.id == id) {
                        src1 = student;
                    }
                }
              
            }
            return src1;
        }

        public List<student> FindbyName(string key)
        {
            List<student> srchSt = new List<student>();
            if (Liststudents != null &&Liststudents.Count > 0)
            {
                foreach (student student in Liststudents)
                {
                    if(student.name.ToUpper().Contains(key.ToUpper())) {
                    srchSt.Add(student);
                    }
                }
            }
            return srchSt;
        }
        public bool DeletebyID(int id)
        {
            bool Isdelete = false;

            student st  = FindbyId(id);
            if(st!=null)
            {
                Isdelete = Liststudents.Remove(st);
            }
            return Isdelete;
        }
        public void Update(int id)
        {
            student student = FindbyId(id);
            if (student!=null)
            {
                student st = new student();
                st.id = GenerateID();
                Console.WriteLine("cap nhap ten sinh vien moi:");
                st.name = Convert.ToString(Console.ReadLine());
                Console.WriteLine("cap Nhap gioi tinh:");
                st.gender = Convert.ToString(Console.ReadLine());
                Console.WriteLine("cap Nhap ngay sinh nhat:");
                st.dob = Convert.ToString(Console.ReadLine());
                Console.WriteLine("cap Nhap lop cua sinh vien:");
                st.Class = Convert.ToString(Console.ReadLine());
                Console.WriteLine("cap Nhap diem so1:");
                st.mark1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("cap Nhap diem so2:");
                st.mark2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("cap Nhap diem so3:");
                st.mark3 = Convert.ToDouble(Console.ReadLine());

                Liststudents.Add(st);
            }
        }
    }

}