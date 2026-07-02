using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPerfomansLab.Task3
{
    public class Task3
    {

    }

    public class Test
    {
        private int _id;
        private string _title;
        private string _value;
        private List<Test> _values;

        public int Id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public List<Test> Values { get; set; }
    }

    public class ResultTest
    {
        private int _id;
        private string _value;

        public int Id { get; set; }
        public string Value { get; set; }
    }

}
