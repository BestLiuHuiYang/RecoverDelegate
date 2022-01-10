using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RecoverDelegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*----------------------------------委托ACtion,接受无返回值的方法----------------------------------------*/
            Calculator ca = new Calculator();
            //直接调用report方法
            ca.Report();
            //常规委托
            Action action = new Action(ca.Report);
            //间接调用report方法
            action.Invoke();
            //更简单的调用方法
            action();
            /*----------------------------------泛型委托Func<>-----------------------------------------------------*/
            Func<int, int, int> func = new Func<int, int, int>(ca.Add);
            Func<int, int, int> func1 = new Func<int, int, int>(ca.Sub);
            int z;
            z = func.Invoke(10, 30);
            z = func(10, 30);
            Console.WriteLine(z);
            int z1 = func1.Invoke(50, 40);
            z1 = func1(10, 30);
            Console.WriteLine(z1);
            /*----------------------------------测试委托就是类------------------------------------------------------*/
            Type type = typeof(Action);
            Console.WriteLine(type.IsClass);
            /*----------------------------------自己写的delegate----------------------------------------------------*/
            CalcAll calcAll = new CalcAll();
            DelGetCalc delcalc1 = new DelGetCalc(calcAll.Add);
            DelGetCalc delcalc2 = new DelGetCalc(calcAll.Sub);
            DelGetCalc delcalc3 = new DelGetCalc(calcAll.Mul);
            DelGetCalc delcalc4 = new DelGetCalc(calcAll.Div);
            double x = 100;
            double y = 200;
            double val = 0;
            val = delcalc1.Invoke(x, y);
            Console.WriteLine(val);
            val = delcalc2.Invoke(x, y);
            Console.WriteLine(val);
            val = delcalc3(x, y);
            Console.WriteLine(val);
            val = delcalc4(x, y);
            Console.WriteLine(val);

            /*-----------------------------------委托中的模板方法----------------------------------------------------*/

            //进行生产
            MakeProduct makeProduct = new MakeProduct();
            //将生产的产品放入工厂
            ProductFactory productFactory = new ProductFactory();


            #region 直接调用
            //生产完毕放入盒子中
            MyBox mb1 = productFactory.MakeProductIntoBox(makeProduct.Noodles);
            //输出盒子中产品的名称
            Console.WriteLine(mb1.MyProduct.Pname);
            MyBox mb2 = productFactory.MakeProductIntoBox(makeProduct.Toys);
            Console.WriteLine(mb2.MyProduct.Pname);
            #endregion

            #region 间接调用,类似先将地址存入指针，在通过传递指针寻找地址
            Func<MyProduct> funcmp1() => makeProduct.Noodles;
            MyProduct food;
            food= productFactory.MakeProductIntoBox(funcmp1()).MyProduct;
            Func<MyProduct> funcmp2() => makeProduct.Toys;
            MyProduct toys;
            toys= productFactory.MakeProductIntoBox(funcmp2()).MyProduct;
            Console.WriteLine("食物的名称"+food.Pname+"\n"+"玩具的名称"+food.Pname);
            #endregion
            /*--------------------------------委托中的回调方法（除新增了CallLoger类外其余逻辑于模板方法写法类似）-------------------------------------*/
            CallMakeProduct cmp =new CallMakeProduct();
            CallFactoryOfGood cfg=new CallFactoryOfGood();
            Func<CallProduct> funcapple = new Func<CallProduct>(cmp.Apple);
            Func<CallProduct> funcar = new Func<CallProduct>(cmp.Car);
            CallLoger callLoger= new CallLoger();
            Action<CallProduct> acp = new Action<CallProduct>(callLoger.CallBackLoginfor);
            cfg.PBox(funcapple, acp);
            cfg.PBox(funcar, acp);
            Console.WriteLine(cfg.PBox(funcapple, acp).CallProduct.Cpname);

            //综上可以发现也就是对函数进行间接调用
            Console.ReadKey();
        }
    }

    class Calculator
    {
        public void Report()
        {
            Console.WriteLine("Void Report");
        }
        public int Add(int x, int y)
        {
            return x + y;
        }
        public int Sub(int x, int y)
        {
            return x - y;
        }
    }
}
