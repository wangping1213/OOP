using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OOP.EventApp
{
    public partial class FrmEvent : Form
    {
        private List<String> selectCourses = new List<string>();
        public FrmEvent()
        {
            InitializeComponent();
            List<Course> courseList = this.GetCourseList();
            for (int i = 0; i < courseList.Count; i++)
            {
                AddResource(courseList[i], i);
            }
        }

        private void AddResource(Course course, int index)
        {
            Button button = new Button();
            int x = 0, y = 0;
            x = (index % 5) * 162 + 12;
            y = (index / 5) * 48 + 66;
            if (index >= 5)
            {
                y += (index / 5) * 20;
            }

            button.BackColor = SystemColors.Control;
            button.Location = new Point(x, y);
            button.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));

            button.Name = string.Format("btn_{0}", course.CourseId);
            button.Size = new Size(162, 66);
            button.TabIndex = 0;
            button.Tag = string.Format("{0}_{1}_{2}", course.CourseId, course.CourseHour, course.Teacher);
            button.Text = course.CourseName;
            button.UseVisualStyleBackColor = true;
            button.Click += new EventHandler(this.button_Click);
            this.Controls.Add(button);
        }

        private List<Course> GetCourseList()
        {
            List<Course> courseList = new List<Course>();
            courseList.Add(new Course(".NET课程", 1001, "王老师", 20));
            courseList.Add(new Course("JAVA课程", 1002, "张老师", 23));
            courseList.Add(new Course("操作系统课程", 1003, "王老师", 15));
            courseList.Add(new Course("编译原理课程", 1004, "王老师", 27));
            courseList.Add(new Course("AI人工智能课程", 1005, "王老师", 35));

            courseList.Add(new Course("单片机课程", 1006, "王老师", 17));
            courseList.Add(new Course("C语言课程", 1007, "王老师", 17));
            courseList.Add(new Course("软件工程课程", 1008, "孙老师", 34));
            courseList.Add(new Course("思维导图课程", 1009, "王老师", 27));
            courseList.Add(new Course("高等数学课程", 1010, "王老师", 23));
            courseList.Add(new Course("线性代数能课程", 1011, "王老师", 12));
            return courseList;

        }

        private void button_Click(object sender, EventArgs e)
        {           
            Button button = (Button)sender;
            string courseName = button.Text.Trim();
            string[] arr = button.Tag.ToString().Split('_');
            string result = string.Format("{0}\t\t{1}\t\t{2}\t\t{3}", arr[0], courseName, arr[1], arr[2]);
            this.selectCourses.Add(result);
            button.BackColor = Color.Gray;
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Console.WriteLine("输入所有的课程信息：");
            Console.WriteLine("课程ID\t\t课程名\t\t课时\t\t主讲老师");
            foreach (string item in this.selectCourses)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            this.selectCourses.Clear();
            foreach (Control item in this.Controls)
            {
                if (item is Button && item.Text != "btnSave")
                {
                    item.BackColor = SystemColors.Control;
                }
            }
        }
    }
}
