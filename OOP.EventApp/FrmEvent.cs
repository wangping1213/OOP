using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            System.Windows.Forms.Button button = new System.Windows.Forms.Button();
            int x = 0, y = 0;
            //index = 0 12 48
            //index = 1 12+162 48
            //index = 5 12 + 66+48
            x = (index % 5) * 162 + 12;
            y = (index / 5) * 48 + 66;
            if (index >= 5)
            {
                y += (index / 5) * 20;
            }

            button.Location = new System.Drawing.Point(x, y);
            button.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

            button.Name = string.Format("btn_{0}", course.CourseId);
            button.Size = new System.Drawing.Size(162, 66);
            button.TabIndex = 0;
            button.Tag = string.Format("{0}_{1}_{2}", course.CourseId, course.CourseHour, course.Teacher);
            button.Text = course.CourseName;
            button.UseVisualStyleBackColor = true;
            button.Click += new System.EventHandler(this.button_Click);
            this.Controls.Add(button);
        }

        private List<Course> GetCourseList()
        {
            List<Course> courseList = new List<Course>();
            courseList.Add(new Course(".NET课程", 1001, "王老师", 20));
            courseList.Add(new Course("JAVA课程", 1002, "王老师", 23));
            courseList.Add(new Course("操作系统课程", 1003, "王老师", 15));
            courseList.Add(new Course("编译原理课程", 1004, "王老师", 27));
            courseList.Add(new Course("AI人工智能课程", 1005, "王老师", 35));

            courseList.Add(new Course("单片机课程", 1006, "王老师", 17));
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
        }
    }
}
