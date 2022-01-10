using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoverDelegate
{
    public class CallProduct
    {
        public string Cpname { get; set; }
        public double CPrince { get; set; }
    }
    public class CallBox
    {
        public CallProduct CallProduct { get; set; }
    }
    public class CallMakeProduct
    {
        public CallProduct Apple()
        {
            CallProduct cp = new CallProduct();
            cp.Cpname = "苹果";
            cp.CPrince = 56.3;
            return cp;   
        }
        public CallProduct Car()
        {
            CallProduct cp = new CallProduct();
            cp.Cpname = "车";
            cp.CPrince = 36.3;
            return cp;
        }
    }
    public class CallLoger
    {
        public void CallBackLoginfor(CallProduct cp)
        {
            Console.WriteLine("the price of {0} is {1},time--{2}",cp.Cpname,cp.CPrince,DateTime.UtcNow);
        }
    }
    public class CallFactoryOfGood
    {
        public CallBox PBox(Func<CallProduct> func,Action<CallProduct> LogCallBack)
        {
            CallBox box=new CallBox();
            CallProduct cp=func.Invoke();
            box.CallProduct = cp;
            if (cp.CPrince>50)
            {
                //回调
                LogCallBack(cp);
            }
            return box;
        }
    }
}
