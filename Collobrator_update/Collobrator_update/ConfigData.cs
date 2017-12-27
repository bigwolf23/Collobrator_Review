using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Collobrator_update
{
    /// <summary>  
    /// <creator>Arnold liu</creator>  
    /// </summary> 
    /// 
    [XmlRoot(@"root")]
    public class ClearCaseConfig
    {
        private string _type;

        [XmlAttribute("type")]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private Head _head;
        //属性的定义  
        [XmlElement("head")]
        public Head Head
        {
            set   //设定属性  
            {
                _head = value;
            }
            get    //从属性获取值  
            {
                return _head;
            }   
        }


        private List<Unit> data = new List<Unit>();

        [XmlArray("data")]
        [XmlArrayItem("unit")]
        public List<Unit> Unit
        {
            get { return data; }
        }
        public void addUnit(Unit e)
        {
            data.Add(e);
        }
    }


    public class Head
    {
        private string _MapDisk;
        [XmlElement("mapDisk")]
        public string MapDisk
        {
            set{
                _MapDisk = value;
            }
            get{
                return _MapDisk;
            }
        }

        private string _branchname;
        [XmlElement("branchname")]
        public string Branchname
        {
            get { return _branchname; }
            set { _branchname = value; }
        }  
    }  


    /// <summary>  
    /// <creator>Arnold liu</creator>  
    /// </summary>  
    [XmlRootAttribute("unit")]
    public class Unit
    {
        private string _name;

        [XmlAttribute("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _name_value;

        [XmlTextAttribute]
        public string Name_value
        {
            get { return _name_value; }
            set { _name_value = value; }
        }
    }  
}
