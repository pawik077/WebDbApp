using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models {
  public class Weather {
    public int ID { get; set; }
    public string city { set; get; }
    public string weather { set; get; }
    public float temperature { set; get; }
    public DateTime time { set; get; }
  }
}
