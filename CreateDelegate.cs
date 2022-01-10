using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoverDelegate
{
    //public表明在何处都可以使用
    //delegate表示声明委托
    //double是目标方法的返回值类型
    //GetCalc是委托名称
    //double x,doubel y是目标方法的参数个数和类型
    public delegate double DelGetCalc(double x, double y);

    class CalcAll
    {
        public double Add(double x, double y)
        {
            return x + y;
        }
        public double Sub(double x, double y)
        {
            return x - y;
        }
        public double Mul(double x, double y)
        {
            return x * y;
        }
        public double Div(double x, double y)
        {
            return x / y;
        }
    }
  
}
